using Stump.Core.IO;

namespace D2pReader.MapInformations
{
    public class Fixture
    {
        public Fixture(BigEndianReader _reader)
        {
            FixtureId = _reader.ReadInt();
            OffsetX = _reader.ReadShort();
            OffsetY = _reader.ReadShort();
            Rotation = _reader.ReadShort();
            XScale = _reader.ReadShort();
            YScale = _reader.ReadShort();
            RedMultiplier = _reader.ReadSByte();
            GreenMultiplier = _reader.ReadSByte();
            BlueMultiplier = _reader.ReadSByte();
            Hue = RedMultiplier | GreenMultiplier | BlueMultiplier;
            Alpha = _reader.ReadByte();
        }

        #region Vars

        #endregion

        #region Properties

        public int FixtureId { get; }

        public int OffsetX { get; }

        public int OffsetY { get; }

        public int Rotation { get; }

        public int XScale { get; }

        public int YScale { get; }

        public int RedMultiplier { get; }

        public int GreenMultiplier { get; }

        public int BlueMultiplier { get; }

        public int Hue { get; }

        public uint Alpha { get; }

        #endregion
    }
}