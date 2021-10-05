using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AcquaintanceSearchErrorMessage : Message
    {
        public const uint Id = 6143;

        public AcquaintanceSearchErrorMessage(sbyte reason)
        {
            Reason = reason;
        }

        public AcquaintanceSearchErrorMessage()
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