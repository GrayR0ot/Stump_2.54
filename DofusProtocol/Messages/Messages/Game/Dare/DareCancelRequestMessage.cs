using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareCancelRequestMessage : Message
    {
        public const uint Id = 6680;

        public DareCancelRequestMessage(double dareId)
        {
            DareId = dareId;
        }

        public DareCancelRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public double DareId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
        }
    }
}