//using Stump.DofusProtocol.Enums;
//using Stump.Server.BaseServer.Commands;
//using Stump.Server.WorldServer.Commands.Commands.Patterns;
//using Stump.Server.WorldServer.Commands.Trigger;
//using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
//using Stump.Server.WorldServer.Game.Exchanges.Bank;
//using Stump.Server.WorldServer.Handlers.Inventory;

//namespace Stump.Server.WorldServer.Commands.Commands
//{
//    public class BankCommands : InGameCommand
//    {
//        public BankCommands()
//        {
//            Aliases = new[] { "bank" };
//            Description = "Ouvre la banque.";
//            RequiredRole = RoleEnum.Vip;
//        }
//        public override void Execute(GameTrigger trigger)
//        {
//            Character character = trigger.Character;
//            if (!character.IsFighting())
//            {
//                var dialog = new BankDialog(character);
//                dialog.Open();
//            }
//        }
//    }
//}

