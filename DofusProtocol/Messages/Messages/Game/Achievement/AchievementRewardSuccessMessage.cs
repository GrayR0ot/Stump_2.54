using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AchievementRewardSuccessMessage : Message
    {
        public const uint Id = 6376;

        public AchievementRewardSuccessMessage(short achievementId)
        {
            AchievementId = achievementId;
        }

        public AchievementRewardSuccessMessage()
        {
        }

        public override uint MessageId => Id;

        public short AchievementId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(AchievementId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AchievementId = reader.ReadShort();
        }
    }
}