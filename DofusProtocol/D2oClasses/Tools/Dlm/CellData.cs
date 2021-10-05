using Stump.Core.IO;

namespace D2pReader.MapInformations
{
    public class CellData
    {
        #region Vars

        private readonly int _linkedZone;

        #endregion

        public CellData(BigEndianReader _reader, sbyte mapVersion, int id)
        {
            var tmpbytesv9 = 0;
            var topArrow = false;
            var bottomArrow = false;
            var rightArrow = false;
            var leftArrow = false;
            var tmpBits = 0;
            Floor = _reader.ReadSByte() * 10;
            Id = id;

            if (Floor == -1280) return;
            if (mapVersion >= 9)
            {
                Losmov = tmpbytesv9 = _reader.ReadShort();
                Mov = (tmpbytesv9 & 1) == 0;
                NonWalkableDuringFight = (tmpbytesv9 & 2) != 0;
                NonWalkableDuringRP = (tmpbytesv9 & 4) != 0;
                Los = (tmpbytesv9 & 8) == 0;
                Blue = (tmpbytesv9 & 16) != 0;
                Red = (tmpbytesv9 & 32) != 0;
                Visible = (tmpbytesv9 & 64) != 0;
                FarmCell = (tmpbytesv9 & 128) != 0;
                if (mapVersion >= 10)
                {
                    HavenBagCell = (tmpbytesv9 & 256) != 0;
                    topArrow = (tmpbytesv9 & 512) != 0;
                    bottomArrow = (tmpbytesv9 & 1024) != 0;
                    rightArrow = (tmpbytesv9 & 2048) != 0;
                    leftArrow = (tmpbytesv9 & 4096) != 0;
                }
                else
                {
                    topArrow = (tmpbytesv9 & 256) != 0;
                    bottomArrow = (tmpbytesv9 & 512) != 0;
                    rightArrow = (tmpbytesv9 & 1024) != 0;
                    leftArrow = (tmpbytesv9 & 2048) != 0;
                }
            }
            else
            {
                Losmov = _reader.ReadByte();
                Los = (Losmov & 2) >> 1 == 1;
                Mov = (Losmov & 1) == 1;
                Visible = (Losmov & 64) >> 6 == 1;
                FarmCell = (Losmov & 32) >> 5 == 1;
                Blue = (Losmov & 16) >> 4 == 1;
                Red = (Losmov & 8) >> 3 == 1;
                NonWalkableDuringRP = (Losmov & 128) >> 7 == 1;
                NonWalkableDuringFight = (Losmov & 4) >> 2 == 1;
            }

            Speed = _reader.ReadSByte();
            MapChangeData = (uint) _reader.ReadSByte();
            if (mapVersion > 5) MoveZone = _reader.ReadByte();
            if (mapVersion > 10 && (HasLinkedZoneRP() || HasLinkedZoneFight())) _linkedZone = _reader.ReadByte();
            if (mapVersion > 7 && mapVersion < 9)
            {
                tmpBits = _reader.ReadByte();
                Arrow = 15 & tmpBits;
            }
        }

        public byte[] Serialize()
        {
            return new[]
            {
                (byte) (Id >> 8),
                (byte) (Id & 255),
                (byte) (Floor >> 8),
                (byte) (Floor & 255),
                (byte) Losmov,
                (byte) MapChangeData,
                (byte) Speed,
                (byte) (MoveZone >> 24),
                (byte) (MoveZone >> 16),
                (byte) (MoveZone >> 8),
                (byte) (MoveZone & 255u)
            };
        }

        #region Properties

        public int Id { get; }

        public int Speed { get; }

        public uint MapChangeData { get; }

        public uint MoveZone { get; }

        public int Losmov { get; }

        public int Floor { get; }

        public int Arrow { get; }


        public bool Los { get; }

        public bool Mov { get; }

        public bool Visible { get; }

        public bool FarmCell { get; }

        public bool Blue { get; }

        public bool Red { get; }

        public bool NonWalkableDuringRP { get; }

        public bool NonWalkableDuringFight { get; }

        public bool HavenBagCell { get; }

        public bool HasLinkedZoneRP()
        {
            return Mov && !FarmCell;
        }

        public int LinkedZoneRP()
        {
            return (_linkedZone & 240) >> 4;
        }

        public bool HasLinkedZoneFight()
        {
            return Mov && !NonWalkableDuringFight && !FarmCell && !HavenBagCell;
        }

        public int LinkedZoneFight()
        {
            return _linkedZone & 15;
        }

        #endregion
    }
}