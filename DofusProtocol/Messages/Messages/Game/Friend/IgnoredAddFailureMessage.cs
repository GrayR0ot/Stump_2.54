using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class IgnoredAddFailureMessage : Message
    {
        public const uint Id = 5679;

        public IgnoredAddFailureMessage(sbyte reason)
        {
            Reason = reason;
        }

        public IgnoredAddFailureMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadSByte();
        }
    }
}