using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeRequestMessage : Message
    {
        public const uint Id = 5505;

        public ExchangeRequestMessage(sbyte exchangeType)
        {
            ExchangeType = exchangeType;
        }

        public ExchangeRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte ExchangeType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ExchangeType);
        }

        public override void Deserialize(IDataReader reader)
        {
            ExchangeType = reader.ReadSByte();
        }
    }
}