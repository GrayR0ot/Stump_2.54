using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Spells
{
    public abstract class SpellTargetStrategy
    {
        public SpellTargetStrategy(Spell spell)
        {
            Spell = spell;
        }

        public Spell Spell { get; }

        public abstract AISpellCastPossibility FindBestCast();
    }
}