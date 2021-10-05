using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeWaitingResultMessage : Message
    {
        public const uint Id = 5786;

        public ExchangeWaitingResultMessage(bool bwait)
        {
            Bwait = bwait;
        }

        public ExchangeWaitingResultMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Bwait { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Bwait);
        }

        public override void Deserialize(IDataReader reader)
        {
            Bwait = reader.ReadBoolean();
        }
    }
}