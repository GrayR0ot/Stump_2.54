using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Types;
using Item = Stump.Server.WorldServer.Game.Items.Item;

namespace Stump.Server.WorldServer.Game.Exchanges.Trades
{
    public abstract class TradeItem : Item
    {
        public abstract CharacterInventoryPositionEnum Position { get; }

        public override ObjectItem GetObjectItem()
        {
            return new ObjectItem(
                (sbyte) Position,
                (ushort) Template.Id,
                Effects.Select(entry => entry.GetObjectEffect()).ToArray(),
                (uint) Guid,
                Stack);
        }
    }
}