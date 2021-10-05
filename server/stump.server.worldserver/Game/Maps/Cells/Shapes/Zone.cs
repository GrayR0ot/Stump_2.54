using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;

namespace Stump.Server.WorldServer.Game.Maps.Cells.Shapes
{
    public class Zone : IShape
    {
        public const int EFFECTSHAPE_DEFAULT_EFFICIENCY = 10;
        public const int EFFECTSHAPE_DEFAULT_MAX_EFFICIENCY_APPLY = 4;

        private SpellShapeEnum m_shapeType;

        public Zone(SpellShapeEnum shape, byte radius)
        {
            Radius = radius;
            ShapeType = shape;
        }

        public Zone(SpellShapeEnum shape, byte radius, byte minRadius)
        {
            Radius = radius;
            MinRadius = minRadius;
            ShapeType = shape;
        }

        public Zone(SpellShapeEnum shape, byte radius, byte minRadius, DirectionsEnum direction, int efficiencyMalus,
            int maxEfficiency)
        {
            Radius = radius;
            MinRadius = minRadius;
            Direction = direction;
            ShapeType = shape;
            EfficiencyMalus = efficiencyMalus > 0 ? efficiencyMalus : EFFECTSHAPE_DEFAULT_EFFICIENCY;
            MaxEfficiency = maxEfficiency > 0 ? maxEfficiency : EFFECTSHAPE_DEFAULT_MAX_EFFICIENCY_APPLY;
        }

        public SpellShapeEnum ShapeType
        {
            get => m_shapeType;
            set
            {
                m_shapeType = value;
                InitializeShape();
            }
        }

        public IShape Shape { get; private set; }

        private void InitializeShape()
        {
            switch (ShapeType)
            {
                case SpellShapeEnum.X:
                    Shape = new Cross(MinRadius, Radius);
                    break;
                case SpellShapeEnum.L:
                    Shape = new Line(Radius, false);
                    break;
                case SpellShapeEnum.l:
                    Shape = new Line(Radius, true);
                    break;
                case SpellShapeEnum.T:
                    Shape = new Cross(0, Radius)
                    {
                        OnlyPerpendicular = true
                    };
                    break;
                case SpellShapeEnum.D:
                    Shape = new Cross(0, Radius);
                    break;
                case SpellShapeEnum.C:
                    Shape = new Lozenge(MinRadius, Radius);
                    break;
                case SpellShapeEnum.I:
                    Shape = new Lozenge(Radius, 63);
                    break;
                case SpellShapeEnum.O:
                    Shape = new Lozenge(Radius, Radius);
                    break;
                case SpellShapeEnum.Q:
                    Shape = new Cross(MinRadius > 0 ? MinRadius : (byte) 1, Radius);
                    break;
                case SpellShapeEnum.G:
                    Shape = new Square(0, Radius);
                    break;
                case SpellShapeEnum.V:
                    Shape = new Cone(0, Radius);
                    break;
                case SpellShapeEnum.W:
                    Shape = new Square(0, Radius)
                    {
                        DiagonalFree = true
                    };
                    break;
                case SpellShapeEnum.plus:
                    Shape = new Cross(0, Radius)
                    {
                        Diagonal = true
                    };
                    break;
                case SpellShapeEnum.sharp:
                    Shape = new Cross(MinRadius > 0 ? MinRadius : (byte) 1, Radius)
                    {
                        Diagonal = true
                    };
                    break;
                case SpellShapeEnum.star:
                    Shape = new Cross(0, Radius)
                    {
                        AllDirections = true
                    };
                    break;
                case SpellShapeEnum.slash:
                    Shape = new Line(Radius, false);
                    break;
                case SpellShapeEnum.U:
                    Shape = new HalfLozenge(0, Radius);
                    break;
                case SpellShapeEnum.A:
                case SpellShapeEnum.a:
                    Shape = new Lozenge(0, 63);
                    break;
                case SpellShapeEnum.P:
                    Shape = new Single();
                    break;
                case SpellShapeEnum.minus:
                    Shape = new Cross(0, Radius)
                    {
                        Diagonal = true,
                        OnlyPerpendicular = true
                    };
                    break;
                default:
                    Shape = new Cross(MinRadius, Radius);
                    break;
            }

            Shape.Direction = Direction;
        }

        #region IShape Members

        public uint Surface => Shape.Surface;

        public byte MinRadius
        {
            get => m_minRadius;
            set
            {
                m_minRadius = value;

                if (Shape != null)
                    Shape.MinRadius = value;
            }
        }

        public int EfficiencyMalus { get; set; }

        public int MaxEfficiency { get; set; }

        public DirectionsEnum Direction
        {
            get => m_direction;
            set
            {
                m_direction = value;
                if (Shape != null)
                    Shape.Direction = value;
            }
        }

        private byte m_radius;
        private DirectionsEnum m_direction;
        private byte m_minRadius;

        public byte Radius
        {
            get => m_radius;
            set
            {
                m_radius = value;
                if (Shape != null)
                    Shape.Radius = value;
            }
        }

        public Cell[] GetCells(Cell centerCell, Map map)
        {
            return Shape.GetCells(centerCell, map);
        }

        #endregion
    }
}