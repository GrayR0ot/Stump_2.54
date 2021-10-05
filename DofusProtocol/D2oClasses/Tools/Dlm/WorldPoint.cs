namespace D2pReader.MapInformations
{
    public class WorldPoint
    {
        public WorldPoint(uint mapId)
        {
            MapId = mapId;
            WorldId = (MapId & 1073479680) >> 18;

            X = (int) ((MapId >> 9) & 511);
            Y = (int) (MapId & 511);

            if ((X & 256) == 256)
                X = -(X & 255);

            if ((Y & 256) == 256)
                Y = -(Y & 255);
        }

        #region Vars

        #endregion

        #region Properties

        public uint MapId { get; }

        public uint WorldId { get; }

        public int X { get; }

        public int Y { get; }

        #endregion
    }
}