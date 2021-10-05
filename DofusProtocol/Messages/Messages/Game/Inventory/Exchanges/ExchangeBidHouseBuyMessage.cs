using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeBidHouseBuyMessage : Message
    {
        public const uint Id = 5804;

        public ExchangeBidHouseBuyMessage(uint uid, uint qty, ulong price)
        {
            Uid = uid;
            Qty = qty;
            Price = price;
        }

        public ExchangeBidHouseBuyMessage()
        {
        }

        public override uint MessageId => Id;

        public uint Uid { get; set; }
        public uint Qty { get; set; }
        public ulong Price { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(Uid);
            writer.WriteVarUInt(Qty);
            writer.WriteVarULong(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
            Uid = reader.ReadVarUInt();
            Qty = reader.ReadVarUInt();
            Price = reader.ReadVarULong();
        }
    }
}