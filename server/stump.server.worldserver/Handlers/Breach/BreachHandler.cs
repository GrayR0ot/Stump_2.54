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
            if (client.Character.breachGroupInvitation != null)
                if (message.Accept)
                {
                    client.Character.breachOwner = client.Character.breachGroupInvitation.Host;
                    client.Character.breachGroupInvitation = null;
                    if (client.Character.breachOwner.breachGroup == null)
                        client.Character.breachOwner.breachGroup = new long[] {client.Character.Id};
                    else
                        client.Character.breachOwner.breachGroup = client.Character.breachOwner.breachGroup.Add(client.Character.Id);

                    client.Send(
                        new BreachInvitationCloseMessage(client.Character.breachOwner
                            .GetCharacterMinimalInformations()));
                    client.Character.breachOwner.Client.Send(
                        new BreachInvitationResponseMessage(client.Character.GetCharacterMinimalInformations(), true));
                    client.Character.Teleport(client.Character.breachOwner.Position);
                }
        }

        [WorldHandler(BreachInvitationRequestMessage.Id)]
        public static void HandleBreachInvitationRequestMessage(WorldClient client,
            BreachInvitationRequestMessage message)
        {
            if (client.Character.breachGroup == null || client.Character.breachGroup.Length <= 3)
            {
                var target = World.Instance.GetCharacter((int) message.Guest);
                var breachInvitationOfferMessage =
                    new BreachInvitationOfferMessage(client.Character.GetCharacterMinimalInformations(), 60);
                if (target != client.Character)
                {
                    target.breachGroupInvitation = new BreachGroupInvitation(client.Character,
                        breachInvitationOfferMessage);
                    target.Client.Send(breachInvitationOfferMessage);
                }
            }
        }

        [WorldHandler(BreachRewardBuyMessage.Id)]
        public static void HandleBreachRewardBuyMessage(WorldClient client,
            BreachRewardBuyMessage message)
        {
            if (client.Character.breachBuyables != null)
                for (var index = 0; index < client.Character.breachBuyables.Length; index++)
                {
                    var buyable = client.Character.breachBuyables[index];
                    if (buyable.ObjectId == message.ObjectId)
                    {
                        if (client.Character.breachBudget >= buyable.Price)
                        {
                            client.Send(new BreachRewardBoughtMessage(message.ObjectId, true));
                            var buyables = new List<BreachReward>(client.Character.breachBuyables);
                            buyables.RemoveAt(index);
                            client.Character.breachBuyables = buyables.ToArray();
                            switch (buyable.ObjectId)
                            {
                                //MINOR INTELLIGENCY
                                case 6:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(126, 10));
                                    client.Character.breachBudget -= 300;
                                    break;
                                //MINOR LUCK
                                case 7:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(123, 10));
                                    client.Character.breachBudget -= 300;
                                    break;
                                //MINOR AGILITY
                                case 91:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(119, 10));
                                    client.Character.breachBudget -= 300;
                                    break;
                                //MINOR STRENGTH
                                case 92:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(118, 10));
                                    client.Character.breachBudget -= 300;
                                    break;
                                //MINOR VITALITY
                                case 93:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(125, 25));
                                    client.Character.breachBudget -= 300;
                                    break;
                                //MINOR POWER
                                case 94:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(138, 10));
                                    client.Character.breachBudget -= 300;
                                    break;
                                //MINOR AP ATTACK
                                case 95:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(410, 1));
                                    client.Character.breachBudget -= 300;
                                    break;
                                //MINOR AM ATTACK
                                case 96:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(412, 1));
                                    client.Character.breachBudget -= 300;
                                    break;
                                //MINOR TACKLE LEAK
                                case 99:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(752, 1));
                                    client.Character.breachBudget -= 300;
                                    break;
                                //MINOR TACKLE BLOCK
                                case 100:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(753, 1));
                                    client.Character.breachBudget -= 300;
                                    break;
                                ///MEDIUM INTELLIGENCY
                                case 103:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(126, 25));
                                    client.Character.breachBudget -= 600;
                                    break;
                                ///MEDIUM LUCK
                                case 104:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(123, 25));
                                    client.Character.breachBudget -= 600;
                                    break;
                                ///MEDIUM AGILITY
                                case 105:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(119, 25));
                                    client.Character.breachBudget -= 600;
                                    break;
                                ///MEDIUM STRENGTH
                                case 106:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(118, 25));
                                    client.Character.breachBudget -= 600;
                                    break;
                                ///MEDIUM VITALITY
                                case 107:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(125, 50));
                                    client.Character.breachBudget -= 600;
                                    break;
                                ///MEDIUM POWER
                                case 108:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(138, 20));
                                    client.Character.breachBudget -= 600;
                                    break;
                                ///MEDIUM AP ATTACK
                                case 109:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(410, 2));
                                    client.Character.breachBudget -= 600;
                                    break;
                                ///MEDIUM AM ATTACK
                                case 110:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(412, 2));
                                    client.Character.breachBudget -= 600;
                                    break;
                                ///MEDIUM TACKLE LEAK
                                case 113:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(752, 2));
                                    client.Character.breachBudget -= 600;
                                    break;
                                ///MEDIUM TACKLE BLOCK
                                case 114:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(753, 2));
                                    client.Character.breachBudget -= 600;
                                    break;

                                ///MAJOR INTELLIGENCY
                                case 117:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(126, 50));
                                    client.Character.breachBudget -= 900;
                                    break;
                                ///MAJOR LUCK
                                case 118:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(123, 50));
                                    client.Character.breachBudget -= 900;
                                    break;
                                ///MAJOR AGILITY
                                case 119:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(119, 50));
                                    client.Character.breachBudget -= 900;
                                    break;
                                ///MAJOR STRENGTH
                                case 120:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(118, 50));
                                    client.Character.breachBudget -= 900;
                                    break;
                                ///MAJOR VITALITY
                                case 121:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(125, 100));
                                    client.Character.breachBudget -= 900;
                                    break;
                                ///MAJOR POWER
                                case 122:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(138, 40));
                                    client.Character.breachBudget -= 900;
                                    break;
                                ///MAJOR AP ATTACK
                                case 123:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(410, 4));
                                    client.Character.breachBudget -= 900;
                                    break;
                                ///MAJOR AM ATTACK
                                case 124:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(412, 4));
                                    client.Character.breachBudget -= 900;
                                    break;
                                ///MAJOR TACKLE LEAK
                                case 127:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(752, 4));
                                    client.Character.breachBudget -= 900;
                                    break;
                                ///MAJOR TACKLE BLOCK
                                case 128:
                                    client.Character.breachBoosts =
                                        client.Character.breachBoosts.Add(new ObjectEffectInteger(753, 4));
                                    client.Character.breachBudget -= 900;
                                    break;
                            }

                            client.Send(new BreachStateMessage(client.Character.GetCharacterMinimalInformations(),
                                client.Character.breachBoosts.ToArray(), (uint) client.Character.breachBudget, true));
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
                client.Character.breachGroup = null;
                client.Character.SendServerMessage("En quittant les breach, le groupe  a été dissout.");
            }
        }
    }
}