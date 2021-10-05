using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AchievementDetailsRequestMessage : Message
    {
        public const uint Id = 6380;

        public AchievementDetailsRequestMessage(ushort achievementId)
        {
            AchievementId = achievementId;
        }

        public AchievementDetailsRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort AchievementId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(AchievementId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AchievementId = reader.ReadVarUShort();
        }
    }
}