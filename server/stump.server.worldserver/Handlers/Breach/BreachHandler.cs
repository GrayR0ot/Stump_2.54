using System.Collections.Generic;
using System.Linq;
using Stump.Core.Extensions;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Messages;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Core.Network;
using Stump.Server.WorldServer.Game;
using Stump.Server.WorldServer.Game.Maps.Cells;
using Stump.Server.WorldServer.Game.Songes;

namespace Stump.Server.WorldServer.Handlers.Breach
{
    public class BreachHandler : WorldHandlerContainer
    {
        private static int LastMap;
        private static short LastCell;
        private static DirectionsEnum LastDirection;

        private BreachHandler()
        {
        }

        [WorldHandler(BreachInvitationAnswerMessage.Id)]
        public static void HandleBreachInvitationAnswerMessage(WorldClient client,
            BreachInvitationAnswerMessage message)
        {
            if (client.Character.songesGroupInvitation != null)
                if (message.Accept)
                {
                    client.Character.songesOwner = client.Character.songesGroupInvitation.Host;
                    client.Character.songesGroupInvitation = null;
                    if (client.Character.songesOwner.songesGroup == null)
                        client.Character.songesOwner.songesGroup = new long[] {client.Character.Id};
                    else
                        client.Character.songesOwner.songesGroup.Add(client.Character.Id);

                    client.Send(
                        new BreachInvitationCloseMessage(client.Character.songesOwner
                            .GetCharacterMinimalInformations()));
                    client.Character.songesOwner.Client.Send(
                        new BreachInvitationResponseMessage(client.Character.GetCharacterMinimalInformations(), true));
                    client.Character.Teleport(client.Character.songesOwner.Position);
                }
        }

        [WorldHandler(BreachInvitationRequestMessage.Id)]
        public static void HandleBreachInvitationRequestMessage(WorldClient client,
            BreachInvitationRequestMessage message)
        {
            if (client.Character.songesGroup == null || client.Character.songesGroup.Length <= 3)
            {
                var target = World.Instance.GetCharacter((int) message.Guest);
                var breachInvitationOfferMessage =
                    new BreachInvitationOfferMessage(client.Character.GetCharacterMinimalInformations(), 60);
                if (target != client.Character)
                {
                    target.songesGroupInvitation = new SongesGroupInvitation(client.Character,
                        breachInvitationOfferMessage);
                    target.Client.Send(breachInvitationOfferMessage);
                }
            }
        }

        [WorldHandler(BreachRewardBuyMessage.Id)]
        public static void HandleBreachRewardBuyMessage(WorldClient client,
            BreachRewardBuyMessage message)
        {
            if (client.Character.songesBuyables != null)
                for (var index = 0; index < client.Character.songesBuyables.Length; index++)
                {
                    var buyable = client.Character.songesBuyables[index];
                    if (buyable.ObjectId == message.ObjectId)
                    {
                        if (client.Character.songesBudget >= buyable.Price)
                        {
                            client.Send(new BreachRewardBoughtMessage(message.ObjectId, true));
                            var buyables = new List<BreachReward>(client.Character.songesBuyables);
                            buyables.RemoveAt(index);
                            client.Character.songesBuyables = buyables.ToArray();
                            switch (buyable.ObjectId)
                            {
                                //MINOR INTELLIGENCY
                                case 6:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(126, 10));
                                    client.Character.songesBudget -= 300;
                                    break;
                                //MINOR LUCK
                                case 7:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(123, 10));
                                    client.Character.songesBudget -= 300;
                                    break;
                                //MINOR AGILITY
                                case 91:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(119, 10));
                                    client.Character.songesBudget -= 300;
                                    break;
                                //MINOR STRENGTH
                                case 92:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(118, 10));
                                    client.Character.songesBudget -= 300;
                                    break;
                                //MINOR VITALITY
                                case 93:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(125, 25));
                                    client.Character.songesBudget -= 300;
                                    break;
                                //MINOR POWER
                                case 94:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(138, 10));
                                    client.Character.songesBudget -= 300;
                                    break;
                                //MINOR AP ATTACK
                                case 95:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(410, 1));
                                    client.Character.songesBudget -= 300;
                                    break;
                                //MINOR AM ATTACK
                                case 96:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(412, 1));
                                    client.Character.songesBudget -= 300;
                                    break;
                                //MINOR TACKLE LEAK
                                case 99:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(752, 1));
                                    client.Character.songesBudget -= 300;
                                    break;
                                //MINOR TACKLE BLOCK
                                case 100:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(753, 1));
                                    client.Character.songesBudget -= 300;
                                    break;
                                ///MEDIUM INTELLIGENCY
                                case 103:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(126, 25));
                                    client.Character.songesBudget -= 600;
                                    break;
                                ///MEDIUM LUCK
                                case 104:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(123, 25));
                                    client.Character.songesBudget -= 600;
                                    break;
                                ///MEDIUM AGILITY
                                case 105:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(119, 25));
                                    client.Character.songesBudget -= 600;
                                    break;
                                ///MEDIUM STRENGTH
                                case 106:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(118, 25));
                                    client.Character.songesBudget -= 600;
                                    break;
                                ///MEDIUM VITALITY
                                case 107:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(125, 50));
                                    client.Character.songesBudget -= 600;
                                    break;
                                ///MEDIUM POWER
                                case 108:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(138, 20));
                                    client.Character.songesBudget -= 600;
                                    break;
                                ///MEDIUM AP ATTACK
                                case 109:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(410, 2));
                                    client.Character.songesBudget -= 600;
                                    break;
                                ///MEDIUM AM ATTACK
                                case 110:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(412, 2));
                                    client.Character.songesBudget -= 600;
                                    break;
                                ///MEDIUM TACKLE LEAK
                                case 113:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(752, 2));
                                    client.Character.songesBudget -= 600;
                                    break;
                                ///MEDIUM TACKLE BLOCK
                                case 114:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(753, 2));
                                    client.Character.songesBudget -= 600;
                                    break;

                                ///MAJOR INTELLIGENCY
                                case 117:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(126, 50));
                                    client.Character.songesBudget -= 900;
                                    break;
                                ///MAJOR LUCK
                                case 118:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(123, 50));
                                    client.Character.songesBudget -= 900;
                                    break;
                                ///MAJOR AGILITY
                                case 119:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(119, 50));
                                    client.Character.songesBudget -= 900;
                                    break;
                                ///MAJOR STRENGTH
                                case 120:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(118, 50));
                                    client.Character.songesBudget -= 900;
                                    break;
                                ///MAJOR VITALITY
                                case 121:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(125, 100));
                                    client.Character.songesBudget -= 900;
                                    break;
                                ///MAJOR POWER
                                case 122:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(138, 40));
                                    client.Character.songesBudget -= 900;
                                    break;
                                ///MAJOR AP ATTACK
                                case 123:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(410, 4));
                                    client.Character.songesBudget -= 900;
                                    break;
                                ///MAJOR AM ATTACK
                                case 124:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(412, 4));
                                    client.Character.songesBudget -= 900;
                                    break;
                                ///MAJOR TACKLE LEAK
                                case 127:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(752, 4));
                                    client.Character.songesBudget -= 900;
                                    break;
                                ///MAJOR TACKLE BLOCK
                                case 128:
                                    client.Character.songesBoosts =
                                        client.Character.songesBoosts.Add(new ObjectEffectInteger(753, 4));
                                    client.Character.songesBudget -= 900;
                                    break;
                            }

                            client.Send(new BreachStateMessage(client.Character.GetCharacterMinimalInformations(),
                                client.Character.songesBoosts.ToArray(), (uint) client.Character.songesBudget, true));
                        }
                        else
                        {
                            client.Send(new BreachRewardBoughtMessage(message.ObjectId, false));
                        }

                        break;
                    }
                }
        }

        [WorldHandler(BreachTeleportRequestMessage.Id)]
        public static void HandleBreachTeleportRequestMessage(WorldClient client,
            BreachTeleportRequestMessage message)
        {
            if (LastMap != 0 && LastCell != 0 && LastDirection != 0)
            {
                client.Character.Teleport(new ObjectPosition(Singleton<World>.Instance.GetMap(LastMap), LastCell,
                    LastDirection));
                LastMap = 0;
                LastCell = 0;
                LastDirection = 0;
            }
            else
            {
                LastMap = client.Character.Map.Id;
                LastCell = client.Character.Cell.Id;
                LastDirection = client.Character.Direction;
                client.Character.Teleport(new ObjectPosition(Singleton<World>.Instance.GetMap(195559424), 382,
                    DirectionsEnum.DIRECTION_NORTH));
            }
        }

        [WorldHandler(BreachExitRequestMessage.Id)]
        public static void HandleBreachExitRequestMessage(WorldClient client,
            BreachExitRequestMessage message)
        {
            {
                client.Character.Teleport(new ObjectPosition(Singleton<World>.Instance.GetMap(195559424), 382,
                    DirectionsEnum.DIRECTION_NORTH));
                client.Character.songesGroup = null;
                client.Character.SendServerMessage("En quittant les songes, le groupe  a été dissout.");
            }
        }
    }
}