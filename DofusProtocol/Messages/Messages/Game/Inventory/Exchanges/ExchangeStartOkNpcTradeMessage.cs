using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeStartOkNpcTradeMessage : Message
    {
        public const uint Id = 5785;

        public ExchangeStartOkNpcTradeMessage(double npcId)
        {
            NpcId = npcId;
        }

        public ExchangeStartOkNpcTradeMessage()
        {
        }

        public override uint MessageId => Id;

        public double NpcId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(NpcId);
        }

        public override void Deserialize(IDataReader reader)
        {
            NpcId = reader.ReadDouble();
        }
    }
}