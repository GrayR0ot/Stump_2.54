using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Messages;
using Stump.DofusProtocol.Types;
using Stump.Server.BaseServer.Network;
using Stump.Server.WorldServer.Core.Network;
using Stump.Server.WorldServer.Game;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Actors.RolePlay;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Arena;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.HavenBags;
using Stump.Server.WorldServer.Game.Interactives.Skills;
using Stump.Server.WorldServer.Game.Maps;
using Stump.Server.WorldServer.Game.Maps.Paddocks;
using Stump.Server.WorldServer.Game.Songes;

namespace Stump.Server.WorldServer.Handlers.Context.RolePlay
{
    public partial class ContextRoleplayHandler : WorldHandlerContainer
    {
        [WorldHandler(ChangeMapMessage.Id)]
        public static void HandleChangeMapMessage(WorldClient client, ChangeMapMessage message)
        {
            var neighbourState = client.Character.Map.GetClientMapRelativePosition((int) message.MapId);
            var scrollAction = WorldMapScrollActionManager.Instance.GetWorldMapScroll(client.Character.Map);

            if (scrollAction != null)
            {
                Map newDestination = null;
                if (neighbourState == MapNeighbour.Top && scrollAction.TopMapId != 0)
                    newDestination = World.Instance.GetMap(scrollAction.TopMapId);
                if (neighbourState == MapNeighbour.Bottom && scrollAction.BottomMapId != 0)
                    newDestination = World.Instance.GetMap(scrollAction.BottomMapId);
                if (neighbourState == MapNeighbour.Left && scrollAction.LeftMapId != 0)
                    newDestination = World.Instance.GetMap(scrollAction.LeftMapId);
                if (neighbourState == MapNeighbour.Right && scrollAction.RightMapId != 0)
                    newDestination = World.Instance.GetMap(scrollAction.RightMapId);

                if (newDestination != null)
                {
                    client.Character.Teleport(newDestination, neighbourState);
                    return;
                }
            }

            // todo : check with MapChangeData the neighbour validity
            if (neighbourState != MapNeighbour.None && client.Character.Position.Cell.MapChangeData != 0)
                client.Character.Teleport(neighbourState);
        }

        [WorldHandler(MapInformationsRequestMessage.Id)]
        public static void HandleMapInformationsRequestMessage(WorldClient client,
            MapInformationsRequestMessage message)
        {
            SendMapComplementaryInformationsDataMessage(client);

            if (client.Character.Map.Id == 195561472)
                SendMapComplementaryInformationsBreachMessage(client);

            var objectItems = client.Character.Map.GetObjectItems();
            if (client.Character.Map.Id == ArenaManager.KolizeumMapId)
            {
                var arenaCount = ArenaManager.Instance.Arenas_1vs1.Sum(x => x.Value.Map.GetFightCount()) +
                                 ArenaManager.Instance.Arenas_3vs3.Sum(x => x.Value.Map.GetFightCount());

                if (arenaCount > 0)
                    SendMapFightCountMessage(client, (short) arenaCount);
            }
            else if (client.Character.Map.GetFightCount() > 0)
            {
                SendMapFightCountMessage(client, client.Character.Map.GetFightCount());
            }

            foreach (var objectItem in objectItems.ToArray())
                SendObjectGroundAddedMessage(client, objectItem);

            var paddock = PaddockManager.Instance.GetPaddockByMap((int) message.MapId);
            if (paddock != null)
                client.Send(paddock.GetPaddockPropertiesMessage());

            var skills = client.Character.Map.GetInteractiveObjects().SelectMany(x =>
                x.GetSkills().Where(y => (y is SkillCraft || y is SkillRuneCraft) && y.IsEnabled(client.Character))
                    .Select(y => y.SkillTemplate)).Distinct();

            SendJobMultiCraftAvailableSkillsMessage(client, client.Character, skills, true);
        }

        [WorldHandler(MapRunningFightListRequestMessage.Id)]
        public static void HandleMapRunningFightListRequestMessage(WorldClient client,
            MapRunningFightListRequestMessage message)
        {
            if (client.Character.Map.Id == ArenaManager.KolizeumMapId)
                SendMapRunningFightListMessage(client,
                    ArenaManager.Instance.Arenas_1vs1.SelectMany(x => x.Value.Map.Fights)
                        .Concat(ArenaManager.Instance.Arenas_3vs3.SelectMany(x => x.Value.Map.Fights)),
                    client.Character);
            else
                SendMapRunningFightListMessage(client, client.Character.Map.Fights, client.Character);
        }

        [WorldHandler(GuidedModeReturnRequestMessage.Id)]
        public static void HandleGuidedModeReturnRequestMessage(WorldClient client,
            GuidedModeReturnRequestMessage message)
        {
            var map = World.Instance.GetMap(152305664);
            client.Character.Teleport(map, map.GetCell(342));
        }

        [WorldHandler(GuidedModeQuitRequestMessage.Id)]
        public static void HandleGuidedModeQuitRequestMessage(WorldClient client, GuidedModeQuitRequestMessage message)
        {
            var map = World.Instance.GetMap(153092354);
            client.Character.Teleport(map, map.GetCell(328));
        }

        [WorldHandler(MapRunningFightDetailsRequestMessage.Id)]
        public static void HandleMapRunningFightDetailsRequestMessage(WorldClient client,
            MapRunningFightDetailsRequestMessage message)
        {
            var fight = FightManager.Instance.GetFight(message.FightId);

            if (fight == null || fight.Map != client.Character.Map &&
                client.Character.Map.Id != ArenaManager.KolizeumMapId)
                return;

            SendMapRunningFightDetailsMessage(client, fight);
        }

        [WorldHandler(GameRolePlayFreeSoulRequestMessage.Id)]
        public static void HandleGameRoleplayFreeSoulRequestMessage(WorldClient client,
            GameRolePlayFreeSoulRequestMessage message)
        {
            client.Character.FreeSoul();
        }

        public static void SendMapRunningFightListMessage(IPacketReceiver client, IEnumerable<IFight> fights,
            Character character)
        {
            client.Send(new MapRunningFightListMessage(fights
                .Select(entry => entry.GetFightExternalInformations(character)).ToArray()));
        }

        public static void SendMapRunningFightDetailsMessage(IPacketReceiver client, IFight fight)
        {
            var redFighters = fight.ChallengersTeam.GetAllFighters(x => !(x is SummonedFighter) && !(x is SummonedBomb))
                .ToArray();
            var blueFighters = fight.DefendersTeam.GetAllFighters(x => !(x is SummonedFighter) && !(x is SummonedBomb))
                .ToArray();

            var partiesName = fight.GetPartiesName().ToArray();

            if (partiesName.Length > 0)
                client.Send(new MapRunningFightDetailsExtendedMessage(
                    (ushort) fight.Id,
                    redFighters.Select(entry => entry.GetGameFightFighterLightInformations()).ToArray(),
                    blueFighters.Select(entry => entry.GetGameFightFighterLightInformations()).ToArray(),
                    partiesName));
            else
                client.Send(new MapRunningFightDetailsMessage(
                    (ushort) fight.Id,
                    redFighters.Select(entry => entry.GetGameFightFighterLightInformations()).ToArray(),
                    blueFighters.Select(entry => entry.GetGameFightFighterLightInformations()).ToArray()));
        }

        public static void SendCurrentMapMessage(IPacketReceiver client, int mapId)
        {
            // todo
            client.Send(new CurrentMapMessage(mapId, "649ae451ca33ec53bbcbcc33becf15f4"));
        }

        public static void SendMapFightCountMessage(IPacketReceiver client, short fightsCount)
        {
            client.Send(new MapFightCountMessage((ushort) fightsCount));
        }

        public static void SendMapComplementaryInformationsDataMessage(WorldClient client)
        {
            var cm = client.Character.Map.GetMapComplementaryInformationsDataMessage(client.Character);
            client.Send(cm);
            if (cm is MapComplementaryInformationsDataInHavenBagMessage)
            {
                var havenbag =
                    HavenBagManager.Instance.GetHavenBagByOwner(client.Character.Record.HavenBagOwnerId);
                var havenbagfurnitures = HavenBagManager.Instance.GetHavenBagFurnitures()
                    .Where(x => x.HavenBagId == havenbag.HavenBagId).Select(v => v.HavenBagFurnitureInformation)
                    .ToArray();
                ContextHandler.SendHavenBagFurnituresMessage(client, havenbagfurnitures);
                ContextHandler.SendHavenBagPermissionsUpdateMessage(client,
                    HavenBagManager.Instance.GetHavenBagPermissions(havenbag.FriendsAllowed,
                        havenbag.GuildAllowed));
            }
        }

        public static void SendGameRolePlayShowActorMessage(IPacketReceiver client, Character character,
            RolePlayActor actor)
        {
            client.Send(
                new GameRolePlayShowActorMessage(
                    actor.GetGameContextActorInformations(character) as GameRolePlayActorInformations));
        }

        public static void SendObjectGroundAddedMessage(IPacketReceiver client, WorldObjectItem objectItem)
        {
            client.Send(new ObjectGroundAddedMessage((ushort) objectItem.Cell.Id, (ushort) objectItem.Item.Id));
        }

        public static void SendObjectGroundRemovedMessage(IPacketReceiver client, WorldObjectItem objectItem)
        {
            client.Send(new ObjectGroundRemovedMessage((ushort) objectItem.Cell.Id));
        }

        public static void SendMapComplementaryInformationsBreachMessage(WorldClient client)
        {
            if (client.Character.breachOwner == null)
            {
                if (client.Character.breachBranches == null)
                    client.Character.breachBranches = BreachBranches.generateSongeBranches(client.Character);

                var breachBranches = new List<BreachBranch>();
                foreach (var breachBranch in client.Character.breachBranches)
                {
                    var branch = new BreachBranch(breachBranch.Room, breachBranch.Element, breachBranch.Bosses,
                        breachBranch.Map);
                    breachBranches.Add(branch);
                }

                client.Send(new BreachEnterMessage((ulong) client.Character.Id));
                client.Send(new BreachStateMessage(client.Character.GetCharacterMinimalInformations(),
                    client.Character.breachBoosts.ToArray(), (uint) client.Character.breachBudget, true));
                foreach (var character in client.Character.Map.GetAllCharacters())
                    client.Send(new BreachCharactersMessage(client.Character.Map.GetAllCharacters()
                        .Select(x => (ulong) x.Id)
                        .ToArray()));

                client.Send(new MapComplementaryInformationsBreachMessage((ushort) client.Character.Map.SubArea.Id,
                    client.Character.Map.Id, new HouseInformations[0],
                    client.Character.Map.Actors.Where(entry => entry.CanBeSee(client.Character)).Select(entry =>
                            entry.GetGameContextActorInformations(client.Character) as GameRolePlayActorInformations)
                        .ToArray(),
                    client.Character.Map.GetInteractiveObjects().Where(entry => entry.CanBeSee(client.Character))
                        .Select(
                            entry =>
                                entry.GetInteractiveElementWithBonus(client.Character)).ToArray(),
                    client.Character.Map.GetInteractiveObjects().Where(entry => entry.CanBeSee(client.Character))
                        .Where(x => x.Animated)
                        .Select(entry => entry.GetStatedElement()).ToArray(),
                    client.Character.Map.GetMapObstacles().ToArray(),
                    client.Character.Map.Fights.Where(entry => entry.BladesVisible)
                        .Select(entry => entry.GetFightCommonInformations()).ToArray(),
                    false,
                    new FightStartingPositions(client.Character.Map.GetBlueFightPlacement().Select(x => (ushort) x.Id),
                        client.Character.Map.GetRedFightPlacement().Select(x => (ushort) x.Id)),
                    (uint) (200 + client.Character.breachStep),
                    0,
                    breachBranches.ToArray()
                ));


                var cm = client.Character.Map.GetMapComplementaryInformationsDataMessage(client.Character);
                if (cm is MapComplementaryInformationsBreachMessage) client.Send(cm);
            }
            else
            {
                var breachBranches = new List<BreachBranch>();
                foreach (var breachBranch in client.Character.breachOwner.breachBranches)
                {
                    var branch = new BreachBranch(breachBranch.Room, breachBranch.Element, breachBranch.Bosses,
                        breachBranch.Map);
                    breachBranches.Add(branch);
                }

                client.Send(new BreachEnterMessage((ulong) client.Character.breachOwner.Id));
                client.Send(new BreachStateMessage(client.Character.breachOwner.GetCharacterMinimalInformations(),
                    client.Character.breachOwner.breachBoosts.ToArray(),
                    (uint) client.Character.breachOwner.breachBudget, true));
                foreach (var character in client.Character.Map.GetAllCharacters())
                    client.Send(new BreachCharactersMessage(client.Character.Map.GetAllCharacters()
                        .Select(x => (ulong) x.Id)
                        .ToArray()));

                client.Send(new MapComplementaryInformationsBreachMessage((ushort) client.Character.Map.SubArea.Id,
                    client.Character.Map.Id, new HouseInformations[0],
                    client.Character.Map.Actors.Where(entry => entry.CanBeSee(client.Character)).Select(entry =>
                            entry.GetGameContextActorInformations(client.Character) as GameRolePlayActorInformations)
                        .ToArray(),
                    client.Character.Map.GetInteractiveObjects().Where(entry => entry.CanBeSee(client.Character))
                        .Select(
                            entry =>
                                entry.GetInteractiveElementWithBonus(client.Character)).ToArray(),
                    client.Character.Map.GetInteractiveObjects().Where(entry => entry.CanBeSee(client.Character))
                        .Where(x => x.Animated)
                        .Select(entry => entry.GetStatedElement()).ToArray(),
                    client.Character.Map.GetMapObstacles().ToArray(),
                    client.Character.Map.Fights.Where(entry => entry.BladesVisible)
                        .Select(entry => entry.GetFightCommonInformations()).ToArray(),
                    false,
                    new FightStartingPositions(client.Character.Map.GetBlueFightPlacement().Select(x => (ushort) x.Id),
                        client.Character.Map.GetRedFightPlacement().Select(x => (ushort) x.Id)),
                    (uint) (200 + client.Character.breachOwner.breachStep),
                    0,
                    breachBranches.ToArray()
                ));


                var cm = client.Character.Map.GetMapComplementaryInformationsDataMessage(client.Character);
                if (cm is MapComplementaryInformationsBreachMessage) client.Send(cm);
            }
        }
    }
}