//using Stump.DofusProtocol.Enums;
//using Stump.Server.BaseServer.Commands;
//using Stump.Server.WorldServer.Commands.Commands.Patterns;
//using Stump.Server.WorldServer.Commands.Trigger;
//using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

//namespace Stump.Server.WorldServer.Commands.Commands
//{
//    public class AddTokenCommand : TargetCommand
//    {
//        public AddTokenCommand()
//        {
//            Aliases = new string[]
//            {
//                "addtoken"
//            };
//            RequiredRole = RoleEnum.Administrator;
//            AddTargetParameter(false, "Defined target");
//            AddParameter<int>("amount", "amount", "Amount of tokens", 5, false, null);
//        }
//        public override void Execute(TriggerBase trigger)
//        {
//            Character[] targets = GetTargets(trigger);


//                for (int i = 0; i < targets.Length; i++)

//                {
//                    Character character = targets[i];
//                    int num = (trigger.Get<int>("amount"));

//                    foreach (var target in GetTargets(trigger))
//                    {
//                        //var item = ItemManager.Instance.CreatePlayerItem(character, 12124, trigger.Get<int>("amount"), true);
//                        var tokens = character.Inventory.Tokens;

//                        if (tokens != null)
//                        {
//                            tokens.Stack += (uint)trigger.Get<int>("amount");
//                            character.Inventory.RefreshItem(tokens);
//                        }
//                        else
//                        {
//                            character.Inventory.CreateTokenItem(trigger.Get<int>("amount"));
//                            character.Inventory.RefreshItem(character.Inventory.Tokens);
//                        }


//                        //character.Inventory.AddItem(trigger.Get<int>("amount"));
//                        character.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_MESSAGE, 21, trigger.Get<int>("amount"), 12124);

//                        target.RefreshActor();
//                        target.SaveLater();

//                        trigger.Reply("Ajout de {0} points boutiques à {1}.", new object[]
//                        {
//                        num,
//                        character.Name
//                        });
//                        character.OpenPopup($"Félicitation, l'équipe d'Asylium vous offre {num} points boutiques.");
//                    }
//                }

//        }
//    }
//}

