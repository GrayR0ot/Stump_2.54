using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class NotificationListMessage : Message
    {
        public const uint Id = 6087;

        public NotificationListMessage(int[] flags)
        {
            Flags = flags;
        }

        public NotificationListMessage()
        {
        }

        public override uint MessageId => Id;

        public int[] Flags { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Flags.Count());
            for (var flagsIndex = 0; flagsIndex < Flags.Count(); flagsIndex++) writer.WriteVarInt(Flags[flagsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flagsCount = reader.ReadUShort();
            Flags = new int[flagsCount];
            for (var flagsIndex = 0; flagsIndex < flagsCount; flagsIndex++) Flags[flagsIndex] = reader.ReadVarInt();
        }
    }
}