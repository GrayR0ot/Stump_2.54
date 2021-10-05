using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AchievementRewardErrorMessage : Message
    {
        public const uint Id = 6375;

        public AchievementRewardErrorMessage(short achievementId)
        {
            AchievementId = achievementId;
        }

        public AchievementRewardErrorMessage()
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