using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class WrapperObjectErrorMessage : SymbioticObjectErrorMessage
    {
        public new const uint Id = 6529;

        public WrapperObjectErrorMessage(sbyte reason, sbyte errorCode)
        {
            Reason = reason;
            ErrorCode = errorCode;
        }

        public WrapperObjectErrorMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}