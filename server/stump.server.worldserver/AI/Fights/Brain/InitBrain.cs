using Stump.Server.WorldServer.Database.AI;
using Stump.Server.WorldServer.Game.Actors.Fight;

namespace Stump.Server.WorldServer.AI.Fights.Brain
{
    public class InitBrain : Brain
    {
        public InitBrain(AIFighter fighter, InitBrainRecord record)
            : base(fighter)
        {
            BrainRecord = record;
            fighter.GetAlive += OnGetAlive;
        }

        private InitBrainRecord BrainRecord { get; }

        private void OnGetAlive(FightActor fighter)
        {
            fighter.CastAutoSpell(BrainRecord.Spell, fighter.Cell);
        }
    }
}