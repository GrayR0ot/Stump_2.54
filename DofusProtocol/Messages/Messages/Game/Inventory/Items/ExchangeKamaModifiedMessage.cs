using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeKamaModifiedMessage : ExchangeObjectMessage
    {
        public new const uint Id = 5521;

        public ExchangeKamaModifiedMessage(bool remote, ulong quantity)
        {
            Remote = remote;
            Quantity = quantity;
        }

        public ExchangeKamaModifiedMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong Quantity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarULong(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Quantity = reader.ReadVarULong();
        }
    }
}