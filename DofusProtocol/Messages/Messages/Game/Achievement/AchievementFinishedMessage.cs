using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AchievementFinishedMessage : Message
    {
        public const uint Id = 6208;

        public AchievementFinishedMessage(AchievementAchievedRewardable achievement)
        {
            Achievement = achievement;
        }

        public AchievementFinishedMessage()
        {
        }

        public override uint MessageId => Id;

        public AchievementAchievedRewardable Achievement { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Achievement.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Achievement = new AchievementAchievedRewardable();
            Achievement.Deserialize(reader);
        }
    }
}