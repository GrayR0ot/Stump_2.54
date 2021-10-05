using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeStartOkRecycleTradeMessage : Message
    {
        public const uint Id = 6600;

        public ExchangeStartOkRecycleTradeMessage(short percentToPrism, short percentToPlayer)
        {
            PercentToPrism = percentToPrism;
            PercentToPlayer = percentToPlayer;
        }

        public ExchangeStartOkRecycleTradeMessage()
        {
        }

        public override uint MessageId => Id;

        public short PercentToPrism { get; set; }
        public short PercentToPlayer { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(PercentToPrism);
            writer.WriteShort(PercentToPlayer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PercentToPrism = reader.ReadShort();
            PercentToPlayer = reader.ReadShort();
        }
    }
}