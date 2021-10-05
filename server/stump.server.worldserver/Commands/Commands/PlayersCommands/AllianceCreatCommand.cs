//using Stump.DofusProtocol.Enums;
//using Stump.Server.WorldServer.Commands.Commands.Patterns;
//using Stump.Server.WorldServer.Commands.Trigger;
//using Stump.Server.WorldServer.Game.Dialogs.Alliances;
//using System.Drawing;
//using Stump.Core.Reflection;
//using Stump.Server.BaseServer.Commands;
//using Stump.Server.WorldServer.Game;
//using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
//using Stump.Server.WorldServer.Game.Alliances;


//namespace Stump.Server.WorldServer.Commands.Commands
//{
//    public class InvitarAlianza : TargetCommand
//    {
//        public InvitarAlianza()
//        {
//            base.Aliases = new string[]
//            {
//                "inviter"
//            };
//            RequiredRole = RoleEnum.Player;
//            Description = "Invite le chef de guilde a faire partie de votre alliance.";
//            AddParameter("chef", isOptional: false, converter: ParametersConverter.CharacterConverter);
//        }

//        public override void Execute(TriggerBase trigger)
//        {
//            var gameTrigger = trigger as GameTrigger;
//            var player = gameTrigger.Character;
//            Character objetivo;
//            objetivo = trigger.Get<Character>("chef");

//            if (objetivo == null)
//            {
//                player.SendServerMessage("vous devez indiquer le nom du chef que vous voulez inviter");
//                return;
//            }

//            foreach (var target in GetTargets(trigger))
//            {
//                if (player.Guild?.Alliance != null)
//                {
//                    if (!player.GuildMember.HasRight(GuildRightsBitEnum.GUILD_RIGHT_INVITE_NEW_MEMBERS)) // ALLIANCE_RIGHT_RECRUIT_GUILDS = 8
//                    {
//                        player.SendServerMessage("vous n'avez pas la perimission de faire ceci.", Color.Crimson);
//                        player.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_ERROR, 207); //TODO: Explore messages to send correctly ids
//                    }
//                    else
//                    {
//                        var character = Singleton<World>.Instance.GetCharacter(objetivo.Id);
//                        if (character == null)
//                        {
//                            player.SendServerMessage("le joueur n'est pas disponible.", Color.Crimson);
//                            player.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_ERROR, 208);
//                        }
//                        else
//                        {
//                            if (character.Guild == null || character.Guild.Alliance != null || !character.GuildMember.IsBoss)
//                            {
//                                player.SendServerMessage("Vous n'êtes pas chef de l'alliance.", Color.Crimson);
//                                player.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_ERROR, 206);
//                            }
//                            else
//                            {
//                                //   alliancevar = character.Guild.Alliance;
//                                if (character.IsBusy())
//                                {
//                                    player.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_ERROR, 209);
//                                }
//                                else
//                                {

//                                    AllianceInvitationRequest guildInvitationRequest = new AllianceInvitationRequest(player, character);
//                                    guildInvitationRequest.Open();
//                                }
//                            }
//                        }
//                    }
//                }
//                else
//                {
//                    player.SendServerMessage("Il y a eu une erreur :<br>- Vous n'êtes pas dans une alliance.<br>- Vous n'avez pas les permissions.<br>- La personne est indisponible.", Color.Crimson);
//                }
//            }
//        }
//    }

//    public class AllianceCreateCommand : InGameSubCommand
//    {
//        public AllianceCreateCommand () 
//{
//            base.Aliases = new string[] {
//                "crear"
//            };

//            base.RequiredRole = RoleEnum.Player;
//            ParentCommandType = typeof (AllianceCommand);
//        }

//        public override void Execute (GameTrigger trigger) {
//            var allianceCreationPanel = new AllianceCreationPanel (trigger.Character);
//            allianceCreationPanel.Open ();
//        }

//    }


//}

