using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeCraftResultMagicWithObjectDescMessage : ExchangeCraftResultWithObjectDescMessage
    {
        public new const uint Id = 6188;

        public ExchangeCraftResultMagicWithObjectDescMessage(sbyte craftResult, ObjectItemNotInContainer objectInfo,
            sbyte magicPoolStatus)
        {
            CraftResult = craftResult;
            ObjectInfo = objectInfo;
            MagicPoolStatus = magicPoolStatus;
        }

        public ExchangeCraftResultMagicWithObjectDescMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte MagicPoolStatus { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(MagicPoolStatus);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MagicPoolStatus = reader.ReadSByte();
        }
    }
}