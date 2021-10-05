using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class Achievement
    {
        public const short Id = 363;

        public Achievement(ushort objectId, AchievementObjective[] finishedObjective,
            AchievementStartedObjective[] startedObjectives)
        {
            ObjectId = objectId;
            FinishedObjective = finishedObjective;
            StartedObjectives = startedObjectives;
        }

        public Achievement()
        {
        }

        public virtual short TypeId => Id;

        public ushort ObjectId { get; set; }
        public AchievementObjective[] FinishedObjective { get; set; }
        public AchievementStartedObjective[] StartedObjectives { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(ObjectId);
            writer.WriteShort((short) FinishedObjective.Count());
            for (var finishedObjectiveIndex = 0;
                finishedObjectiveIndex < FinishedObjective.Count();
                finishedObjectiveIndex++)
            {
                var objectToSend = FinishedObjective[finishedObjectiveIndex];
                objectToSend.Serialize(writer);
            }

            writer.WriteShort((short) StartedObjectives.Count());
            for (var startedObjectivesIndex = 0;
                startedObjectivesIndex < StartedObjectives.Count();
                startedObjectivesIndex++)
            {
                var objectToSend = StartedObjectives[startedObjectivesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public virtual void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUShort();
            var finishedObjectiveCount = reader.ReadUShort();
            FinishedObjective = new AchievementObjective[finishedObjectiveCount];
            for (var finishedObjectiveIndex = 0;
                finishedObjectiveIndex < finishedObjectiveCount;
                finishedObjectiveIndex++)
            {
                var objectToAdd = new AchievementObjective();
                objectToAdd.Deserialize(reader);
                FinishedObjective[finishedObjectiveIndex] = objectToAdd;
            }

            var startedObjectivesCount = reader.ReadUShort();
            StartedObjectives = new AchievementStartedObjective[startedObjectivesCount];
            for (var startedObjectivesIndex = 0;
                startedObjectivesIndex < startedObjectivesCount;
                startedObjectivesIndex++)
            {
                var objectToAdd = new AchievementStartedObjective();
                objectToAdd.Deserialize(reader);
                StartedObjectives[startedObjectivesIndex] = objectToAdd;
            }
        }
    }
}