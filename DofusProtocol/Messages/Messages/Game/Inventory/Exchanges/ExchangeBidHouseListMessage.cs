using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeBidHouseListMessage : Message
    {
        public const uint Id = 5807;

        public ExchangeBidHouseListMessage(ushort objectId)
        {
            ObjectId = objectId;
        }

        public ExchangeBidHouseListMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUShort();
        }
    }
}