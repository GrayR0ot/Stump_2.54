using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class JobAllowMultiCraftRequestMessage : Message
    {
        public const uint Id = 5748;

        public JobAllowMultiCraftRequestMessage(bool enabled)
        {
            Enabled = enabled;
        }

        public JobAllowMultiCraftRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Enabled { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Enabled);
        }

        public override void Deserialize(IDataReader reader)
        {
            Enabled = reader.ReadBoolean();
        }
    }
}