using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Boss
{
    [BrainIdentifier((int) MonsterIdEnum.GROLLOUM)]
    public class Grollum : Brain
    {
        public Grollum(AIFighter fighter)
            : base(fighter)
        {
            fighter.Fight.FightStarted += Fight_FightStarted;
        }

        private void Fight_FightStarted(IFight obj)
        {
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.DUR_COMME_LA_ROCHE_2408, 1), Fighter.Cell);
        }
    }
}