using System;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Fights.Buffs;
using Stump.Server.WorldServer.Game.Spells.Casts;

namespace Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Damage
{
    [EffectHandler(EffectsEnum.Effect_1093)]
    [EffectHandler(EffectsEnum.Effect_1096)]
    [EffectHandler(EffectsEnum.Effect_1094)]
    [EffectHandler(EffectsEnum.Effect_1095)]
    [EffectHandler(EffectsEnum.Effect_1092)]
    [EffectHandler(EffectsEnum.Effect_1119)]
    [EffectHandler(EffectsEnum.Effect_1122)]
    [EffectHandler(EffectsEnum.Effect_1120)]
    [EffectHandler(EffectsEnum.Effect_1121)]
    [EffectHandler(EffectsEnum.Effect_1118)]
    public class DamagePerHPEroded : SpellEffectHandler
    {
        public DamagePerHPEroded(EffectDice effect, FightActor caster, SpellCastHandler castHandler, Cell targetedCell, bool critical)
            : base(effect, caster, castHandler, targetedCell, critical)
        {
        }

        protected override bool InternalApply()
        {
            foreach (var actor in GetAffectedActors())
            {
                if (Effect.Duration != 0 || Effect.Delay != 0)
                {
                    AddTriggerBuff(actor, BuffTriggerType.Instant, OnBuffTriggered);
                }
                else
                {
                    var damages = new Fights.Damage(Dice)
                    {
                        Source = Caster,
                        IgnoreDamageReduction = true,
                        IgnoreDamageBoost = true,
                        School = GetEffectSchool(Dice.EffectId),
                        MarkTrigger = MarkTrigger,
                        IsCritical = Critical,
                        Amount = (int)Math.Floor((actor.Stats.Health.PermanentDamages * Dice.DiceNum) / 100d)
                    };

                    if (Effect.EffectId == EffectsEnum.Effect_1118 ||
                        Effect.EffectId == EffectsEnum.Effect_1122 ||
                        Effect.EffectId == EffectsEnum.Effect_1120 ||
                        Effect.EffectId == EffectsEnum.Effect_1121 ||
                        Effect.EffectId == EffectsEnum.Effect_1119)
                    {
                        damages.Amount = (int)Math.Floor((Caster.Stats.Health.PermanentDamages * Dice.DiceNum) / 100d);
                    }

                    actor.InflictDamage(damages);
                }
            }

            return true;
        }

        void OnBuffTriggered(TriggerBuff buff, FightActor triggerrer, BuffTriggerType trigger, object token)
        {
            var damages = new Fights.Damage(Dice)
            {
                Source = buff.Caster,
                Buff = buff,
                IgnoreDamageReduction = true,
                IgnoreDamageBoost = true,
                School = GetEffectSchool(buff.Dice.EffectId),
                MarkTrigger = MarkTrigger,
                IsCritical = Critical,
                Amount = (int)Math.Floor((buff.Target.Stats.Health.PermanentDamages * Dice.DiceNum) / 100d)
            };

            if (Effect.EffectId == EffectsEnum.Effect_1118 ||
                Effect.EffectId == EffectsEnum.Effect_1122 ||
                Effect.EffectId == EffectsEnum.Effect_1120 ||
                Effect.EffectId == EffectsEnum.Effect_1121 ||
                Effect.EffectId == EffectsEnum.Effect_1119)
            {
                damages.Amount = (int)Math.Floor((buff.Caster.Stats.Health.PermanentDamages * Dice.DiceNum) / 100d);
            }

            buff.Target.InflictDamage(damages);
        }

        static EffectSchoolEnum GetEffectSchool(EffectsEnum effect)
        {
            switch (effect)
            {
                case EffectsEnum.Effect_1095:
                case EffectsEnum.Effect_1121:
                    return EffectSchoolEnum.Water;
                case EffectsEnum.Effect_1096:
                case EffectsEnum.Effect_1122:
                    return EffectSchoolEnum.Earth;
                case EffectsEnum.Effect_1093:
                case EffectsEnum.Effect_1119:
                    return EffectSchoolEnum.Air;
                case EffectsEnum.Effect_1094:
                case EffectsEnum.Effect_1120:
                    return EffectSchoolEnum.Fire;
                case EffectsEnum.Effect_1092:
                case EffectsEnum.Effect_1118:
                    return EffectSchoolEnum.Neutral;
                default:
                    throw new Exception(string.Format("Effect {0} has not associated School Type", effect));
            }
        }
    }
}