using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Commands.Trigger;
using Stump.Server.WorldServer.Game;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Maps.Cells;

namespace Stump.Server.WorldServer.Commands.Commands.Teleport
{
    internal class TpAscensionCommand : CommandBase
    {
        public TpAscensionCommand()
        {
            Aliases = new[] {"next"};
            RequiredRole = RoleEnum.Administrator;
            Description = "Vous téléporte à la prochaine salle de la tour de l'ascension..";
        }

        public static void Teleport(Character player, int actualStairMap, short actualStairCell,
            DirectionsEnum playerDirection)
        {
            player.Teleport(new ObjectPosition(Singleton<World>.Instance.GetMap(actualStairMap), actualStairCell,
                playerDirection));
        }

        public override void Execute(TriggerBase trigger)
        {
            var gameTrigger = trigger as GameTrigger;
            if (gameTrigger != null)
            {
                var actualStairMap = AscensionEnum.getAscensionFloorMap(gameTrigger.Character.AscensionStair)[0];
                var map = World.Instance.GetMap(actualStairMap);

                var actualStairCell = AscensionEnum.getAscensionFloorMap(gameTrigger.Character.AscensionStair)[1];
                var player = gameTrigger.Character;
                Teleport(player, actualStairMap, 384, DirectionsEnum.DIRECTION_SOUTH_EAST);
            }
        }
    }
}