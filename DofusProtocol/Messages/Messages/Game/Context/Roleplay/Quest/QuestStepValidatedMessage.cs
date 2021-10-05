using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class QuestStepValidatedMessage : Message
    {
        public const uint Id = 6099;

        public QuestStepValidatedMessage(ushort questId, ushort stepId)
        {
            QuestId = questId;
            StepId = stepId;
        }

        public QuestStepValidatedMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort QuestId { get; set; }
        public ushort StepId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(QuestId);
            writer.WriteVarUShort(StepId);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestId = reader.ReadVarUShort();
            StepId = reader.ReadVarUShort();
        }
    }
}