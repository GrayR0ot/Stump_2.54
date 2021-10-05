using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectGroundRemovedMultipleMessage : Message
    {
        public const uint Id = 5944;

        public ObjectGroundRemovedMultipleMessage(ushort[] cells)
        {
            Cells = cells;
        }

        public ObjectGroundRemovedMultipleMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort[] Cells { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Cells.Count());
            for (var cellsIndex = 0; cellsIndex < Cells.Count(); cellsIndex++) writer.WriteVarUShort(Cells[cellsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var cellsCount = reader.ReadUShort();
            Cells = new ushort[cellsCount];
            for (var cellsIndex = 0; cellsIndex < cellsCount; cellsIndex++) Cells[cellsIndex] = reader.ReadVarUShort();
        }
    }
}