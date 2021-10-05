using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ChatSmileyExtraPackListMessage : Message
    {
        public const uint Id = 6596;

        public ChatSmileyExtraPackListMessage(byte[] packIds)
        {
            PackIds = packIds;
        }

        public ChatSmileyExtraPackListMessage()
        {
        }

        public override uint MessageId => Id;

        public byte[] PackIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) PackIds.Count());
            for (var packIdsIndex = 0; packIdsIndex < PackIds.Count(); packIdsIndex++)
                writer.WriteByte(PackIds[packIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var packIdsCount = reader.ReadUShort();
            PackIds = new byte[packIdsCount];
            for (var packIdsIndex = 0; packIdsIndex < packIdsCount; packIdsIndex++)
                PackIds[packIdsIndex] = reader.ReadByte();
        }
    }
}