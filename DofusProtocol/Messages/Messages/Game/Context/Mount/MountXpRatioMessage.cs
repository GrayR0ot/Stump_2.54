using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MountXpRatioMessage : Message
    {
        public const uint Id = 5970;

        public MountXpRatioMessage(sbyte ratio)
        {
            Ratio = ratio;
        }

        public MountXpRatioMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Ratio { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Ratio);
        }

        public override void Deserialize(IDataReader reader)
        {
            Ratio = reader.ReadSByte();
        }
    }
}