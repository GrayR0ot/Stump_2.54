using System;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Spells;

using Stump.Server.WorldServer.Game.Spells.Casts;
namespace Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Damage
{
    [EffectHandler(EffectsEnum.Effect_277)]
    [EffectHandler(EffectsEnum.Effect_276)]
    [EffectHandler(EffectsEnum.Effect_278)]
    [EffectHandler(EffectsEnum.Effect_275)]
    [EffectHandler(EffectsEnum.Effect_279)]
    public class DamagePerHPLost : SpellEffectHandler
    {
        public DamagePerHPLost(EffectDice effect, FightActor caster, SpellCastHandler castHandler, Cell targetedCell, bool critical)
            : base(effect, caster, castHandler, targetedCell, critical)
        {
        }

        protected override bool InternalApply()
        {
            foreach (var actor in GetAffectedActors())
            {
                var damages = new Fights.Damage(Dice)
                {
                    Source = Caster,
                    IgnoreDamageReduction = true,
                    IgnoreDamageBoost = true,
                    School = GetEffectSchool(Dice.EffectId),
                    MarkTrigger = MarkTrigger,
                    IsCritical = Critical
                };

                var damagesAmount = Math.Round(((Caster.Stats.Health.DamageTaken * Dice.DiceNum) / 100d));

                damages.Amount = (int)damagesAmount;

                actor.InflictDamage(damages);
            }

            return true;
        }

        static EffectSchoolEnum GetEffectSchool(EffectsEnum effect)
        {
            switch (effect)
            {
                case EffectsEnum.Effect_275:
                    return EffectSchoolEnum.Water;
                case EffectsEnum.Effect_276:
                    return EffectSchoolEnum.Earth;
                case EffectsEnum.Effect_277:
                    return EffectSchoolEnum.Air;
                case EffectsEnum.Effect_278:
                    return EffectSchoolEnum.Fire;
                case EffectsEnum.Effect_279:
                    return EffectSchoolEnum.Neutral;
                default:
                    throw new Exception(string.Format("Effect {0} has not associated School Type", effect));
            }
        }
    }
}
