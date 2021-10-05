using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ChatCommunityChannelCommunityMessage : Message
    {
        public const uint Id = 6730;

        public ChatCommunityChannelCommunityMessage(short communityId)
        {
            CommunityId = communityId;
        }

        public ChatCommunityChannelCommunityMessage()
        {
        }

        public override uint MessageId => Id;

        public short CommunityId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(CommunityId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CommunityId = reader.ReadShort();
        }
    }
}