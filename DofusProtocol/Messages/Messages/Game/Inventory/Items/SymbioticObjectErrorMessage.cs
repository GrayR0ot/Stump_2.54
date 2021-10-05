using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SymbioticObjectErrorMessage : ObjectErrorMessage
    {
        public new const uint Id = 6526;

        public SymbioticObjectErrorMessage(sbyte reason, sbyte errorCode)
        {
            Reason = reason;
            ErrorCode = errorCode;
        }

        public SymbioticObjectErrorMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte ErrorCode { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(ErrorCode);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ErrorCode = reader.ReadSByte();
        }
    }
}