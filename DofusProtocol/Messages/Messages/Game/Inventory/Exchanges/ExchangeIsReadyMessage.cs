using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeIsReadyMessage : Message
    {
        public const uint Id = 5509;

        public ExchangeIsReadyMessage(double objectId, bool ready)
        {
            ObjectId = objectId;
            Ready = ready;
        }

        public ExchangeIsReadyMessage()
        {
        }

        public override uint MessageId => Id;

        public double ObjectId { get; set; }
        public bool Ready { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ObjectId);
            writer.WriteBoolean(Ready);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadDouble();
            Ready = reader.ReadBoolean();
        }
    }
}