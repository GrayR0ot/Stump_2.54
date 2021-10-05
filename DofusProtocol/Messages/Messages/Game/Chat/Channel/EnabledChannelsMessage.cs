using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class EnabledChannelsMessage : Message
    {
        public const uint Id = 892;

        public EnabledChannelsMessage(byte[] channels, byte[] disallowed)
        {
            Channels = channels;
            Disallowed = disallowed;
        }

        public EnabledChannelsMessage()
        {
        }

        public override uint MessageId => Id;

        public byte[] Channels { get; set; }
        public byte[] Disallowed { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Channels.Count());
            for (var channelsIndex = 0; channelsIndex < Channels.Count(); channelsIndex++)
                writer.WriteByte(Channels[channelsIndex]);
            writer.WriteShort((short) Disallowed.Count());
            for (var disallowedIndex = 0; disallowedIndex < Disallowed.Count(); disallowedIndex++)
                writer.WriteByte(Disallowed[disallowedIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var channelsCount = reader.ReadUShort();
            Channels = new byte[channelsCount];
            for (var channelsIndex = 0; channelsIndex < channelsCount; channelsIndex++)
                Channels[channelsIndex] = reader.ReadByte();
            var disallowedCount = reader.ReadUShort();
            Disallowed = new byte[disallowedCount];
            for (var disallowedIndex = 0; disallowedIndex < disallowedCount; disallowedIndex++)
                Disallowed[disallowedIndex] = reader.ReadByte();
        }
    }
}