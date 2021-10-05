using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ChatClientMultiMessage : ChatAbstractClientMessage
    {
        public new const uint Id = 861;

        public ChatClientMultiMessage(string content, sbyte channel)
        {
            Content = content;
            Channel = channel;
        }

        public ChatClientMultiMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Channel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Channel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Channel = reader.ReadSByte();
        }
    }
}