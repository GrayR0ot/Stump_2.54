using System.Collections.Generic;
using D2pReader.MapInformations.Elements;
using Stump.Core.IO;

namespace D2pReader.MapInformations
{
    public class Cell
    {
        #region Vars

        private readonly int _elementsCount;

        #endregion

        public Cell(BigEndianReader _reader, sbyte mapVersion, MapManager map, List<byte> elements)
        {
            CellId = _reader.ReadShort();
            _elementsCount = _reader.ReadShort();
            Elements = new List<BasicElement>();
            ElementCompressed = elements;

            for (var i = 0; i < _elementsCount; i++)
            {
                var elementType = _reader.ReadSByte();
                var element = BasicElement.GetElementFromType(elementType, _reader, mapVersion);
                //_elements.Add(BasicElement.GetElementFromType(elementType, _reader, mapVersion));
                Elements.Add(element);
                if (BasicElement.ElementId != 0)
                    ElementsCount++;
                //this.m_compressedElements.AddRange(element.Serialize(_cellId, (int)BasicElement.ElementId));
                //System.Array.Copy(element.Serialize(_cellId, (int)BasicElement.ElementId), 0, m_compressedElements, counter * 6, 6);
            }
        }

        #region Properties

        public int CellId { get; }

        public int ElementsCount { get; }

        public List<BasicElement> Elements { get; }

        public List<byte> ElementCompressed { get; }

        #endregion
    }
}