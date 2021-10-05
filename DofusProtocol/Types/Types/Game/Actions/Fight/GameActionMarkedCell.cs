using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameActionMarkedCell
    {
        public const short Id = 85;

        public GameActionMarkedCell(ushort cellId, sbyte zoneSize, int cellColor, sbyte cellsType)
        {
            CellId = cellId;
            ZoneSize = zoneSize;
            CellColor = cellColor;
            CellsType = cellsType;
        }

        public GameActionMarkedCell()
        {
        }

        public virtual short TypeId => Id;

        public ushort CellId { get; set; }
        public sbyte ZoneSize { get; set; }
        public int CellColor { get; set; }
        public sbyte CellsType { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(CellId);
            writer.WriteSByte(ZoneSize);
            writer.WriteInt(CellColor);
            writer.WriteSByte(CellsType);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUShort();
            ZoneSize = reader.ReadSByte();
            CellColor = reader.ReadInt();
            CellsType = reader.ReadSByte();
        }
    }
}