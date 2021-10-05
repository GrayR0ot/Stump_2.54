using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using Stump.Server.WorldServer.Database.Monsters;
using Stump.Server.WorldServer.Database.World;

namespace Stump.Server.WorldServer.Game.Maps
{
    public class SuperArea
    {
        private readonly List<Area> m_areas = new List<Area>();
        private readonly List<Map> m_maps = new List<Map>();
        private readonly List<MonsterSpawn> m_monsterSpawns = new List<MonsterSpawn>();
        private readonly List<SubArea> m_subAreas = new List<SubArea>();


        protected internal SuperAreaRecord m_record;

        public SuperArea(SuperAreaRecord record)
        {
            m_record = record;
        }

        public int Id => m_record.Id;

        public string Name => m_record.Name;

        public IEnumerable<Area> Areas => m_areas;

        public IEnumerable<SubArea> SubAreas => m_subAreas;

        public IEnumerable<Map> Maps => m_maps;

        public Dictionary<Point, List<Map>> MapsByPosition { get; } = new Dictionary<Point, List<Map>>();

        public ReadOnlyCollection<MonsterSpawn> MonsterSpawns => m_monsterSpawns.AsReadOnly();

        internal void AddArea(Area area)
        {
            m_areas.Add(area);
            m_subAreas.AddRange(area.SubAreas);
            m_maps.AddRange(area.Maps);

            foreach (var map in area.Maps)
            {
                if (!MapsByPosition.ContainsKey(map.Position))
                    MapsByPosition.Add(map.Position, new List<Map>());

                MapsByPosition[map.Position].Add(map);
            }

            area.SuperArea = this;
        }

        internal void RemoveArea(Area area)
        {
            m_areas.Remove(area);
            m_subAreas.RemoveAll(entry => area.SubAreas.Contains(entry));
            m_maps.RemoveAll(delegate(Map entry)
            {
                if (area.Maps.Contains(entry))
                {
                    if (MapsByPosition.ContainsKey(entry.Position))
                    {
                        var list = MapsByPosition[entry.Position];
                        list.Remove(entry);

                        if (list.Count <= 0)
                            MapsByPosition.Remove(entry.Position);
                    }

                    return true;
                }

                return false;
            });

            area.SuperArea = null;
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
            if (!MapsByPosition.ContainsKey(position))
                return new Map[0];

            return MapsByPosition[position].ToArray();
        }

        public Map[] GetMaps(Point position, bool outdoor)
        {
            if (!MapsByPosition.ContainsKey(position))
                return new Map[0];

            return MapsByPosition[position].Where(entry => entry.Outdoor == outdoor).ToArray();
        }

        public void AddMonsterSpawn(MonsterSpawn spawn)
        {
            m_monsterSpawns.Add(spawn);

            foreach (var area in Areas) area.AddMonsterSpawn(spawn);
        }

        public void RemoveMonsterSpawn(MonsterSpawn spawn)
        {
            m_monsterSpawns.Remove(spawn);

            foreach (var area in Areas) area.RemoveMonsterSpawn(spawn);
        }
    }
}