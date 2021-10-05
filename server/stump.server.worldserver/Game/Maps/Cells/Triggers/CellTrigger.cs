using Stump.Server.WorldServer.Database.World.Triggers;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Maps.Cells.Triggers
{
    public abstract class CellTrigger
    {
        protected CellTrigger(CellTriggerRecord record)
        {
            Record = record;
            Position = record.GetPosition();
        }

        public CellTriggerRecord Record { get; }

        public ObjectPosition Position { get; }

        public CellTriggerType TriggerType => Record.TriggerType;

        public abstract void Apply(Character character);
    }
}