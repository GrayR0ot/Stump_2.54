using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeBidHouseUnsoldItemsMessage : Message
    {
        public const uint Id = 6612;

        public ExchangeBidHouseUnsoldItemsMessage(ObjectItemGenericQuantity[] items)
        {
            Items = items;
        }

        public ExchangeBidHouseUnsoldItemsMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItemGenericQuantity[] Items { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Items.Count());
            for (var itemsIndex = 0; itemsIndex < Items.Count(); itemsIndex++)
            {
                var objectToSend = Items[itemsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var itemsCount = reader.ReadUShort();
            Items = new ObjectItemGenericQuantity[itemsCount];
            for (var itemsIndex = 0; itemsIndex < itemsCount; itemsIndex++)
            {
                var objectToAdd = new ObjectItemGenericQuantity();
                objectToAdd.Deserialize(reader);
                Items[itemsIndex] = objectToAdd;
            }
        }
    }
}