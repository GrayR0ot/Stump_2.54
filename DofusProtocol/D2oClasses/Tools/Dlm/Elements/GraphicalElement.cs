using Stump.Core.IO;

namespace D2pReader.MapInformations.Elements
{
    public class GraphicalElement : BasicElement
    {
        public GraphicalElement(BigEndianReader _reader, sbyte mapVersion)
        {
            ElementId = _reader.ReadUInt();
            Hue1 = _reader.ReadSByte();
            Hue2 = _reader.ReadSByte();
            Hue3 = _reader.ReadSByte();
            Shadow1 = _reader.ReadSByte();
            Shadow2 = _reader.ReadSByte();
            Shadow3 = _reader.ReadSByte();

            if (mapVersion <= 4)
            {
                OffsetX = _reader.ReadSByte();
                OffsetY = _reader.ReadSByte();

                PixelOffsetX = (int) (OffsetX * CELL_HALF_WIDTH);
                PixelOffsetY = (int) (OffsetY * CELL_HALF_HEIGHT);
            }

            else
            {
                PixelOffsetX = _reader.ReadShort();
                PixelOffsetY = _reader.ReadShort();

                OffsetX = (int) (PixelOffsetX / CELL_HALF_WIDTH);
                OffsetY = (int) (PixelOffsetY / CELL_HALF_HEIGHT);
            }

            Altitude = _reader.ReadSByte();
            Identifier = _reader.ReadUInt();
        }

        #region Vars

        public const uint CELL_HALF_WIDTH = 43;
        public const float CELL_HALF_HEIGHT = 21.5F;

        #endregion

        #region Properties

        public uint ElementId { get; }

        public int Hue1 { get; }

        public int Hue2 { get; }

        public int Hue3 { get; }

        public int Shadow1 { get; }

        public int Shadow2 { get; }

        public int Shadow3 { get; }

        public int OffsetX { get; }

        public int OffsetY { get; }

        public int PixelOffsetX { get; }

        public int PixelOffsetY { get; }

        public int Altitude { get; }

        public uint Identifier { get; }

        #endregion
    }
}