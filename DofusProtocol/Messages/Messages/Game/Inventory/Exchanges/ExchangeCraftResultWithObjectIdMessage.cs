using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeCraftResultWithObjectIdMessage : ExchangeCraftResultMessage
    {
        public new const uint Id = 6000;

        public ExchangeCraftResultWithObjectIdMessage(sbyte craftResult, ushort objectGenericId)
        {
            CraftResult = craftResult;
            ObjectGenericId = objectGenericId;
        }

        public ExchangeCraftResultWithObjectIdMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort ObjectGenericId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(ObjectGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectGenericId = reader.ReadVarUShort();
        }
    }
}