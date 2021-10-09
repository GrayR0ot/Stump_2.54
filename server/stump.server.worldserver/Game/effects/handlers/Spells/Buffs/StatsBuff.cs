using System;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Spells.Casts;

namespace Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Buffs
{
    [EffectHandler(EffectsEnum.Effect_119)]
    [EffectHandler(EffectsEnum.Effect_123)]
    [EffectHandler(EffectsEnum.Effect_126)]
    [EffectHandler(EffectsEnum.Effect_118)]
    [EffectHandler(EffectsEnum.Effect_124)]
    [EffectHandler(EffectsEnum.Effect_125)]
    [EffectHandler(EffectsEnum.Effect_117)]
    [EffectHandler(EffectsEnum.Effect_136)]
    [EffectHandler(EffectsEnum.Effect_182)]
    [EffectHandler(EffectsEnum.Effect_112)]
    [EffectHandler(EffectsEnum.Effect_121)]
    [EffectHandler(EffectsEnum.Effect_178)]
    [EffectHandler(EffectsEnum.Effect_138)]
    [EffectHandler(EffectsEnum.Effect_1054)]
    [EffectHandler(EffectsEnum.Effect_165)]
    [EffectHandler(EffectsEnum.Effect_107)]
    [EffectHandler(EffectsEnum.Effect_137)]
    [EffectHandler(EffectsEnum.Effect_142)]
    [EffectHandler(EffectsEnum.Effect_184)]
    [EffectHandler(EffectsEnum.Effect_183)]
    [EffectHandler(EffectsEnum.Effect_753)]
    [EffectHandler(EffectsEnum.Effect_752)]
    [EffectHandler(EffectsEnum.Effect_160)]
    [EffectHandler(EffectsEnum.Effect_161)]
    [EffectHandler(EffectsEnum.Effect_115)]
    [EffectHandler(EffectsEnum.Effect_122)]
    [EffectHandler(EffectsEnum.Effect_412)]
    [EffectHandler(EffectsEnum.Effect_410)]
    [EffectHandler(EffectsEnum.Effect_414)]
    [EffectHandler(EffectsEnum.Effect_416)]
    [EffectHandler(EffectsEnum.Effect_1040)]
    [EffectHandler(EffectsEnum.Effect_212)]
    [EffectHandler(EffectsEnum.Effect_213)]
    [EffectHandler(EffectsEnum.Effect_210)]
    [EffectHandler(EffectsEnum.Effect_211)]
    [EffectHandler(EffectsEnum.Effect_214)]
    [EffectHandler(EffectsEnum.Effect_1166)]
    [EffectHandler(EffectsEnum.Effect_1144)]
    [EffectHandler(EffectsEnum.Effect_176)]
    [EffectHandler(EffectsEnum.Effect_1171)]
    [EffectHandler(EffectsEnum.Effect_2800)]
    [EffectHandler(EffectsEnum.Effect_2803)]
    [EffectHandler(EffectsEnum.Effect_2804)]
    [EffectHandler(EffectsEnum.Effect_2807)]
    [EffectHandler(EffectsEnum.Effect_2808)]
    [EffectHandler(EffectsEnum.Effect_2811)]
    [EffectHandler(EffectsEnum.Effect_2812)]
    [EffectHandler(EffectsEnum.Effect_2815)]
    [EffectHandler(EffectsEnum.Effect_226)]

    public class StatsBuff : SpellEffectHandler
    {
        public StatsBuff(EffectDice effect, FightActor caster, SpellCastHandler castHandler, Cell targetedCell, bool critical)
            : base(effect, caster, castHandler, targetedCell, critical)
        {
        }

        protected override bool InternalApply()
        {
            var integerEffect = GenerateEffect();

            if (integerEffect == null)
                return false;

            foreach (var actor in GetAffectedActors())
            {
                AddStatBuff(actor, (short)integerEffect.Value, GetEffectCaracteristic());
            }

            return true;
        }
        
        PlayerFields GetEffectCaracteristic()
        {
            switch (Effect.EffectId)
            {
                case EffectsEnum.Effect_125:
                    return PlayerFields.Vitality;
                case EffectsEnum.Effect_119:
                    return PlayerFields.Agility;
                case EffectsEnum.Effect_123:
                    return PlayerFields.Chance;
                case EffectsEnum.Effect_126:
                    return PlayerFields.Intelligence;
                case EffectsEnum.Effect_118:
                    return PlayerFields.Strength;
                case EffectsEnum.Effect_124:
                    return PlayerFields.Wisdom;
                case EffectsEnum.Effect_117:
                case EffectsEnum.Effect_136:
                    return PlayerFields.Range;
                case EffectsEnum.Effect_182:
                    return PlayerFields.SummonLimit;
                case EffectsEnum.Effect_112:
                case EffectsEnum.Effect_121:
                    return PlayerFields.DamageBonus;
                case EffectsEnum.Effect_138:
                case EffectsEnum.Effect_165:
                    return PlayerFields.DamageBonusPercent;
                case EffectsEnum.Effect_178:
                    return PlayerFields.HealBonus;
                case EffectsEnum.Effect_107:
                    return PlayerFields.DamageReflection;
                case EffectsEnum.Effect_137:
                case EffectsEnum.Effect_142:
                    return PlayerFields.PhysicalDamage;
                case EffectsEnum.Effect_184:
                    return PlayerFields.PhysicalDamageReduction;
                case EffectsEnum.Effect_183:
                    return PlayerFields.MagicDamageReduction;
                case EffectsEnum.Effect_753:
                    return PlayerFields.TackleBlock;
                case EffectsEnum.Effect_752:
                    return PlayerFields.TackleEvade;
                case EffectsEnum.Effect_160:
                    return PlayerFields.DodgeAPProbability;
                case EffectsEnum.Effect_161:
                    return PlayerFields.DodgeMPProbability;
                case EffectsEnum.Effect_115:
                    return PlayerFields.CriticalHit;
                case EffectsEnum.Effect_122:
                    return PlayerFields.CriticalMiss;
                case EffectsEnum.Effect_412:
                    return PlayerFields.MPAttack;
                case EffectsEnum.Effect_410:
                    return PlayerFields.APAttack;
                case EffectsEnum.Effect_414:
                    return PlayerFields.PushDamageBonus;
                case EffectsEnum.Effect_416:
                    return PlayerFields.PushDamageReduction;
                case EffectsEnum.Effect_1040:
                    return PlayerFields.Shield;
                case EffectsEnum.Effect_212:
                    return PlayerFields.AirResistPercent;
                case EffectsEnum.Effect_213:
                    return PlayerFields.FireResistPercent;
                case EffectsEnum.Effect_210:
                    return PlayerFields.EarthResistPercent;
                case EffectsEnum.Effect_211:
                    return PlayerFields.WaterResistPercent;
                case EffectsEnum.Effect_214:
                    return PlayerFields.NeutralResistPercent;
                case EffectsEnum.Effect_1166:
                    return PlayerFields.GlyphBonusPercent;
                case EffectsEnum.Effect_1144:
                    return PlayerFields.WeaponDamageBonus;
                case EffectsEnum.Effect_1054:
                    return PlayerFields.SpellDamageBonus;
                case EffectsEnum.Effect_176:
                    return PlayerFields.Prospecting;
                case EffectsEnum.Effect_1171:
                    return PlayerFields.DamageMultiplicator;
                case EffectsEnum.Effect_2800:
                    return PlayerFields.MeleeDamageDonePercent;
                case EffectsEnum.Effect_2803:
                    return PlayerFields.MeleeDamageReceivedPercent;
                case EffectsEnum.Effect_2804:
                    return PlayerFields.RangedDamageDonePercent;
                case EffectsEnum.Effect_2807:
                    return PlayerFields.RangedDamageReceivedPercent;
                case EffectsEnum.Effect_2808:
                    return PlayerFields.WeaponDamageDonePercent;
                case EffectsEnum.Effect_2811:
                    return PlayerFields.WeaponDamageReceivedPercent;
                case EffectsEnum.Effect_2812:
                    return PlayerFields.SpellDamageDonePercent;
                case EffectsEnum.Effect_2815:
                    return PlayerFields.SpellDamageReceivedPercent;
                case EffectsEnum.Effect_226:
                    return PlayerFields.TrapBonusPercent;
                default:
                    throw new Exception($"'{Effect.EffectId}' has no binded caracteristic");
            }
        }
    }
}