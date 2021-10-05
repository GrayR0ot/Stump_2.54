//using Stump.DofusProtocol.Enums;
//using Stump.Server.BaseServer.Commands;
//using Stump.Server.WorldServer.Commands.Trigger;
//using Stump.Server.WorldServer.Game;
//using Stump.Server.WorldServer.Game.Dialogs.Interactives;
//using Stump.Server.WorldServer.Game.Maps;
//using System.Collections.Generic;

//namespace Stump.Server.WorldServer.Commands.Commands.Teleport
//{
//    public class TpPanel : CommandBase
//    {
//        public TpPanel()
//        {
//            Aliases = new[] { "tp", "TP" };
//            RequiredRole = RoleEnum.Player;
//            Description = "Téléportation aux maps clés du serveur.";
//        }

//        public override void Execute(TriggerBase trigger)
//        {
//            Dictionary<Map, int> destinations = new Dictionary<Map, int>();
//            //destinations.Add(World.Instance.GetMap(191105026), 273);  // ZAAP ASTRUB
//            //destinations.Add(World.Instance.GetMap(192413696), 469); // ZONE SHOP
//            destinations.Add(World.Instance.GetMap(5506048), 359);  // BONTA
//            destinations.Add(World.Instance.GetMap(13631488), 359);  // BRAKMAR
//           // destinations.Add(World.Instance.GetMap(2883603), 437); //FM BONTA
//            destinations.Add(World.Instance.GetMap(99090957), 457); // KANIJEDO

//            //if ((trigger as GameTrigger).UserRole == RoleEnum.Vip)
//            //{
//            //    destinations.Add(World.Instance.GetMap(154627), 382);
//            //}

//            var gameTrigger = trigger as GameTrigger;
//            DungsDialog s = new DungsDialog(gameTrigger.Character, destinations);
//            s.Open();
//        }
//    }
//}

