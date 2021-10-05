using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ChatSmileyRequestMessage : Message
    {
        public const uint Id = 800;

        public ChatSmileyRequestMessage(ushort smileyId)
        {
            SmileyId = smileyId;
        }

        public ChatSmileyRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort SmileyId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(SmileyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SmileyId = reader.ReadVarUShort();
        }
    }
}