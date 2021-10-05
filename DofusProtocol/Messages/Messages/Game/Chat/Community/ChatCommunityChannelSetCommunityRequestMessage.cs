using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ChatCommunityChannelSetCommunityRequestMessage : Message
    {
        public const uint Id = 6729;

        public ChatCommunityChannelSetCommunityRequestMessage(short communityId)
        {
            CommunityId = communityId;
        }

        public ChatCommunityChannelSetCommunityRequestMessage()
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