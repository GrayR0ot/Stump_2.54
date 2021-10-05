using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareInformationsRequestMessage : Message
    {
        public const uint Id = 6659;

        public DareInformationsRequestMessage(double dareId)
        {
            DareId = dareId;
        }

        public DareInformationsRequestMessage()
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