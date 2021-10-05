using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareWonMessage : Message
    {
        public const uint Id = 6681;

        public DareWonMessage(double dareId)
        {
            DareId = dareId;
        }

        public DareWonMessage()
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