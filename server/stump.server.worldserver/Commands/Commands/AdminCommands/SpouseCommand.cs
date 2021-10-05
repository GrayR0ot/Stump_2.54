//using Database.Mariages;
//using Stump.Core.Attributes;
//using Stump.Core.Reflection;
//using Stump.DofusProtocol.Enums;
//using Stump.DofusProtocol.Messages;
//using Stump.DofusProtocol.Types;
//using Stump.Server.BaseServer.Commands;
//using Stump.Server.WorldServer.Commands.Commands.Patterns;
//using Stump.Server.WorldServer.Commands.Trigger;
//using Stump.Server.WorldServer.Game;
//using Stump.Server.WorldServer.Game.Actors.Look;
//using System;
//using System.Drawing;
//namespace Stump.Server.WorldServer.Commands.Commands
//{
//    public class SpouseCommand : InGameCommand
//    {
//        public SpouseCommand()
//        {
//            Aliases = new[] { "spouse" };
//            RequiredRole = RoleEnum.Administrator;
//        }

//        public override void Execute(GameTrigger trigger)
//        {
//            trigger.Character.Client.Send(new SpouseStatusMessage(true));

//            var spouseConnect = World.Instance.IsConnected(trigger.Character.Record.CurrentSpouse);
//            var SpouseRecord = WorldServer.Instance.DBAccessor.Database.Fetch<SpouseRecord>(string.Format(SpouseRelator.FetchByOwner, trigger.Character.Record.CurrentSpouse), new object[0]);

//            foreach (var record in WorldServer.Instance.DBAccessor.Database.Fetch<SpouseRecord>(string.Format(SpouseRelator.FetchByOwner, trigger.Character.Id), new object[0]))
//            {
//                if (trigger.Character.Record.CurrentSpouse != 0 && !spouseConnect && trigger.Character.Record.CurrentSpouse == record.SpouseId)
//                {
//                    trigger.Character.SendServerMessage(
//                         "\n----------------------------------\n" +
//                         "<b>Information sur l'époux / épouse</b>\n" +
//                         "----------------------------------\n" +
//                         "<b>Nom :</b> " + record.name + "\n" +
//                         "<b>Niveau :</b> " + record.level + "\n" +
//                         "<b>Guilde :</b> " + record.guilldName + "\n" +
//                         "<b>Status :</b> Non connecté.");

//                    trigger.Character.Client.Send(new SpouseStatusMessage(true));

//                    trigger.Character.Client.Send(new SpouseInformationsMessage(
//                    new FriendSpouseInformations(1, (ulong)record.Id, record.name, (ushort)record.level, record.breed, record.sex, ActorLook.Parse(record.look).GetEntityLook(),
//                    new GuildInformations(1, record.guilldName != string.Empty ? record.guilldName : "Inconnu", 1), record.alignement)));

//                }
//                else if (trigger.Character.Record.CurrentSpouse != 0 && spouseConnect && trigger.Character.Record.CurrentSpouse == record.SpouseId)
//                {
//                    trigger.Character.SendServerMessage(
//                         "\n----------------------------------\n" +
//                         "<b>Information sur l'époux / épouse</b>\n" +
//                         "----------------------------------\n" +
//                         "<b>Nom :</b> " + record.name + "\n" +
//                         "<b>Niveau :</b> " + record.level + "\n" +
//                         "<b>Guilde :</b> " + record.guilldName + "\n" +
//                         "<b>Status :</b> Connecté.");

//                    trigger.Character.Client.Send(new SpouseStatusMessage(true));

//                    trigger.Character.Client.Send(new SpouseInformationsMessage(
//                    new FriendSpouseOnlineInformations(1, (ulong)record.Id, record.name, (ushort)record.level, record.breed, record.sex, ActorLook.Parse(record.look).GetEntityLook(),
//                    new BasicGuildInformations(1, record.guilldName != string.Empty ? record.guilldName : "Inconnu", 1), record.alignement, record.IsFighting, false, record.PvPEnabled, record.Map, (short)record.SubArea)));
//                }
//                else
//                {
//                    trigger.Character.SendServerMessage("Vous n'êtes pas marié.");
//                }

//                break;
//            }
//        }
//    }
//}

