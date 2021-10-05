using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeCraftResultWithObjectDescMessage : ExchangeCraftResultMessage
    {
        public new const uint Id = 5999;

        public ExchangeCraftResultWithObjectDescMessage(sbyte craftResult, ObjectItemNotInContainer objectInfo)
        {
            CraftResult = craftResult;
            ObjectInfo = objectInfo;
        }

        public ExchangeCraftResultWithObjectDescMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItemNotInContainer ObjectInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            ObjectInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectInfo = new ObjectItemNotInContainer();
            ObjectInfo.Deserialize(reader);
        }
    }
}