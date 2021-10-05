using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class WarnOnPermaDeathMessage : Message
    {
        public const uint Id = 6512;

        public WarnOnPermaDeathMessage(bool enable)
        {
            Enable = enable;
        }

        public WarnOnPermaDeathMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Enable { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            Enable = reader.ReadBoolean();
        }
    }
}