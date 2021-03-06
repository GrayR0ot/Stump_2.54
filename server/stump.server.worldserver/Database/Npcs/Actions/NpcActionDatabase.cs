using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Conditions;

namespace Stump.Server.WorldServer.Database.Npcs.Actions
{
    public abstract class NpcActionDatabase : NpcAction
    {
        protected NpcActionDatabase(NpcActionRecord record)
        {
            Record = record;
        }

        public NpcActionRecord Record { get; }

        public uint Id
        {
            get => Record.Id;
            set => Record.Id = value;
        }

        public int NpcId
        {
            get => Record.NpcId;
            set => Record.NpcId = value;
        }

        public NpcTemplate Template
        {
            get => Record.Template;
            set => Record.Template = value;
        }

        public ConditionExpression ConditionExpression
        {
            get => Record.ConditionExpression;
            set => Record.ConditionExpression = value;
        }

        public override int Priority => Record.Priority;

        public override bool CanExecute(Npc npc, Character character)
        {
            return ConditionExpression == null || ConditionExpression.Eval(character);
        }
    }
}