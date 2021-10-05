using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AchievementListMessage : Message
    {
        public const uint Id = 6205;

        public AchievementListMessage(AchievementAchieved[] finishedAchievements)
        {
            FinishedAchievements = finishedAchievements;
        }

        public AchievementListMessage()
        {
        }

        public override uint MessageId => Id;

        public AchievementAchieved[] FinishedAchievements { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) FinishedAchievements.Count());
            for (var finishedAchievementsIndex = 0;
                finishedAchievementsIndex < FinishedAchievements.Count();
                finishedAchievementsIndex++)
            {
                var objectToSend = FinishedAchievements[finishedAchievementsIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var finishedAchievementsCount = reader.ReadUShort();
            FinishedAchievements = new AchievementAchieved[finishedAchievementsCount];
            for (var finishedAchievementsIndex = 0;
                finishedAchievementsIndex < finishedAchievementsCount;
                finishedAchievementsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<AchievementAchieved>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                FinishedAchievements[finishedAchievementsIndex] = objectToAdd;
            }
        }
    }
}