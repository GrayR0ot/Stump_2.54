using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeBidHousePriceMessage : Message
    {
        public const uint Id = 5805;

        public ExchangeBidHousePriceMessage(ushort genId)
        {
            GenId = genId;
        }

        public ExchangeBidHousePriceMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort GenId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(GenId);
        }

        public override void Deserialize(IDataReader reader)
        {
            GenId = reader.ReadVarUShort();
        }
    }
}