using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NLog;
using Stump.Core.Attributes;
using Stump.Server.WorldServer.Database.Monsters;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Fights.Teams;
using Stump.Server.WorldServer.Game.Maps.Cells;
using Stump.Server.WorldServer.Game.Maps.Teleport;

namespace Stump.Server.WorldServer.Game.Maps.Spawns
{
    public class DungeonSpawningPool : SpawningPoolBase
    {
        [Variable(true)] public static int DungeonSpawnsInterval = 30;

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly Dictionary<MonsterGroup, NewMonsterDungeonSpawn> m_groupsSpawn =
            new Dictionary<MonsterGroup, NewMonsterDungeonSpawn>();

        private readonly object m_locker = new object();
        private readonly List<NewMonsterDungeonSpawn> m_spawns = new List<NewMonsterDungeonSpawn>();
        private Queue<NewMonsterDungeonSpawn> m_spawnsQueue = new Queue<NewMonsterDungeonSpawn>();

        public DungeonSpawningPool(Map map)
            : this(map, DungeonSpawnsInterval)
        {
        }

        public DungeonSpawningPool(Map map, int interval)
            : base(map, interval)
        {
        }

        public ReadOnlyCollection<NewMonsterDungeonSpawn> Spawns => m_spawns.AsReadOnly();

        public void AddSpawn(NewMonsterDungeonSpawn spawn)
        {
            lock (m_locker)
            {
                m_spawns.Add(spawn);
                m_spawnsQueue.Enqueue(spawn);
            }
        }

        public void RemoveSpawn(NewMonsterDungeonSpawn spawn)
        {
            lock (m_locker)
            {
                m_spawns.Remove(spawn);

                var asList = m_spawnsQueue.ToList();
                if (asList.Remove(spawn))
                    m_spawnsQueue = new Queue<NewMonsterDungeonSpawn>(asList);
            }
        }

        protected override bool IsLimitReached()
        {
            return m_spawnsQueue.Count == 0;
        }

        protected override MonsterGroup DequeueNextGroupToSpawn()
        {
            if (!Map.CanSpawnMonsters())
            {
                StopAutoSpawn();
                return null;
            }

            lock (m_locker)
            {
                if (m_spawnsQueue.Count == 0)
                {
                    logger.Error("SpawningPool Map = {0} try to spawn a monser but m_groupsToSpawn is empty", Map.Id);
                    return null;
                }

                var spawn = m_spawnsQueue.Dequeue();

                var cell = spawn.CellId == null ? Map.GetRandomFreeCell() : Map.Cells[(int) spawn.CellId];

                var group = new MonsterGroupWithAlternatives(Map.GetNextContextualId(),
                    new ObjectPosition(Map, cell, Map.GetRandomDirection()), this);

                try
                {
                    //1-4
                    group.AddMonster(new Monster(spawn.GroupMonsters[0].MonsterTemplate.Grades.First(), group),
                        1);
                    if (spawn.GroupMonsters.Count >= 2)
                        group.AddMonster(new Monster(spawn.GroupMonsters[1].MonsterTemplate.Grades.First(), group),
                            1);
                    if (spawn.GroupMonsters.Count >= 3)
                        group.AddMonster(new Monster(spawn.GroupMonsters[2].MonsterTemplate.Grades.First(), group),
                            1);
                    if (spawn.GroupMonsters.Count >= 4)
                        group.AddMonster(new Monster(spawn.GroupMonsters[3].MonsterTemplate.Grades.First(), group),
                            1);
                    
                    //1-5
                    group.AddMonster(new Monster(spawn.GroupMonsters[0].MonsterTemplate.Grades.First(), group),
                        5);
                    if (spawn.GroupMonsters.Count >= 2)
                        group.AddMonster(new Monster(spawn.GroupMonsters[1].MonsterTemplate.Grades.First(), group),
                            5);
                    if (spawn.GroupMonsters.Count >= 3)
                        group.AddMonster(new Monster(spawn.GroupMonsters[2].MonsterTemplate.Grades.First(), group),
                            5);
                    if (spawn.GroupMonsters.Count >= 4)
                        group.AddMonster(new Monster(spawn.GroupMonsters[3].MonsterTemplate.Grades.First(), group),
                            5);
                    if (spawn.GroupMonsters.Count >= 5)
                        group.AddMonster(new Monster(spawn.GroupMonsters[4].MonsterTemplate.Grades.First(), group),
                            5);
                    //1-6
                    group.AddMonster(new Monster(spawn.GroupMonsters[0].MonsterTemplate.Grades.First(), group),
                        6);
                    if (spawn.GroupMonsters.Count >= 2)
                        group.AddMonster(new Monster(spawn.GroupMonsters[1].MonsterTemplate.Grades.First(), group),
                            6);
                    if (spawn.GroupMonsters.Count >= 3)
                        group.AddMonster(new Monster(spawn.GroupMonsters[2].MonsterTemplate.Grades.First(), group),
                            6);
                    if (spawn.GroupMonsters.Count >= 4)
                        group.AddMonster(new Monster(spawn.GroupMonsters[3].MonsterTemplate.Grades.First(), group),
                            6);
                    if (spawn.GroupMonsters.Count >= 5)
                        group.AddMonster(new Monster(spawn.GroupMonsters[4].MonsterTemplate.Grades.First(), group),
                            6);
                    if (spawn.GroupMonsters.Count >= 6)
                        group.AddMonster(new Monster(spawn.GroupMonsters[5].MonsterTemplate.Grades.First(), group),
                            6);
                    //1-7
                    group.AddMonster(new Monster(spawn.GroupMonsters[0].MonsterTemplate.Grades.First(), group),
                        7);
                    if (spawn.GroupMonsters.Count >= 2)
                        group.AddMonster(new Monster(spawn.GroupMonsters[1].MonsterTemplate.Grades.First(), group),
                            7);
                    if (spawn.GroupMonsters.Count >= 3)
                        group.AddMonster(new Monster(spawn.GroupMonsters[2].MonsterTemplate.Grades.First(), group),
                            7);
                    if (spawn.GroupMonsters.Count >= 4)
                        group.AddMonster(new Monster(spawn.GroupMonsters[3].MonsterTemplate.Grades.First(), group),
                            7);
                    if (spawn.GroupMonsters.Count >= 5)
                        group.AddMonster(new Monster(spawn.GroupMonsters[4].MonsterTemplate.Grades.First(), group),
                            7);
                    if (spawn.GroupMonsters.Count >= 6)
                        group.AddMonster(new Monster(spawn.GroupMonsters[5].MonsterTemplate.Grades.First(), group),
                            7);
                    if (spawn.GroupMonsters.Count >= 7)
                        group.AddMonster(new Monster(spawn.GroupMonsters[6].MonsterTemplate.Grades.First(), group),
                            7);
                    //1-8
                    group.AddMonster(new Monster(spawn.GroupMonsters[0].MonsterTemplate.Grades.First(), group),
                        8);
                    if (spawn.GroupMonsters.Count >= 2)
                        group.AddMonster(new Monster(spawn.GroupMonsters[1].MonsterTemplate.Grades.First(), group),
                            8);
                    if (spawn.GroupMonsters.Count >= 3)
                        group.AddMonster(new Monster(spawn.GroupMonsters[2].MonsterTemplate.Grades.First(), group),
                            8);
                    if (spawn.GroupMonsters.Count >= 4)
                        group.AddMonster(new Monster(spawn.GroupMonsters[3].MonsterTemplate.Grades.First(), group),
                            8);
                    if (spawn.GroupMonsters.Count >= 5)
                        group.AddMonster(new Monster(spawn.GroupMonsters[4].MonsterTemplate.Grades.First(), group),
                            8);
                    if (spawn.GroupMonsters.Count >= 6)
                        group.AddMonster(new Monster(spawn.GroupMonsters[5].MonsterTemplate.Grades.First(), group),
                            8);
                    if (spawn.GroupMonsters.Count >= 7)
                        group.AddMonster(new Monster(spawn.GroupMonsters[6].MonsterTemplate.Grades.First(), group),
                            8);
                    if (spawn.GroupMonsters.Count >= 8)
                        group.AddMonster(new Monster(spawn.GroupMonsters[7].MonsterTemplate.Grades.First(), group),
                            8);
                    
                    /*foreach (var entity in spawn.GroupMonsters)
                    {
                        try
                        {
                            if (entity.MinPartyMembers != null)
                            {
                                if (entity.DungeonSpawnId == 1)
                                {
                                    Console.WriteLine("Spawning group " + entity.MinPartyMembers);
                                    group.AddMonster(new Monster(entity.MonsterTemplate.Grades.First(), group),
                                        1);
                                }
                                else
                                {
    
                                    group.AddMonster(new Monster(entity.MonsterTemplate.Grades.First(), group),
                                        1);
                                }
                            }
                            else
                                group.AddMonster(new Monster(entity.MonsterTemplate.Grades.First(), group));
                        }
                        catch (Exception e)
                        {
                            /*Console.WriteLine("ERROR Spawning: " + entity.Id);
                            Console.WriteLine("ERROR: : " + e.StackTrace);*/
                    /*}
                }*/
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error spawning dungeon group #" + spawn.Id + " on map " + spawn.MapId);
                }

                m_groupsSpawn.Add(group, spawn);

                return group;
            }
        }

        protected override int GetNextSpawnInterval()
        {
            return Interval * 1000;
        }

        protected override void OnGroupSpawned(MonsterGroup group)
        {
            group.EnterFight += OnGroupEnterFight;

            base.OnGroupSpawned(group);
        }

        private void OnGroupEnterFight(MonsterGroup group, Character character)
        {
            group.EnterFight -= OnGroupEnterFight;
            group.Fight.WinnersDetermined += OnWinnersDetermined;
        }

        private void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            fight.WinnersDetermined -= OnWinnersDetermined;

            if (draw)
                return;

            // if players didn't win they don't get teleported
            if (!(winners is FightPlayerTeam) || !(losers is FightMonsterTeam))
                return;

            var group = ((MonsterFighter) losers.Leader).Monster.Group;

            if (!m_groupsSpawn.ContainsKey(group))
            {
                logger.Error("Group {0} (Map {1}) has ended his fight but is not register in the pool", group.Id,
                    Map.Id);
                return;
            }

            var spawn = m_groupsSpawn[group];

            if (!spawn.TeleportEvent)
                return;

            var pos = spawn.GetTeleportPosition();

            foreach (var fighter in winners.GetAllFighters<CharacterFighter>())
            {
                fighter.Character.NextMap = pos.Map;
                fighter.Character.Cell = pos.Cell;
                fighter.Character.Direction = pos.Direction;


                m_groupsSpawn.Remove(group);
            }
        }

        protected override void OnGroupUnSpawned(MonsterGroup monster)
        {
            lock (m_locker)
            {
                if (!m_groupsSpawn.ContainsKey(monster))
                {
                    logger.Error("Group {0} (Map {1}) was not bind to a dungeon spawn", monster.Id, Map.Id);
                }
                else
                {
                    var spawn = m_groupsSpawn[monster];

                    if (m_spawns.Contains(spawn))
                        m_spawnsQueue.Enqueue(spawn);
                }
            }

            base.OnGroupUnSpawned(monster);
        }
    }
}