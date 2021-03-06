using System.Collections.Generic;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Maps.Cells.Shapes.Set
{
    public class Union : Set
    {
        public Union(Set A, Set B)
        {
            this.A = A;
            this.B = B;
        }

        public Set A { get; }

        public Set B { get; }

        public override IEnumerable<MapPoint> EnumerateSet()
        {
            return A.EnumerateSet().Union(B.EnumerateSet());
        }

        public override bool BelongToSet(MapPoint point)
        {
            return A.BelongToSet(point) || B.BelongToSet(point);
        }
    }
}