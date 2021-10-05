using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Maps.Cells;

namespace Stump.Server.WorldServer.AI.Fights.Spells
{
    public class TargetCell
    {
        public TargetCell(Cell cell, DirectionFlagEnum direction = DirectionFlagEnum.ALL_DIRECTIONS)
        {
            Cell = cell;
            Direction = direction;
            Point = new MapPoint(cell);
        }

        public Cell Cell { get; }

        public MapPoint Point { get; }

        public DirectionFlagEnum Direction { get; set; }

        protected bool Equals(TargetCell other)
        {
            return Equals(Cell, other.Cell) && Direction == other.Direction;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Cell != null ? Cell.GetHashCode() : 0) * 397) ^ (int) Direction;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TargetCell) obj);
        }
    }
}