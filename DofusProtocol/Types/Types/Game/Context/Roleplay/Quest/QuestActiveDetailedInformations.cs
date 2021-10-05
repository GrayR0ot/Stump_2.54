using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class QuestActiveDetailedInformations : QuestActiveInformations
    {
        public new const short Id = 382;

        public QuestActiveDetailedInformations(ushort questId, ushort stepId, QuestObjectiveInformations[] objectives)
        {
            QuestId = questId;
            StepId = stepId;
            Objectives = objectives;
        }

        public QuestActiveDetailedInformations()
        {
        }

        public override short TypeId => Id;

        public ushort StepId { get; set; }
        public QuestObjectiveInformations[] Objectives { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(StepId);
            writer.WriteShort((short) Objectives.Count());
            for (var objectivesIndex = 0; objectivesIndex < Objectives.Count(); objectivesIndex++)
            {
                var objectToSend = Objectives[objectivesIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            StepId = reader.ReadVarUShort();
            var objectivesCount = reader.ReadUShort();
            Objectives = new QuestObjectiveInformations[objectivesCount];
            for (var objectivesIndex = 0; objectivesIndex < objectivesCount; objectivesIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<QuestObjectiveInformations>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Objectives[objectivesIndex] = objectToAdd;
            }
        }
    }
}