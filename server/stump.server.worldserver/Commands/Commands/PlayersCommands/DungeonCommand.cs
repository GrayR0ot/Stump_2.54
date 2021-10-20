using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;
using Stump.Server.WorldServer.Database.Dungeons;
using Stump.Server.WorldServer.Game;
using Stump.Server.WorldServer.Game.Dialogs.Interactives;
using Stump.Server.WorldServer.Game.Maps;
using Stump.Server.WorldServer.Game.Maps.Teleport;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class DungeonCommand : InGameCommand
    {
        public DungeonCommand()
        {
            Aliases = new[] {"dj"};
            RequiredRole = RoleEnum.Player;
            Description = "Ouverture du menu des donjons";
        }

        public override void Execute(GameTrigger trigger)
        {
            var character = trigger.Character;
            if (character != null)
            {
                Dictionary<Map, int> destinations = new Dictionary<Map, int>();

                foreach (var dungeon in DungeonManager.Instance.GetAllDungeons())
                {
                    DungeonRecord dungeonRecord = dungeon.Value;
                    int mapId = int.Parse(dungeon.Value.MapsIdsCSV.Split(',').First().Replace(".0", ""));
                    Map map = World.Instance.GetMap(mapId);
                    destinations.Add(map, map.GetFirstFreeCellNearMiddle().Id);
                }

                DungsDialog s = new DungsDialog(character, destinations, true);
                s.Open();
            }
        }
    }
}