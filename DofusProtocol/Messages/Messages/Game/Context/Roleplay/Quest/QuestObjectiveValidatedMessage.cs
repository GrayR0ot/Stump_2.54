using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class QuestObjectiveValidatedMessage : Message
    {
        public const uint Id = 6098;

        public QuestObjectiveValidatedMessage(ushort questId, ushort objectiveId)
        {
            QuestId = questId;
            ObjectiveId = objectiveId;
        }

        public QuestObjectiveValidatedMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort QuestId { get; set; }
        public ushort ObjectiveId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(QuestId);
            writer.WriteVarUShort(ObjectiveId);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestId = reader.ReadVarUShort();
            ObjectiveId = reader.ReadVarUShort();
        }
    }
}