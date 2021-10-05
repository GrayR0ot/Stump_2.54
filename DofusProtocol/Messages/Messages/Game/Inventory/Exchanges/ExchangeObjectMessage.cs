using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeObjectMessage : Message
    {
        public const uint Id = 5515;

        public ExchangeObjectMessage(bool remote)
        {
            Remote = remote;
        }

        public ExchangeObjectMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Remote { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Remote);
        }

        public override void Deserialize(IDataReader reader)
        {
            Remote = reader.ReadBoolean();
        }
    }
}