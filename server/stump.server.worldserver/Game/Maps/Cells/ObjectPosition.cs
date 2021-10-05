using System;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;

namespace Stump.Server.WorldServer.Game.Maps.Cells
{
    /// <summary>
    ///     Represents the position of an object relative to the global world
    /// </summary>
    public class ObjectPosition
    {
        private Cell m_cell;

        private DirectionsEnum m_direction;

        private Map m_map;

        private MapPoint m_point;

        public ObjectPosition(ObjectPosition position)
        {
            m_map = position.Map;
            m_cell = position.Cell;
            m_direction = position.Direction;
        }

        public ObjectPosition(Map map, Cell cell)
        {
            m_map = map;
            m_cell = cell;
            m_direction = DirectionsEnum.DIRECTION_EAST;
        }

        public ObjectPosition(Map map, short cellId)
        {
            m_map = map;
            m_cell = map.Cells[cellId];
            m_direction = DirectionsEnum.DIRECTION_EAST;
        }

        public ObjectPosition(Map map, Cell cell, DirectionsEnum direction)
        {
            m_map = map;
            m_cell = cell;
            m_direction = direction;
        }

        public ObjectPosition(Map map, short cellId, DirectionsEnum direction)
        {
            m_map = map;
            m_cell = map.Cells[cellId];
            m_direction = direction;
        }

        public bool IsValid => m_cell.Id > 0 && m_cell.Id < MapPoint.MapSize &&
                               m_direction > DirectionsEnum.DIRECTION_EAST &&
                               m_direction < DirectionsEnum.DIRECTION_NORTH_EAST && m_map != null;

        public DirectionsEnum Direction
        {
            get => m_direction;
            set
            {
                m_direction = value;

                NotifyPositionChanged();
            }
        }

        public Cell Cell
        {
            get => m_cell;
            set
            {
                m_cell = value;
                m_point = null;

                NotifyPositionChanged();
            }
        }

        public Map Map
        {
            get => m_map;
            set
            {
                m_map = value;

                NotifyPositionChanged();
            }
        }

        public MapPoint Point => m_point ?? (m_point = MapPoint.GetPoint(Cell));

        public event Action<ObjectPosition> PositionChanged;

        private void NotifyPositionChanged()
        {
            var handler = PositionChanged;
            if (handler != null)
                handler(this);
        }

        public ObjectPosition Clone()
        {
            return new ObjectPosition(Map, Cell, Direction);
        }
    }
}