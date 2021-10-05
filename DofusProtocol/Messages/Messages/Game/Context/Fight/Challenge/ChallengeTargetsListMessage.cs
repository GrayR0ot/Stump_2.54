using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ChallengeTargetsListMessage : Message
    {
        public const uint Id = 5613;

        public ChallengeTargetsListMessage(double[] targetIds, short[] targetCells)
        {
            TargetIds = targetIds;
            TargetCells = targetCells;
        }

        public ChallengeTargetsListMessage()
        {
        }

        public override uint MessageId => Id;

        public double[] TargetIds { get; set; }
        public short[] TargetCells { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) TargetIds.Count());
            for (var targetIdsIndex = 0; targetIdsIndex < TargetIds.Count(); targetIdsIndex++)
                writer.WriteDouble(TargetIds[targetIdsIndex]);
            writer.WriteShort((short) TargetCells.Count());
            for (var targetCellsIndex = 0; targetCellsIndex < TargetCells.Count(); targetCellsIndex++)
                writer.WriteShort(TargetCells[targetCellsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var targetIdsCount = reader.ReadUShort();
            TargetIds = new double[targetIdsCount];
            for (var targetIdsIndex = 0; targetIdsIndex < targetIdsCount; targetIdsIndex++)
                TargetIds[targetIdsIndex] = reader.ReadDouble();
            var targetCellsCount = reader.ReadUShort();
            TargetCells = new short[targetCellsCount];
            for (var targetCellsIndex = 0; targetCellsIndex < targetCellsCount; targetCellsIndex++)
                TargetCells[targetCellsIndex] = reader.ReadShort();
        }
    }
}