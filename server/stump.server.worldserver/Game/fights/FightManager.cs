using Stump.Core.Pool;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Arena;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Arena;
using Stump.Server.WorldServer.Game.Fights.Teams;
using Stump.Server.WorldServer.Game.Maps;
using Stump.Server.WorldServer.Game.Songes;

namespace Stump.Server.WorldServer.Game.Fights
{
    public class FightManager : EntityManager<FightManager, IFight>
    {
        readonly UniqueIdProvider m_idProvider = new UniqueIdProvider();

        public FightDuel CreateDuel(Map map)
        {
            var challengersTeam = new FightPlayerTeam(TeamEnum.TEAM_CHALLENGER, map.GetRedFightPlacement());
            var defendersTeam = new FightPlayerTeam(TeamEnum.TEAM_DEFENDER, map.GetBlueFightPlacement());

            var fight = new FightDuel(m_idProvider.Pop(), map, defendersTeam, challengersTeam);

            AddEntity(fight.Id, fight);

            return fight;
        }

        public FightPvM CreatePvMFight(Map map)
        {
            var challengersTeam = new FightPlayerTeam(TeamEnum.TEAM_CHALLENGER, map.GetRedFightPlacement());
            var defendersTeam = new FightMonsterTeam(TeamEnum.TEAM_DEFENDER, map.GetBlueFightPlacement());

            var fight = new FightPvM(m_idProvider.Pop(), map, defendersTeam, challengersTeam);

            AddEntity(fight.Id, fight);

            return fight;
        }

        public BreachFight CreateSongesFight(Map map, Character character)
        {
            var challengersTeam = new FightPlayerTeam(TeamEnum.TEAM_CHALLENGER, map.GetRedFightPlacement());
            var defendersTeam = new FightMonsterTeam(TeamEnum.TEAM_DEFENDER, map.GetBlueFightPlacement());

            var fight = new BreachFight(m_idProvider.Pop(), character, map, defendersTeam, challengersTeam, character.breachStep);

            AddEntity(fight.Id, fight);

            return fight;
        }

        public FightPvD CreatePvDFight(Map map)
        {
            var challengersTeam = new FightPlayerTeam(TeamEnum.TEAM_CHALLENGER, map.GetRedFightPlacement());
            var defendersTeam = new FightMonsterTeam(TeamEnum.TEAM_DEFENDER, map.GetBlueFightPlacement());

            var fight = new FightPvD(m_idProvider.Pop(), map, defendersTeam, challengersTeam);

            AddEntity(fight.Id, fight);

            return fight;
        }
       

        public FightAgression CreateAgressionFight(Map map, AlignmentSideEnum redAlignment, AlignmentSideEnum blueAlignment, bool isBattlefield = false)
        {
            var challengersTeam = new FightPlayerTeam(TeamEnum.TEAM_CHALLENGER, map.GetRedFightPlacement(), redAlignment);
            var defendersTeam = new FightPlayerTeam(TeamEnum.TEAM_DEFENDER, map.GetBlueFightPlacement(), blueAlignment);

            var fight = new FightAgression(m_idProvider.Pop(), map, defendersTeam, challengersTeam, isBattlefield);

            AddEntity(fight.Id, fight);

            return fight;
        }

        public FightPvT CreatePvTFight(Map map)
        {
            var challengersTeam = new FightTaxCollectorAttackersTeam(TeamEnum.TEAM_CHALLENGER, map.GetRedFightPlacement());
            var defendersTeam = new FightTaxCollectorDefenderTeam(TeamEnum.TEAM_DEFENDER, map.GetBlueFightPlacement());

            var fight = new FightPvT(m_idProvider.Pop(), map, defendersTeam, challengersTeam);

            AddEntity(fight.Id, fight);

            return fight;
        }      
        
        public ArenaFight CreateArenaFight(ArenaPreFight preFight, int mode)
        {
            var challengersTeam = new ArenaTeam(TeamEnum.TEAM_CHALLENGER, preFight.Arena.Map.GetRedFightPlacement());
            var defendersTeam = new ArenaTeam(TeamEnum.TEAM_DEFENDER, preFight.Arena.Map.GetBlueFightPlacement());

            var fight = new ArenaFight(preFight.Id, preFight.Arena.Map, defendersTeam, challengersTeam, mode);

            AddEntity(fight.Id, fight);

            return fight;
        }
        
        public ArenaPreFight CreateArenaPreFight(ArenaRecord arena)
        {
            var fight = new ArenaPreFight(m_idProvider.Pop(), arena);

            return fight;
        }

        public void Remove(IFight fight)
        {
            RemoveEntity(fight.Id);

            m_idProvider.Push(fight.Id);
        }

        public IFight GetFight(int id) => GetEntityOrDefault(id);
    }
}