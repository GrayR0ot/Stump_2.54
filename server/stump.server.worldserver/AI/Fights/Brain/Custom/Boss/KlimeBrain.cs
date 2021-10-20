using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom
{
    [BrainIdentifier((int) MonsterIdEnum.KLIME)]
    public class KlimBrain : Brain
    {
        public KlimBrain(AIFighter fighter) : base(fighter)
        {
            fighter.Fight.FightStarted += Fight_FightStarted;
        }

        private void Fight_FightStarted(IFight obj)
        {
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.GALUCHAT_3485, 1), Fighter.Cell);
        }
    }
}