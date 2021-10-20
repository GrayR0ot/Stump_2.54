using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Boss
{
    [BrainIdentifier((int) MonsterIdEnum.TONNEAU_PIRATE)]
    public class TonneauPirateBrain : Brain
    {
        public TonneauPirateBrain(AIFighter fighter)
            : base(fighter)
        {
            fighter.Fight.TurnStarted += OnTurnStarted;
        }

        private void OnTurnStarted(IFight obj, FightActor actor)
        {
            if (actor != Fighter || actor.AP < 4)
                return;

            if (Fighter.IsSummoned())
                Fighter.CastAutoSpell(
                    new Spell((int) SpellIdEnum.PLAT_DE_RESISTANCE_838,
                        (short) (Fighter as SummonedMonster).MonsterGrade.GradeId), Fighter.Cell);
            else
                Fighter.CastAutoSpell(
                    new Spell((int) SpellIdEnum.PLAT_DE_RESISTANCE_838,
                        (short) (Fighter as MonsterFighter).MonsterGrade.GradeId), Fighter.Cell);
        }
    }
}