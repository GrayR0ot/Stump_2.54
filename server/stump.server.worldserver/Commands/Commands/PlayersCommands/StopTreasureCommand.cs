//using Stump.Core.Reflection;
//using Stump.DofusProtocol.Enums;
//using Stump.DofusProtocol.Messages;
//using Stump.Server.BaseServer;
//using Stump.Server.BaseServer.Commands;
//using Stump.Server.BaseServer.Database;
//using Stump.Server.WorldServer.Commands.Trigger;
//using Stump.Server.WorldServer.Game.Actors.Fight;
//using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;
//using Stump.Server.WorldServer.Game.Fights;
//using Stump.Server.WorldServer.Game.Maps.Cells;
//using Stump.Server.WorldServer.Handlers.Context;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Stump.Server.WorldServer.Commands.Commands.CommandPlayer
//{
//    public class StopTreasureCommand : SubCommandContainer
//    {
//        public StopTreasureCommand()
//        {
//            Aliases = new[] { "abandonner" };
//            RequiredRole = RoleEnum.Player;
//            Description = "Permet d'abandonner une chasse en cours.";
//        }

//        public override void Execute(TriggerBase trigger)
//        {
//            var gameTrigger = trigger as GameTrigger;

//            if (gameTrigger.Character.Record.TreasureSearch != 0 && gameTrigger.Character.Record.TreasureTimeStart < DateTime.Now)
//            {
//                gameTrigger.Character.Record.TreasureSearch = 0;
//                gameTrigger.Character.Record.TreasureMapCoffre = null;
//                gameTrigger.Character.Record.TreasureTimeStart = DateTime.Now;
//                gameTrigger.Character.Record.TreasureIndice = null;

//                DataManager.DefaultDatabase.Update(gameTrigger.Character.Record);

//                if (gameTrigger.Character.HasEmote(EmotesEnum.EMOTE_CHERCHER_UN_TRESOR))
//                {
//                    gameTrigger.Character.RemoveEmote(EmotesEnum.EMOTE_CHERCHER_UN_TRESOR);
//                }

//                gameTrigger.Character.SendServerMessage("Vous venez d'abandonner votre chasse au trésor.", System.Drawing.Color.Orange);
//                gameTrigger.Character.DisplayNotification("Vous avez renoncé à chercher votre <b>Trésor</b>.", NotificationEnum.INFORMATION);

//                DataManager.DefaultDatabase.Update(gameTrigger.Character.Record);
//            }
//            else if (gameTrigger.Character.Record.TreasureSearch != 0 && gameTrigger.Character.Record.TreasureTimeStart > DateTime.Now)
//            {
//                if (gameTrigger.Character.Record.TreasureTimeStart.Minute - DateTime.Now.Minute == 1)
//                {
//                    gameTrigger.Character.SendServerMessage("Vous devez attendre <b>" + (gameTrigger.Character.Record.TreasureTimeStart.Minute - DateTime.Now.Minute) + " minute</b> avant de pouvoir abandonner votre chasse.", System.Drawing.Color.Red);
//                }
//                else
//                {
//                    gameTrigger.Character.SendServerMessage("Vous devez attendre <b>" + (gameTrigger.Character.Record.TreasureTimeStart.Minute - DateTime.Now.Minute) + " minutes</b> avant de pouvoir abandonner votre chasse.", System.Drawing.Color.Red);
//                }
//            }
//            else
//            {
//                gameTrigger.Character.SendServerMessage("Vous devez avoir une chasse en cours pour pouvoir abandonner.", System.Drawing.Color.Red);
//            }
//        }
//    }
//}

