//using Stump.DofusProtocol.Enums;
//using Stump.Server.BaseServer.Commands;
//using Stump.Server.WorldServer.Commands.Commands.Patterns;
//using Stump.Server.WorldServer.Commands.Trigger;
//using Stump.Server.WorldServer.Game.Actors.Fight;
//using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
//using Stump.Server.WorldServer.Game.Exchanges.Bank;
//using Stump.Server.WorldServer.Game.Exchanges.BidHouse;
//using Stump.Server.WorldServer.Game.Fights;
//using Stump.Server.WorldServer.Handlers.Inventory;
//using System;
//using System.Linq;

//namespace Stump.Server.WorldServer.Commands.Commands
//{
//    public class HdvCommand : InGameCommand
//    {
//        public HdvCommand()
//        {
//            Aliases = new[] { "hdv" };
//            Description = "Permet d'ouvrir l'hotel de vente général.";
//            RequiredRole = RoleEnum.Vip;
//        }

//        public override void Execute(GameTrigger trigger)
//        {
//            var strType = "1,9,2,114,3,4,5,22,19,7,8,21,6,11,82,17,81,10,16,169,199,151,177,12,43,79,172,184,25,42,74,166,93,33,173,13,188,76,75,200,49,86,165,112,100,69,190,18,121,97,196,207,113,93,90,124,123,46,47,48,53,54,55,56,57,58,59,65,15,68,103,104,105,106,107,109,110,111,119,153,164,195,178,34,35,36,38,39,40,41,50,51,60,63,66,70,71,84,87,95,96,98,108,152,167,179,182,183,185,78,26,189,211,212".Split(',');
//            var listType = strType.ToList().Select(x => Convert.ToInt32(x));
//            var ad = new BidHouseExchange(trigger.Character, listType, 200, true);
//            ad.Open();
//        }
//    }
//}

