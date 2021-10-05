using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class FriendGuildWarnOnAchievementCompleteStateMessage : Message
    {
        public const uint Id = 6383;

        public FriendGuildWarnOnAchievementCompleteStateMessage(bool enable)
        {
            Enable = enable;
        }

        public FriendGuildWarnOnAchievementCompleteStateMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Enable { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            Enable = reader.ReadBoolean();
        }
    }
}