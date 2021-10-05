using System.Linq;
using Stump.DofusProtocol.Messages;
using Stump.Server.BaseServer.Network;
using Stump.Server.WorldServer.Core.Network;

namespace Stump.Server.WorldServer.Handlers.Inventory
{
    public partial class InventoryHandler
    {
        public static void SendSpellListMessage(WorldClient client, bool previsualization)
        {
            client.Send(new SpellListMessage(previsualization,
                client.Character.Spells.GetSpells().Select(
                    entry => entry.GetSpellItem())));
        }

        public static void SendGameRolePlayPlayerLifeStatusMessage(IPacketReceiver client, sbyte state, int phxMap)
        {
            client.Send(new GameRolePlayPlayerLifeStatusMessage(state, phxMap));
        }
    }
}