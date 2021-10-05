using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareRewardConsumeRequestMessage : Message
    {
        public const uint Id = 6676;

        public DareRewardConsumeRequestMessage(double dareId, sbyte type)
        {
            DareId = dareId;
            Type = type;
        }

        public DareRewardConsumeRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public double DareId { get; set; }
        public sbyte Type { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
            writer.WriteSByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
            Type = reader.ReadSByte();
        }
    }
}