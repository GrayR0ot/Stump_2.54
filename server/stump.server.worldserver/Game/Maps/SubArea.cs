using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using Stump.Core.Threading;
using Stump.Server.WorldServer.Database.Monsters;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;

namespace Stump.Server.WorldServer.Game.Maps
{
    public class SubArea
    {
        public static readonly Dictionary<Difficulty, double[]> MonsterGroupLengthProb =
            new Dictionary<Difficulty, double[]>
            {
                {Difficulty.VeryEasy, new[] {2.2, 2.0, 1.6, 0.2, 0.1, 0.0, 0.0, 0.0}},
                {Difficulty.Easy, new[] {1.8, 2.0, 1.8, 1.1, 0.4, 0.2, 0.0, 0.0}},
                {Difficulty.Normal, new[] {1.3, 1.5, 1.5, 1.1, 0.6, 0.4, 0.0, 0.0}},
                {Difficulty.Hard, new[] {0.8, 1.0, 1.5, 1.9, 1.3, 0.9, 0.5, 0.1}},
                {Difficulty.VeryHard, new[] {0.2, 0.6, 1.2, 2.2, 1.9, 1.3, 1.1, 0.6}},
                {Difficulty.Insane, new[] {0.1, 0.3, 0.6, 1.0, 1.7, 2.2, 1.7, 1.5}}
            };

        public static readonly Dictionary<Difficulty, double[]> MonsterGradeProb =
            new Dictionary<Difficulty, double[]>
            {
                {Difficulty.VeryEasy, new[] {3.0, 2.0, 1.0, 0.8, 0.5}},
                {Difficulty.Easy, new[] {2.5, 1.5, 1.5, 0.9, 0.6}},
                {Difficulty.Normal, new[] {1.0, 1.0, 1.0, 1.0, 1.0}},
                {Difficulty.Hard, new[] {0.6, 0.8, 1.0, 1.2, 1.2}},
                {Difficulty.VeryHard, new[] {0.4, 0.6, 0.8, 1.0, 1.2}},
                {Difficulty.Insane, new[] {0.1, 0.4, 0.6, 1.0, 2.0}}
            };

        public static readonly Dictionary<Difficulty, uint> MonsterSpawnInterval =
            new Dictionary<Difficulty, uint>
            {
                {Difficulty.VeryEasy, 60},
                {Difficulty.Easy, 90},
                {Difficulty.Normal, 120},
                {Difficulty.Hard, 160},
                {Difficulty.VeryHard, 180},
                {Difficulty.Insane, 220}
            };

        private readonly List<Map> m_maps = new List<Map>();
        private readonly List<MonsterSpawn> m_monsterSpawns = new List<MonsterSpawn>();

        public SubArea(SubAreaRecord record, short bonus)
        {
            Record = record;
            Bonus = bonus;
        }

        public bool IsAgressibleMonsters => true;
        
        public SubAreaRecord Record { get; }

        public int Id => Record.Id;

        public IEnumerable<Map> Maps => m_maps;

        public Dictionary<Point, List<Map>> MapsByPosition { get; } = new Dictionary<Point, List<Map>>();

        public Area Area { get; internal set; }

        public SuperArea SuperArea => Area.SuperArea;

        public short Bonus
        {
            get;
            set;
        }

        public Difficulty Difficulty
        {
            get => Record.Difficulty;
            set => Record.Difficulty = value;
        }

        public int SpawnsLimit
        {
            get => Record.SpawnsLimit;
            set => Record.SpawnsLimit = value;
        }

        public uint? CustomSpawnInterval
        {
            get => Record.CustomSpawnInterval;
            set
            {
                Record.CustomSpawnInterval = value;
                RefreshMapsSpawnInterval();
            }
        }

        public ReadOnlyCollection<MonsterSpawn> MonsterSpawns => m_monsterSpawns.AsReadOnly();

        internal void AddMap(Map map)
        {
            m_maps.Add(map);

            if (!MapsByPosition.ContainsKey(map.Position))
                MapsByPosition.Add(map.Position, new List<Map>());

            MapsByPosition[map.Position].Add(map);

            map.SubArea = this;
        }

        internal void RemoveMap(Map map)
        {
            m_maps.Remove(map);

            if (MapsByPosition.ContainsKey(map.Position))
            {
                var list = MapsByPosition[map.Position];
                list.Remove(map);

                if (list.Count <= 0)
                    MapsByPosition.Remove(map.Position);
            }

            map.SubArea = null;
        }

        public Map[] GetMaps(int x, int y)
        {
            return GetMaps(new Point(x, y));
        }

        public Map[] GetMaps(int x, int y, bool outdoor)
        {
            return GetMaps(new Point(x, y), outdoor);
        }

        public Map[] GetMaps(Point position)
        {
            return !MapsByPosition.ContainsKey(position) ? new Map[0] : MapsByPosition[position].ToArray();
        }

        public Map[] GetMaps(Point position, bool outdoor)
        {
            return !MapsByPosition.ContainsKey(position)
                ? new Map[0]
                : MapsByPosition[position].Where(entry => entry.Outdoor == outdoor).ToArray();
        }

        public void AddMonsterSpawn(MonsterSpawn spawn)
        {
            m_monsterSpawns.Add(spawn);

            foreach (var map in Maps.Where(map => map.Outdoor && !map.Record.SpawnDisabled)) map.AddMonsterSpawn(spawn);
        }

        public void RemoveMonsterSpawn(MonsterSpawn spawn)
        {
            m_monsterSpawns.Remove(spawn);

            foreach (var map in Maps) map.RemoveMonsterSpawn(spawn);
        }

        public int RollMonsterLengthLimit(int imposedLimit = 8)
        {
            var difficulty = Difficulty;

            if (!MonsterGroupLengthProb.ContainsKey(difficulty))
                difficulty = Difficulty.Normal;

            var thresholds = MonsterGroupLengthProb[difficulty].Take(imposedLimit).ToArray();
            var sum = thresholds.Sum();

            var rand = new AsyncRandom();
            var roll = rand.NextDouble(0, sum);

            double l = 0;
            for (var i = 0; i < thresholds.Length; i++)
            {
                l += thresholds[i];

                if (roll <= l)
                    return i + 1;
            }

            return 1;
        }

        public int RollMonsterGrade(int minGrade, int maxGrade)
        {
            var difficulty = Difficulty;

            if (!MonsterGroupLengthProb.ContainsKey(difficulty))
                difficulty = Difficulty.Normal;

            var threshold = MonsterGroupLengthProb[difficulty].Skip(minGrade - 1).Take(maxGrade - minGrade + 1)
                .ToArray();
            var sum = threshold.Sum();

            var rand = new AsyncRandom();
            var roll = rand.NextDouble(0, sum);

            double l = 0;
            for (var i = 0; i < threshold.Length; i++)
            {
                l += threshold[i];

                if (!(roll <= l))
                    continue;

                // in case of additional grades
                if (i < threshold.Length - 1 || maxGrade <= threshold.Length)
                    return i + 1;

                var secondRoll = rand.Next(0, maxGrade - threshold.Length + 1);

                return i + secondRoll + 1;
            }

            return 1;
        }

        public int GetMonsterSpawnInterval()
        {
            var difficulty = Difficulty;

            if (!MonsterSpawnInterval.ContainsKey(difficulty))
                difficulty = Difficulty.Normal;

            if (Record.CustomSpawnInterval.HasValue)
                return (int) Record.CustomSpawnInterval.Value;

            return (int) MonsterSpawnInterval[difficulty];
        }

        private void RefreshMapsSpawnInterval()
        {
            foreach (var pool in Maps.SelectMany(map => map.SpawningPools)) pool.SetTimer(GetMonsterSpawnInterval());
        }
    }
}