using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Summons.Ani
{
    [BrainIdentifier(5152)]
    internal class MasqueBrain : Brain
    {
        public MasqueBrain(AIFighter fighter)
            : base(fighter)
        {
            fighter.Team.FighterAdded += OnFighterAdded;
        }

        private void OnFighterAdded(FightTeam team, FightActor fighter)
        {
            if (fighter != Fighter)
                return;

            if (fighter.IsSummoned())
                fighter.CastAutoSpell(new Spell(9942, 1), fighter.Summoner.Cell);
        }
    }
}