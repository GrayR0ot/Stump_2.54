//using Stump.DofusProtocol.Enums;
//using Stump.Server.BaseServer.Commands;
//using Stump.Server.WorldServer.Commands.Trigger;
//using Stump.Server.WorldServer.Game;
//using Stump.Server.WorldServer.Game.Dialogs.Interactives;
//using Stump.Server.WorldServer.Game.Maps;
//using System.Collections.Generic;

//namespace Stump.Server.WorldServer.Commands.Commands.Teleport
//{
//    public class XpPanel : CommandBase
//    {
//        public XpPanel()
//        {
//            Aliases = new[] { "xp", "XP" };
//            RequiredRole = RoleEnum.Player;
//            Description = "Téléportation aux maps xp clés du serveur.";
//        }

//        public override void Execute(TriggerBase trigger)
//        {
//            Dictionary<Map, int> destinations = new Dictionary<Map, int>();
//            destinations.Add(World.Instance.GetMap(195297282), 524);
//            destinations.Add(World.Instance.GetMap(154141187), 189);

//            var gameTrigger = trigger as GameTrigger;
//            DungsDialog s = new DungsDialog(gameTrigger.Character, destinations);
//            s.Open();
//        }
//    }
//}

