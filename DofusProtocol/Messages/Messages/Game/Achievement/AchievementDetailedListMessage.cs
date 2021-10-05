using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AchievementDetailedListMessage : Message
    {
        public const uint Id = 6358;

        public AchievementDetailedListMessage(Achievement[] startedAchievements, Achievement[] finishedAchievements)
        {
            StartedAchievements = startedAchievements;
            FinishedAchievements = finishedAchievements;
        }

        public AchievementDetailedListMessage()
        {
        }

        public override uint MessageId => Id;

        public Achievement[] StartedAchievements { get; set; }
        public Achievement[] FinishedAchievements { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) StartedAchievements.Count());
            for (var startedAchievementsIndex = 0;
                startedAchievementsIndex < StartedAchievements.Count();
                startedAchievementsIndex++)
            {
                var objectToSend = StartedAchievements[startedAchievementsIndex];
                objectToSend.Serialize(writer);
            }

            writer.WriteShort((short) FinishedAchievements.Count());
            for (var finishedAchievementsIndex = 0;
                finishedAchievementsIndex < FinishedAchievements.Count();
                finishedAchievementsIndex++)
            {
                var objectToSend = FinishedAchievements[finishedAchievementsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var startedAchievementsCount = reader.ReadUShort();
            StartedAchievements = new Achievement[startedAchievementsCount];
            for (var startedAchievementsIndex = 0;
                startedAchievementsIndex < startedAchievementsCount;
                startedAchievementsIndex++)
            {
                var objectToAdd = new Achievement();
                objectToAdd.Deserialize(reader);
                StartedAchievements[startedAchievementsIndex] = objectToAdd;
            }

            var finishedAchievementsCount = reader.ReadUShort();
            FinishedAchievements = new Achievement[finishedAchievementsCount];
            for (var finishedAchievementsIndex = 0;
                finishedAchievementsIndex < finishedAchievementsCount;
                finishedAchievementsIndex++)
            {
                var objectToAdd = new Achievement();
                objectToAdd.Deserialize(reader);
                FinishedAchievements[finishedAchievementsIndex] = objectToAdd;
            }
        }
    }
}