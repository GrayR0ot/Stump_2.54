using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ChatAbstractClientMessage : Message
    {
        public const uint Id = 850;

        public ChatAbstractClientMessage(string content)
        {
            Content = content;
        }

        public ChatAbstractClientMessage()
        {
        }

        public override uint MessageId => Id;

        public string Content { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Content);
        }

        public override void Deserialize(IDataReader reader)
        {
            Content = reader.ReadUTF();
        }
    }
}