using System.Collections.Generic;
using Stump.Core.IO;

namespace D2pReader.MapInformations
{
    public class Layer
    {
        #region Vars

        private int ElementId;

        #endregion

        public Layer(BigEndianReader _reader, sbyte mapVersion, MapManager map)
        {
            if (mapVersion >= 9)
                LayerId = _reader.ReadSByte();
            else
                LayerId = _reader.ReadInt();
            //_layerId = _reader.ReadInt();
            CellsCount = _reader.ReadShort();

            Cells = new List<Cell>();
            var elements = new List<byte>();
            for (var i = 0; i < CellsCount; i++)
            {
                var cell = new Cell(_reader, mapVersion, map, elements);
                Cells.Add(cell);
                // elements = cell.ElementCompressed;
            }
            //map.m_compressedElements.AddRange(ZipHelper.Compress(elements.ToArray()));
        }

        #region Properties

        public int LayerId { get; }

        public int CellsCount { get; }

        public List<Cell> Cells { get; }

        #endregion
    }
}