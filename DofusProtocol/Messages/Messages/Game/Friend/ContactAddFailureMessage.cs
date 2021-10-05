using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ContactAddFailureMessage : Message
    {
        public const uint Id = 6821;

        public ContactAddFailureMessage(sbyte reason)
        {
            Reason = reason;
        }

        public ContactAddFailureMessage()
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