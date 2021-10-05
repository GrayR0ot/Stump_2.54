using System;
using System.Collections.Generic;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;

namespace Stump.Server.WorldServer.Game.Maps.Cells.Shapes
{
    public class Lozenge : IShape
    {
        public Lozenge(byte minRadius, byte radius)
        {
            MinRadius = minRadius;
            Radius = radius;
        }

        #region IShape Members

        public uint Surface => ((uint) Radius + 1) * ((uint) Radius + 1) + Radius * (uint) Radius;

        public byte MinRadius { get; set; }

        public DirectionsEnum Direction { get; set; }

        public byte Radius { get; set; }

        public Cell[] GetCells(Cell centerCell, Map map)
        {
            var centerPoint = new MapPoint(centerCell);
            var result = new List<Cell>();

            if (Radius == 0)
            {
                if (MinRadius == 0)
                    result.Add(centerCell);

                return result.ToArray();
            }

            var x = centerPoint.X - Radius;
            var y = 0;
            var i = 0;
            var j = 1;
            while (x <= centerPoint.X + Radius)
            {
                y = -i;

                while (y <= i)
                {
                    if (MinRadius == 0 || Math.Abs(centerPoint.X - x) + Math.Abs(y) >= MinRadius)
                        AddCellIfValid(x, y + centerPoint.Y, map, result);

                    y++;
                }

                if (i == Radius) j = -j;

                i = i + j;
                x++;
            }

            return result.ToArray();
        }

        private static void AddCellIfValid(int x, int y, Map map, IList<Cell> container)
        {
            if (!MapPoint.IsInMap(x, y))
                return;

            container.Add(map.Cells[MapPoint.CoordToCellId(x, y)]);
        }

        #endregion
    }
}