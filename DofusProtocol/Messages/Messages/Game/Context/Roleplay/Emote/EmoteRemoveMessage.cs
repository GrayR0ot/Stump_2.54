using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class EmoteRemoveMessage : Message
    {
        public const uint Id = 5687;

        public EmoteRemoveMessage(byte emoteId)
        {
            EmoteId = emoteId;
        }

        public EmoteRemoveMessage()
        {
        }

        public override uint MessageId => Id;

        public byte EmoteId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(EmoteId);
        }

        public override void Deserialize(IDataReader reader)
        {
            EmoteId = reader.ReadByte();
        }
    }
}