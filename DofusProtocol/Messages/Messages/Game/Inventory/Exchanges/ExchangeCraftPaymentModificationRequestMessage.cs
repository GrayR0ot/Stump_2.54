using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeCraftPaymentModificationRequestMessage : Message
    {
        public const uint Id = 6579;

        public ExchangeCraftPaymentModificationRequestMessage(ulong quantity)
        {
            Quantity = quantity;
        }

        public ExchangeCraftPaymentModificationRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong Quantity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            Quantity = reader.ReadVarULong();
        }
    }
}