//using Stump.DofusProtocol.Enums;
//using Stump.Server.BaseServer.Commands;
//using Stump.Server.WorldServer.Commands.Commands.Patterns;
//using Stump.Server.WorldServer.Commands.Trigger;
//using Stump.Server.WorldServer.Database.Npcs;
//using Stump.Server.WorldServer.Game.Maps;
//using Stump.Server.WorldServer.Game.Maps.Cells;

//namespace Stump.Server.WorldServer.Commands.Commands
//{
//    public class IaControl : InGameCommand
//    {
//        public IaControl()
//        {
//            Aliases = new[] { "ia" };
//            RequiredRole = RoleEnum.Administrator;
//            Description = "Définit si vous souhaitez ou non controler l'ia";

//        }

//        public override void Execute(GameTrigger trigger)
//        {
//            var character = trigger.Character;
//            if (character != null)
//            {
//                if (character.IAControl == false)
//                {
//                    character.IAControl = true;
//                    character.SendServerMessage("Le contrôle des invocations est désormais activé.", System.Drawing.Color.Green);
//                }
//                else
//                {
//                    character.IAControl = false;
//                    character.SendServerMessage("Le contrôle des invocations est désormais désactivé.", System.Drawing.Color.Red);
//                }


//            }
//        }

//    }
//}

