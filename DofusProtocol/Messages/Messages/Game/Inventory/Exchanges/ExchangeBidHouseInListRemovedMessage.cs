using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeBidHouseInListRemovedMessage : Message
    {
        public const uint Id = 5950;

        public ExchangeBidHouseInListRemovedMessage(int itemUID)
        {
            ItemUID = itemUID;
        }

        public ExchangeBidHouseInListRemovedMessage()
        {
        }

        public override uint MessageId => Id;

        public int ItemUID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ItemUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            ItemUID = reader.ReadInt();
        }
    }
}