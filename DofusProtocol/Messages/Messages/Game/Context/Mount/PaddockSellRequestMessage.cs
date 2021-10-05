using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PaddockSellRequestMessage : Message
    {
        public const uint Id = 5953;

        public PaddockSellRequestMessage(ulong price, bool forSale)
        {
            Price = price;
            ForSale = forSale;
        }

        public PaddockSellRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong Price { get; set; }
        public bool ForSale { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(Price);
            writer.WriteBoolean(ForSale);
        }

        public override void Deserialize(IDataReader reader)
        {
            Price = reader.ReadVarULong();
            ForSale = reader.ReadBoolean();
        }
    }
}