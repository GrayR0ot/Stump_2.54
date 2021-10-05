using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeBidHouseItemAddOkMessage : Message
    {
        public const uint Id = 5945;

        public ExchangeBidHouseItemAddOkMessage(ObjectItemToSellInBid itemInfo)
        {
            ItemInfo = itemInfo;
        }

        public ExchangeBidHouseItemAddOkMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItemToSellInBid ItemInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            ItemInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ItemInfo = new ObjectItemToSellInBid();
            ItemInfo.Deserialize(reader);
        }
    }
}