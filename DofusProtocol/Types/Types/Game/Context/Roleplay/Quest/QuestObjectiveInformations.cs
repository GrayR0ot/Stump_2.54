using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class QuestObjectiveInformations
    {
        public const short Id = 385;

        public QuestObjectiveInformations(ushort objectiveId, bool objectiveStatus, string[] dialogParams)
        {
            ObjectiveId = objectiveId;
            ObjectiveStatus = objectiveStatus;
            DialogParams = dialogParams;
        }

        public QuestObjectiveInformations()
        {
        }

        public virtual short TypeId => Id;

        public ushort ObjectiveId { get; set; }
        public bool ObjectiveStatus { get; set; }
        public string[] DialogParams { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(ObjectiveId);
            writer.WriteBoolean(ObjectiveStatus);
            writer.WriteShort((short) DialogParams.Count());
            for (var dialogParamsIndex = 0; dialogParamsIndex < DialogParams.Count(); dialogParamsIndex++)
                writer.WriteUTF(DialogParams[dialogParamsIndex]);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            ObjectiveId = reader.ReadVarUShort();
            ObjectiveStatus = reader.ReadBoolean();
            var dialogParamsCount = reader.ReadUShort();
            DialogParams = new string[dialogParamsCount];
            for (var dialogParamsIndex = 0; dialogParamsIndex < dialogParamsCount; dialogParamsIndex++)
                DialogParams[dialogParamsIndex] = reader.ReadUTF();
        }
    }
}