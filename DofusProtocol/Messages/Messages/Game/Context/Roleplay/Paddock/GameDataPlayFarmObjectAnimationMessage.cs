using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameDataPlayFarmObjectAnimationMessage : Message
    {
        public const uint Id = 6026;

        public GameDataPlayFarmObjectAnimationMessage(ushort[] cellId)
        {
            CellId = cellId;
        }

        public GameDataPlayFarmObjectAnimationMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort[] CellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) CellId.Count());
            for (var cellIdIndex = 0; cellIdIndex < CellId.Count(); cellIdIndex++)
                writer.WriteVarUShort(CellId[cellIdIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var cellIdCount = reader.ReadUShort();
            CellId = new ushort[cellIdCount];
            for (var cellIdIndex = 0; cellIdIndex < cellIdCount; cellIdIndex++)
                CellId[cellIdIndex] = reader.ReadVarUShort();
        }
    }
}