using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;

namespace Stump.Server.WorldServer.Game.Maps.Cells.Shapes
{
    public class Single : IShape
    {
        public uint Surface => 1;

        public byte MinRadius
        {
            get => 1;
            set { }
        }

        public DirectionsEnum Direction
        {
            get => DirectionsEnum.DIRECTION_NORTH;
            set { }
        }

        public byte Radius
        {
            get => 1;
            set { }
        }

        public Cell[] GetCells(Cell centerCell, Map map)
        {
            return new[] {centerCell};
        }
    }
}