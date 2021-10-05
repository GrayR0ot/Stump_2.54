using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class WarnOnPermaDeathStateMessage : Message
    {
        public const uint Id = 6513;

        public WarnOnPermaDeathStateMessage(bool enable)
        {
            Enable = enable;
        }

        public WarnOnPermaDeathStateMessage()
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