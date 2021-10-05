using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ChannelEnablingMessage : Message
    {
        public const uint Id = 890;

        public ChannelEnablingMessage(sbyte channel, bool enable)
        {
            Channel = channel;
            Enable = enable;
        }

        public ChannelEnablingMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Channel { get; set; }
        public bool Enable { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Channel);
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            Channel = reader.ReadSByte();
            Enable = reader.ReadBoolean();
        }
    }
}