using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildMotdSetRequestMessage : SocialNoticeSetRequestMessage
    {
        public new const uint Id = 6588;

        public GuildMotdSetRequestMessage(string content)
        {
            Content = content;
        }

        public GuildMotdSetRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public string Content { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Content);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Content = reader.ReadUTF();
        }
    }
}