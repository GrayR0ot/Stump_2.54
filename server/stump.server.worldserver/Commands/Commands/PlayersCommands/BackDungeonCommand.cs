using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;
using Stump.Server.WorldServer.Game;
using Stump.Server.WorldServer.Game.Maps.Cells;

namespace Stump.Server.WorldServer.Commands.Commands.PlayersCommands
{
    public class BackDungeonCommand : InGameCommand
    {
        public BackDungeonCommand()
        {
            Aliases = new[] {"back"};
            Description =
                "Cette commande vous permettra de vous téléporter dans la salle du donjon dans laquelle vous êtes mort.";
            RequiredRole = RoleEnum.Player;
        }

        public override void Execute(GameTrigger trigger)
        {
            var character = trigger.Character;
            if (!character.IsFighting())
            {
                if (character.Record.BackDungeon != 0)
                {
                    var map = Singleton<World>.Instance.GetMap(character.Record.BackDungeon);
                    character.Teleport(new ObjectPosition(map, map.GetFirstFreeCellNearMiddle()));
                }
                else
                {
                    trigger.ReplyError("Vous n'avez pas de position sauvegardée.");
                }
            }
            else
            {
                trigger.ReplyError("Pour lancer cette commande, il faut être en dehors d'un combat. ");
            }
        }
    }
}

////using Stump.Core.Reflection;
////using Stump.DofusProtocol.Enums;
////using Stump.Server.WorldServer.Commands.Commands.Patterns;
////using Stump.Server.WorldServer.Commands.Trigger;
////using Stump.Server.WorldServer.Game;
////using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
////using Stump.Server.WorldServer.Game.Maps.Cells;

////namespace Commands
////{
////    class ReturnDj : InGameCommand
////    {
////        public ReturnDj()
////        {
////            Aliases = new string[] { "BACK" };
////            Description = "Cette commande vous permettra de vous téléporter dans la salle du donjon dans laquelle vous êtes mort.";
////            RequiredRole = RoleEnum.Player;
////        }
////        public override void Execute(GameTrigger trigger)
////        {
////            Character character = trigger.Character;
////            if (!character.IsFighting())
////            {
////                if (character.Record.BackDj != 0)
////                    character.Teleport(new ObjectPosition(Singleton<World>.Instance.GetMap(character.Record.BackDj), character.Cell.Id));
////                else
////                    trigger.ReplyError("Vous n'avez pas de position sauvegarder.");
////            }
////            else
////                trigger.ReplyError("Pour lancer cette commande, il faut être en dehors d'un combat. ");
////        }
////    }
////}