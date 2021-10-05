using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeBidPriceForSellerMessage : ExchangeBidPriceMessage
    {
        public new const uint Id = 6464;

        public ExchangeBidPriceForSellerMessage(ushort genericId, long averagePrice, bool allIdentical,
            ulong[] minimalPrices)
        {
            GenericId = genericId;
            AveragePrice = averagePrice;
            AllIdentical = allIdentical;
            MinimalPrices = minimalPrices;
        }

        public ExchangeBidPriceForSellerMessage()
        {
        }

        public override uint MessageId => Id;

        public bool AllIdentical { get; set; }
        public ulong[] MinimalPrices { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(AllIdentical);
            writer.WriteShort((short) MinimalPrices.Count());
            for (var minimalPricesIndex = 0; minimalPricesIndex < MinimalPrices.Count(); minimalPricesIndex++)
                writer.WriteVarULong(MinimalPrices[minimalPricesIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllIdentical = reader.ReadBoolean();
            var minimalPricesCount = reader.ReadUShort();
            MinimalPrices = new ulong[minimalPricesCount];
            for (var minimalPricesIndex = 0; minimalPricesIndex < minimalPricesCount; minimalPricesIndex++)
                MinimalPrices[minimalPricesIndex] = reader.ReadVarULong();
        }
    }
}