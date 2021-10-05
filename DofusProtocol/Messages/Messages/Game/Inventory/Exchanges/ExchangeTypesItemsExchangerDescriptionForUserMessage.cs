using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeTypesItemsExchangerDescriptionForUserMessage : Message
    {
        public const uint Id = 5752;

        public ExchangeTypesItemsExchangerDescriptionForUserMessage(BidExchangerObjectInfo[] itemTypeDescriptions)
        {
            ItemTypeDescriptions = itemTypeDescriptions;
        }

        public ExchangeTypesItemsExchangerDescriptionForUserMessage()
        {
        }

        public override uint MessageId => Id;

        public BidExchangerObjectInfo[] ItemTypeDescriptions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ItemTypeDescriptions.Count());
            for (var itemTypeDescriptionsIndex = 0;
                itemTypeDescriptionsIndex < ItemTypeDescriptions.Count();
                itemTypeDescriptionsIndex++)
            {
                var objectToSend = ItemTypeDescriptions[itemTypeDescriptionsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var itemTypeDescriptionsCount = reader.ReadUShort();
            ItemTypeDescriptions = new BidExchangerObjectInfo[itemTypeDescriptionsCount];
            for (var itemTypeDescriptionsIndex = 0;
                itemTypeDescriptionsIndex < itemTypeDescriptionsCount;
                itemTypeDescriptionsIndex++)
            {
                var objectToAdd = new BidExchangerObjectInfo();
                objectToAdd.Deserialize(reader);
                ItemTypeDescriptions[itemTypeDescriptionsIndex] = objectToAdd;
            }
        }
    }
}