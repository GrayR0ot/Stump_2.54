using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;

namespace Stump.Server.WorldServer.Game.Arena
{
    public class ArenaTeam : FightTeamWithLeader<CharacterFighter>
    {
        public ArenaTeam(TeamEnum id, Cell[] placementCells)
            : base(id, placementCells)
        {
        }


        public override TeamTypeEnum TeamType => TeamTypeEnum.TEAM_TYPE_PLAYER;
    }
}