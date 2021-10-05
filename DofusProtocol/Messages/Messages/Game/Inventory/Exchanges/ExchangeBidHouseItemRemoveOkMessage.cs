using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeBidHouseItemRemoveOkMessage : Message
    {
        public const uint Id = 5946;

        public ExchangeBidHouseItemRemoveOkMessage(int sellerId)
        {
            SellerId = sellerId;
        }

        public ExchangeBidHouseItemRemoveOkMessage()
        {
        }

        public override uint MessageId => Id;

        public int SellerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SellerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SellerId = reader.ReadInt();
        }
    }
}