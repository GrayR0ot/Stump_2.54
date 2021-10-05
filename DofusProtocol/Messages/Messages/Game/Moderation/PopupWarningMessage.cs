using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PopupWarningMessage : Message
    {
        public const uint Id = 6134;

        public PopupWarningMessage(byte lockDuration, string author, string content)
        {
            LockDuration = lockDuration;
            Author = author;
            Content = content;
        }

        public PopupWarningMessage()
        {
        }

        public override uint MessageId => Id;

        public byte LockDuration { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(LockDuration);
            writer.WriteUTF(Author);
            writer.WriteUTF(Content);
        }

        public override void Deserialize(IDataReader reader)
        {
            LockDuration = reader.ReadByte();
            Author = reader.ReadUTF();
            Content = reader.ReadUTF();
        }
    }
}