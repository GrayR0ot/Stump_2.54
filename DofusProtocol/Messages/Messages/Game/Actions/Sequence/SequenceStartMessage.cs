using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SequenceStartMessage : Message
    {
        public const uint Id = 955;

        public SequenceStartMessage(sbyte sequenceType, double authorId)
        {
            SequenceType = sequenceType;
            AuthorId = authorId;
        }

        public SequenceStartMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte SequenceType { get; set; }
        public double AuthorId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(SequenceType);
            writer.WriteDouble(AuthorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SequenceType = reader.ReadSByte();
            AuthorId = reader.ReadDouble();
        }
    }
}