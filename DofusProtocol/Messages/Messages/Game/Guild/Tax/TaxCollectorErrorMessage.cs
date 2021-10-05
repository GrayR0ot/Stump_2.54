using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TaxCollectorErrorMessage : Message
    {
        public const uint Id = 5634;

        public TaxCollectorErrorMessage(sbyte reason)
        {
            Reason = reason;
        }

        public TaxCollectorErrorMessage()
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