using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeStoppedMessage : Message
    {
        public const uint Id = 6589;

        public ExchangeStoppedMessage(ulong objectId)
        {
            ObjectId = objectId;
        }

        public ExchangeStoppedMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarULong();
        }
    }
}