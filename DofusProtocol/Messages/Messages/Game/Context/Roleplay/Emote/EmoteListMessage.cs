using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class EmoteListMessage : Message
    {
        public const uint Id = 5689;

        public EmoteListMessage(byte[] emoteIds)
        {
            EmoteIds = emoteIds;
        }

        public EmoteListMessage()
        {
        }

        public override uint MessageId => Id;

        public byte[] EmoteIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) EmoteIds.Count());
            for (var emoteIdsIndex = 0; emoteIdsIndex < EmoteIds.Count(); emoteIdsIndex++)
                writer.WriteByte(EmoteIds[emoteIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var emoteIdsCount = reader.ReadUShort();
            EmoteIds = new byte[emoteIdsCount];
            for (var emoteIdsIndex = 0; emoteIdsIndex < emoteIdsCount; emoteIdsIndex++)
                EmoteIds[emoteIdsIndex] = reader.ReadByte();
        }
    }
}