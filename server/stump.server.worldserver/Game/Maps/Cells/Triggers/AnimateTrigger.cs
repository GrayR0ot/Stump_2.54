using System.Collections.Generic;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Types;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Database.World.Triggers;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Handlers.Interactives;

namespace Stump.Server.WorldServer.Game.Maps.Cells.Triggers
{
    [Discriminator("Animate", typeof(CellTrigger), typeof(CellTriggerRecord))]
    public class AnimateTrigger : CellTrigger
    {
        private short? m_cellId;

        private int? m_elementId;
        private int? m_mapId;
        private readonly MapObstacle[] m_mapObstacles;
        private string m_obstacles;

        public AnimateTrigger(CellTriggerRecord record)
            : base(record)
        {
            m_mapObstacles = ObstaclesCSV == null
                ? new MapObstacle[0]
                : ObstaclesCSV.FromCSV<short>(",")
                    .Select(x => new MapObstacle((ushort) x, (sbyte) MapObstacleStateEnum.OBSTACLE_CLOSED)).ToArray();
        }

        /// <summary>
        ///     Parameter 0
        /// </summary>
        public int ElementId
        {
            get => m_elementId ?? (m_elementId = Record.GetParameter<int>(0)).Value;
            set
            {
                Record.SetParameter(0, value);
                m_elementId = value;
            }
        }

        /// <summary>
        ///     Parameter 1
        /// </summary>
        public int MapId
        {
            get => m_mapId ?? (m_mapId = Record.GetParameter<int>(1)).Value;
            set
            {
                Record.SetParameter(1, value);
                m_mapId = value;
            }
        }

        /// <summary>
        ///     Parameter 2
        /// </summary>
        public short CellId
        {
            get => m_cellId ?? (m_cellId = Record.GetParameter<short>(2)).Value;
            set
            {
                Record.SetParameter(2, value);
                m_cellId = value;
            }
        }

        public string ObstaclesCSV
        {
            get => m_obstacles ?? (m_obstacles = Record.AdditionalParameters);
            set
            {
                Record.AdditionalParameters = value;
                m_obstacles = value;
            }
        }

        public List<MapObstacle> Obstacles => m_mapObstacles.ToList();

        public override void Apply(Character character)
        {
            if (!Record.IsConditionFilled(character))
                return;

            var map = World.Instance.GetMap(MapId);

            var interactive = map.GetInteractiveObject(ElementId);
            if (interactive == null)
                return;

            if (interactive.State != InteractiveStateEnum.STATE_NORMAL)
                return;

            interactive.SetInteractiveState(InteractiveStateEnum.STATE_ACTIVATED);

            Obstacles.ForEach(x => x.State = (sbyte) MapObstacleStateEnum.OBSTACLE_OPENED);
            InteractiveHandler.SendMapObstacleUpdatedMessage(map.Clients, Obstacles);

            foreach (var element in map.GetInteractiveObjects())
                InteractiveHandler.SendInteractiveElementUpdatedMessage(map.Clients, character, element);

            map.Area.CallDelayed(20000, () => Reset(character));
        }

        public void Reset(Character character)
        {
            var map = World.Instance.GetMap(MapId);

            var interactive = map.GetInteractiveObject(ElementId);
            if (interactive == null)
                return;

            interactive.SetInteractiveState(InteractiveStateEnum.STATE_NORMAL);

            Obstacles.ForEach(x => x.State = (sbyte) MapObstacleStateEnum.OBSTACLE_CLOSED);
            InteractiveHandler.SendMapObstacleUpdatedMessage(map.Clients, Obstacles);

            foreach (var element in map.GetInteractiveObjects())
                InteractiveHandler.SendInteractiveElementUpdatedMessage(map.Clients, character, element);

            map.MoveCharactersToWalkableCell();
        }
    }
}