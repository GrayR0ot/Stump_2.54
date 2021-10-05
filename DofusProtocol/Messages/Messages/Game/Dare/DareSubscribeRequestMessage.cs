using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareSubscribeRequestMessage : Message
    {
        public const uint Id = 6666;

        public DareSubscribeRequestMessage(double dareId, bool subscribe)
        {
            DareId = dareId;
            Subscribe = subscribe;
        }

        public DareSubscribeRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public double DareId { get; set; }
        public bool Subscribe { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
            writer.WriteBoolean(Subscribe);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
            Subscribe = reader.ReadBoolean();
        }
    }
}