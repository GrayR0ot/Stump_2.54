using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ChatClientPrivateMessage : ChatAbstractClientMessage
    {
        public new const uint Id = 851;

        public ChatClientPrivateMessage(string content, string receiver)
        {
            Content = content;
            Receiver = receiver;
        }

        public ChatClientPrivateMessage()
        {
        }

        public override uint MessageId => Id;

        public string Receiver { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Receiver);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Receiver = reader.ReadUTF();
        }
    }
}