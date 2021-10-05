using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SequenceNumberMessage : Message
    {
        public const uint Id = 6317;

        public SequenceNumberMessage(ushort number)
        {
            Number = number;
        }

        public SequenceNumberMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort Number { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Number);
        }

        public override void Deserialize(IDataReader reader)
        {
            Number = reader.ReadUShort();
        }
    }
}