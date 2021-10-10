using System;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Spell = Stump.Server.WorldServer.Game.Spells.Spell;

using Stump.Server.WorldServer.Game.Spells.Casts;
using Stump.Server.WorldServer.Game.Fights.Buffs;

namespace Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Debuffs
{
    [EffectHandler(EffectsEnum.Effect_154)]
    [EffectHandler(EffectsEnum.Effect_152)]
    [EffectHandler(EffectsEnum.Effect_155)]
    [EffectHandler(EffectsEnum.Effect_157)]
    [EffectHandler(EffectsEnum.Effect_156)]
    [EffectHandler(EffectsEnum.Effect_153)]
    [EffectHandler(EffectsEnum.Effect_116)]
    [EffectHandler(EffectsEnum.Effect_135)]
    [EffectHandler(EffectsEnum.Effect_171)]
    [EffectHandler(EffectsEnum.Effect_145)]
    [EffectHandler(EffectsEnum.Effect_186)]
    [EffectHandler(EffectsEnum.Effect_754)]
    [EffectHandler(EffectsEnum.Effect_755)]
    [EffectHandler(EffectsEnum.Effect_162)]
    [EffectHandler(EffectsEnum.Effect_163)]
    [EffectHandler(EffectsEnum.Effect_411)]
    [EffectHandler(EffectsEnum.Effect_413)]
    [EffectHandler(EffectsEnum.Effect_179)]
    [EffectHandler(EffectsEnum.Effect_219)]
    [EffectHandler(EffectsEnum.Effect_215)]
    [EffectHandler(EffectsEnum.Effect_216)]
    [EffectHandler(EffectsEnum.Effect_217)]
    [EffectHandler(EffectsEnum.Effect_218)]
    [EffectHandler(EffectsEnum.Effect_1172)]
    [EffectHandler(EffectsEnum.Effect_2801)]
    [EffectHandler(EffectsEnum.Effect_2802)]
    [EffectHandler(EffectsEnum.Effect_2805)]
    [EffectHandler(EffectsEnum.Effect_2806)]
    [EffectHandler(EffectsEnum.Effect_2809)]
    [EffectHandler(EffectsEnum.Effect_2810)]
    [EffectHandler(EffectsEnum.Effect_2813)]
    [EffectHandler(EffectsEnum.Effect_2814)]
    [EffectHandler(EffectsEnum.Effect_417)]
    [EffectHandler(EffectsEnum.Effect_415)]

    public class StatsDebuff : SpellEffectHandler
    {
        public StatsDebuff(EffectDice effect, FightActor caster, SpellCastHandler castHandler, Cell targetedCell, bool critical)
            : base(effect, caster, castHandler, targetedCell, critical)
        {
        }

        protected override bool InternalApply()
        {
            foreach (var actor in GetAffectedActors())
            {
                var integerEffect = GenerateEffect();

                if (integerEffect == null)
                    return false;

                if (Effect.Duration == 0)
                    continue;

                if (Effect.EffectId == EffectsEnum.Effect_116)
                {
                    actor.OnFightPointsVariation(ActionsEnum.ACTION_CHARACTER_DEBOOST_RANGE, Caster, actor, (short)(-integerEffect.Value));
                    actor.TriggerBuffs(actor, BuffTriggerType.OnRangeLost);
                }

                AddStatBuff(actor, (short) (-integerEffect.Value), GetEffectCaracteristic(Effect.EffectId));
            }

            return true;
        }

        public static PlayerFields GetEffectCaracteristic(EffectsEnum effect)
        {
            switch (effect)
            {
                case EffectsEnum.Effect_154:
                    return PlayerFields.Agility;
                case EffectsEnum.Effect_152:
                    return PlayerFields.Chance;
                case EffectsEnum.Effect_155:
                    return PlayerFields.Intelligence;
                case EffectsEnum.Effect_157:
                    return PlayerFields.Strength;
                case EffectsEnum.Effect_156:
                    return PlayerFields.Wisdom;
                case EffectsEnum.Effect_116:
                case EffectsEnum.Effect_135:
                    return PlayerFields.Range;
                case EffectsEnum.Effect_171:
                    return PlayerFields.CriticalHit;
                case EffectsEnum.Effect_145:
                    return PlayerFields.DamageBonus;
                case EffectsEnum.Effect_186:
                    return PlayerFields.DamageBonusPercent;
                case EffectsEnum.Effect_754:
                    return PlayerFields.TackleEvade;
                case EffectsEnum.Effect_755:
                    return PlayerFields.TackleBlock;
                case EffectsEnum.Effect_162:
                    return PlayerFields.DodgeAPProbability;
                case EffectsEnum.Effect_163:
                case EffectsEnum.Effect_153:
                    return PlayerFields.Vitality;
                case EffectsEnum.Effect_411:
                    return PlayerFields.APAttack;
                case EffectsEnum.Effect_413:
                    return PlayerFields.MPAttack;
                case EffectsEnum.Effect_179:
                    return PlayerFields.HealBonus;
                case EffectsEnum.Effect_219:
                    return PlayerFields.NeutralResistPercent;
                case EffectsEnum.Effect_215:
                    return PlayerFields.EarthResistPercent;
                case EffectsEnum.Effect_216:
                    return PlayerFields.WaterResistPercent;
                case EffectsEnum.Effect_217:
                    return PlayerFields.AirResistPercent;
                case EffectsEnum.Effect_218:
                    return PlayerFields.FireResistPercent;
                case EffectsEnum.Effect_1172:
                    return PlayerFields.DamageMultiplicator;
                case EffectsEnum.Effect_2801:
                    return PlayerFields.MeleeDamageDonePercent;
                case EffectsEnum.Effect_2802:
                    return PlayerFields.MeleeDamageReceivedPercent;
                case EffectsEnum.Effect_2805:
                    return PlayerFields.RangedDamageDonePercent;
                case EffectsEnum.Effect_2806:
                    return PlayerFields.RangedDamageReceivedPercent;
                case EffectsEnum.Effect_2809:
                    return PlayerFields.WeaponDamageDonePercent;
                case EffectsEnum.Effect_2810:
                    return PlayerFields.WeaponDamageReceivedPercent;
                case EffectsEnum.Effect_2814:
                    return PlayerFields.SpellDamageReceivedPercent;
                case EffectsEnum.Effect_2813:
                    return PlayerFields.SpellDamageDonePercent;
                case EffectsEnum.Effect_417:
                    return PlayerFields.PushDamageReduction;
                case EffectsEnum.Effect_415:
                    return PlayerFields.PushDamageBonus;
                default:
                    throw new Exception(string.Format("'{0}' has no binded caracteristic", effect));
            }
        }
    }
}