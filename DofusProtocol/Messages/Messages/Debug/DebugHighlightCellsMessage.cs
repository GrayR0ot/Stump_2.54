using System;
using System.Collections.Generic;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DebugHighlightCellsMessage : Message
    {
        public const uint Id = 2001;
        public IEnumerable<ushort> cells;
        public double color;

        public DebugHighlightCellsMessage(double color, IEnumerable<ushort> cells)
        {
            this.color = color;
            this.cells = cells;
        }

        public DebugHighlightCellsMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(color);
            writer.WriteShort((short) cells.Count());
            foreach (var objectToSend in cells) writer.WriteVarUShort(objectToSend);
        }

        public override void Deserialize(IDataReader reader)
        {
            color = reader.ReadDouble();
            var cellsCount = reader.ReadUShort();
            var cells_ = new ushort[cellsCount];
            for (var cellsIndex = 0; cellsIndex < cellsCount; cellsIndex++) cells_[cellsIndex] = reader.ReadVarUShort();
            cells = cells_;
        }
    }
}