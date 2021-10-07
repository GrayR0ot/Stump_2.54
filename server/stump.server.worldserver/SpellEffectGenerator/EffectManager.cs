using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Effects;
using Stump.Server.WorldServer.Game.Effects.Handlers.Items;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Items;

namespace SpellEffectGenerator
{
    public class EffectManager
    {
        public const double DEFAULT_STAT_POWER = 1;

        // http://dofuswiki.wikia.com/wiki/Mage#Rune_Maging
        public static readonly Dictionary<CharacteristicEnum, double> POWER_PER_STAT = new Dictionary<CharacteristicEnum, double> {
            { CharacteristicEnum.AP, 101 },
            { CharacteristicEnum.MP, 90 },
            { CharacteristicEnum.RANGE, 51 },
            { CharacteristicEnum.REFLECT, 30 },
            { CharacteristicEnum.SUMMONS, 30 },
            { CharacteristicEnum.CRITICAL_HITS, 10 },
            { CharacteristicEnum.HEALS, 10 },
            { CharacteristicEnum.DAMAGE, 20 },
            { CharacteristicEnum.TRAPS_BONUS_FIXED, 15 },
            { CharacteristicEnum.AP_REDUCTION, 7 },
            { CharacteristicEnum.MP_REDUCTION, 7 },
            { CharacteristicEnum.AP_LOSS_RES, 7 },
            { CharacteristicEnum.MP_LOSS_RES, 7 },
            { CharacteristicEnum.FIRE_REDUCTION_PERCENT, 6 },
            { CharacteristicEnum.WATER_REDUCTION_PERCENT, 6 },
            { CharacteristicEnum.AIR_REDUCTION_PERCENT, 6 },
            { CharacteristicEnum.EARTH_REDUCTION_PERCENT, 6 },
            { CharacteristicEnum.NEUTRAL_REDUCTION_PERCENT, 6 },
            { CharacteristicEnum.NEUTRAL_DAMAGE_FIXED, 5 },
            { CharacteristicEnum.AIR_DAMAGE_FIXED, 5 },
            { CharacteristicEnum.FIRE_DAMAGE_FIXED, 5 },
            { CharacteristicEnum.EARTH_DAMAGE_FIXED, 5 },
            { CharacteristicEnum.WATER_DAMAGE_FIXED, 5 },
            { CharacteristicEnum.CRITICAL_DAMAGE, 5 },
            { CharacteristicEnum.PUSHBACK_DAMAGE_FIXED, 5 },
            { CharacteristicEnum.LOCK, 4 },
            { CharacteristicEnum.DODGE, 4 },
            { CharacteristicEnum.WISDOM, 3 },
            { CharacteristicEnum.PROSPECTING, 3 },
            { CharacteristicEnum.POWER, 2 },
            { CharacteristicEnum.TRAPS_BONUS_PERCENT, 2 },
            { CharacteristicEnum.FIRE_REDUCTION_FIXED, 2 },
            { CharacteristicEnum.EARTH_REDUCTION_FIXED, 2 },
            { CharacteristicEnum.WATER_REDUCTION_FIXED, 2 },
            { CharacteristicEnum.AIR_REDUCTION_FIXED, 2 },
            { CharacteristicEnum.NEUTRAL_REDUCTION_FIXED, 2 },
            { CharacteristicEnum.PUSHBACK_REDUCTION, 2 },
            { CharacteristicEnum.CRITICAL_REDUCTION_FIXED, 2 },
            { CharacteristicEnum.STRENGTH, 1 },
            { CharacteristicEnum.CHANCE, 1 },
            { CharacteristicEnum.INTELLIGENCE, 1 },
            { CharacteristicEnum.AGILITY, 1 },
            { CharacteristicEnum.WEIGHT, 0.25 },
            { CharacteristicEnum.VITALITY, 0.2 },
            { CharacteristicEnum.INITIATIVE, 0.1 },
        };

        public static readonly Dictionary<CharacteristicEnum, double> MaxOver = new Dictionary<CharacteristicEnum, double>
        {
            {CharacteristicEnum.AP, 1},
            {CharacteristicEnum.MP, 1},
            {CharacteristicEnum.RANGE, 1},
            {CharacteristicEnum.REFLECT, 1},
            {CharacteristicEnum.SUMMONS, 1},
            {CharacteristicEnum.CRITICAL_HITS, 2},
            {CharacteristicEnum.HEALS, 3},
            {CharacteristicEnum.DAMAGE, 3},
            {CharacteristicEnum.TRAPS_BONUS_FIXED, 3},
            {CharacteristicEnum.AP_REDUCTION, 3},
            {CharacteristicEnum.MP_REDUCTION, 3},
            {CharacteristicEnum.AP_LOSS_RES, 3},
            {CharacteristicEnum.MP_LOSS_RES, 3},
            {CharacteristicEnum.FIRE_REDUCTION_PERCENT, 3},
            {CharacteristicEnum.WATER_REDUCTION_PERCENT, 3},
            {CharacteristicEnum.AIR_REDUCTION_PERCENT, 3},
            {CharacteristicEnum.EARTH_REDUCTION_PERCENT, 3},
            {CharacteristicEnum.NEUTRAL_REDUCTION_PERCENT, 3},
            {CharacteristicEnum.NEUTRAL_DAMAGE_FIXED, 3},
            {CharacteristicEnum.AIR_DAMAGE_FIXED, 3},
            {CharacteristicEnum.FIRE_DAMAGE_FIXED, 3},
            {CharacteristicEnum.EARTH_DAMAGE_FIXED, 3},
            {CharacteristicEnum.WATER_DAMAGE_FIXED, 3},
            {CharacteristicEnum.CRITICAL_DAMAGE, 3},
            {CharacteristicEnum.PUSHBACK_DAMAGE_FIXED, 10},
            {CharacteristicEnum.LOCK, 3},
            {CharacteristicEnum.DODGE, 3},
            {CharacteristicEnum.WISDOM, 10},
            {CharacteristicEnum.PROSPECTING, 10},
            {CharacteristicEnum.POWER, 10},
            {CharacteristicEnum.TRAPS_BONUS_PERCENT, 2},
            {CharacteristicEnum.FIRE_REDUCTION_FIXED, 10},
            {CharacteristicEnum.EARTH_REDUCTION_FIXED, 10},
            {CharacteristicEnum.WATER_REDUCTION_FIXED, 10},
            {CharacteristicEnum.AIR_REDUCTION_FIXED, 10},
            {CharacteristicEnum.NEUTRAL_REDUCTION_FIXED, 10},
            {CharacteristicEnum.PUSHBACK_REDUCTION, 10},
            {CharacteristicEnum.CRITICAL_REDUCTION_FIXED, 10},
            {CharacteristicEnum.STRENGTH, 10},
            {CharacteristicEnum.CHANCE, 10},
            {CharacteristicEnum.INTELLIGENCE, 10},
            {CharacteristicEnum.AGILITY, 10},
            {CharacteristicEnum.WEIGHT, 404},
            {CharacteristicEnum.VITALITY, 50},
            {CharacteristicEnum.INITIATIVE, 100},
        };

        /// <summary>
        ///   D2O Effect class to stump effect class
        /// </summary>
        /// <param name = "effect"></param>
        /// <returns></returns>
        public EffectBase ConvertExportedEffect(EffectInstance effect)
        {
            if (effect is EffectInstanceLadder)
                return new EffectLadder(effect as EffectInstanceLadder);
            if (effect is EffectInstanceCreature)
                return new EffectCreature(effect as EffectInstanceCreature);
            if (effect is EffectInstanceDate)
                return new EffectDate(effect as EffectInstanceDate);
            if (effect is EffectInstanceDice)
                return new EffectDice(effect as EffectInstanceDice);
            if (effect is EffectInstanceDuration)
                return new EffectDuration(effect as EffectInstanceDuration);
            if (effect is EffectInstanceMinMax)
                return new EffectMinMax(effect as EffectInstanceMinMax);
            if (effect is EffectInstanceMount)
                return new EffectMount(effect as EffectInstanceMount);
            if (effect is EffectInstanceString)
                return new EffectString(effect as EffectInstanceString);
            if (effect is EffectInstanceInteger)
                return new EffectInteger(effect as EffectInstanceInteger);

            return new EffectBase(effect);
        }

        public IEnumerable<EffectBase> ConvertExportedEffect(IEnumerable<EffectInstance> effects)
        {
            return effects.Select(ConvertExportedEffect);
        }

        public byte[] SerializeEffect(EffectInstance effectInstance)
        {
            return ConvertExportedEffect(effectInstance).Serialize();
        }

        public byte[] SerializeEffect(EffectBase effect)
        {
            return effect.Serialize();
        }

        public byte[] SerializeEffects(IEnumerable<EffectBase> effects)
        {
            var buffer = new List<byte>();

            foreach (var effect in effects)
            {
                buffer.AddRange(effect.Serialize());
            }

            return buffer.ToArray();
        }

        public byte[] SerializeEffects(IEnumerable<EffectInstance> effects)
        {
            var buffer = new List<byte>();

            foreach (var effect in effects)
            {
                buffer.AddRange(SerializeEffect(effect));
            }

            return buffer.ToArray();
        }


        public List<EffectBase> DeserializeEffectsFromJson(String jsonArray)
        {
            return JsonConvert.DeserializeObject<List<EffectBase>>(jsonArray);
        }
        public List<EffectBase> DeserializeEffects(byte[] buffer)
        {
            var result = new List<EffectBase>();

            var i = 0;
            while (i + 1 < buffer.Length)
            {
                result.Add(DeserializeEffect(buffer, ref i));
            }

            return result;
        }

        public EffectBase DeserializeEffect(byte[] buffer, ref int index)
        {
            if (buffer.Length < index)
                throw new Exception("buffer too small to contain an Effect");

            var identifier = buffer[0 + index];
            EffectBase effect;

            switch (identifier)
            {
                case 1:
                    effect = new EffectBase();
                    break;
                case 2:
                    effect = new EffectCreature();
                    break;
                case 3:
                    effect = new EffectDate();
                    break;
                case 4:
                    effect = new EffectDice();
                    break;
                case 5:
                    effect = new EffectDuration();
                    break;
                case 6:
                    effect = new EffectInteger();
                    break;
                case 7:
                    effect = new EffectLadder();
                    break;
                case 8:
                    effect = new EffectMinMax();
                    break;
                case 9:
                    effect = new EffectMount();
                    break;
                case 10:
                    effect = new EffectString();
                    break;
                default:
                    throw new Exception(string.Format("Incorrect identifier : {0}", identifier));
            }

            index++;
            effect.DeSerialize(buffer, ref index);

            return effect;
        }

        public double GetEffectMinPower(EffectDice effect)
        {
            var min = effect.DiceFace < effect.DiceNum && effect.DiceFace != 0 ? effect.DiceFace : effect.DiceNum;

            return (effect.Template.BonusType < 0 ? -1 : 1) * min * GetEffectPower(effect.Template);
        }


        public double GetEffectMaxPower(EffectDice effect)
        {
            int max;
            if (effect.DiceFace == 0 || effect.DiceNum == 0)
                max = effect.DiceFace == 0 ? effect.DiceNum : effect.DiceFace;
            else
                max = effect.DiceFace < effect.DiceNum ? effect.DiceNum : effect.DiceFace;

            return (effect.Template.BonusType < 0 ? -1 : 1) * max * GetEffectPower(effect.Template);
        }

        public double GetEffectPower(EffectInteger effect)
        {
            return (effect.Template.BonusType < 0 ? -1 : 1) * GetEffectPower(effect.Template) * effect.Value;
        }

        public double GetEffectBasePower(EffectBase effect)
        {
            return (effect.Template.BonusType < 0 ? -1 : 1) * GetEffectPower(effect.Template);
        }

        public double GetEffectPower(EffectTemplate effect)
        {
            return POWER_PER_STAT.ContainsKey((CharacteristicEnum)effect.Characteristic) ? POWER_PER_STAT[(CharacteristicEnum)effect.Characteristic] : DEFAULT_STAT_POWER;
        }

        public double GetOverMax(EffectInteger effect)
        {
            return (effect.Template.BonusType < 0 ? -1 : 1) * GetEffectPower(effect.Template) * GetOverMax(effect.Template);
        }

        public double GetOverMax(EffectTemplate effect)
        {
            return MaxOver.ContainsKey((CharacteristicEnum)effect.Characteristic) ? MaxOver[(CharacteristicEnum)effect.Characteristic] : DEFAULT_STAT_POWER;
        }

        public double GetItemPower(IItem item)
        {
            return item.Effects.OfType<EffectInteger>().Sum(x => GetEffectPower(x));
        }

        public double GetItemMinPower(IItem item)
        {
            return item.Template.Effects.OfType<EffectDice>().Sum(x => GetEffectMinPower(x));
        }

        public double GetItemMaxPower(IItem item)
        {
            return item.Template.Effects.OfType<EffectDice>().Sum(x => GetEffectMaxPower(x));
        }

        #region Unrandomable Effects

        readonly EffectsEnum[] m_unRandomablesEffects =
            {
                    EffectsEnum.Effect_DamageWater,
                    EffectsEnum.Effect_DamageEarth,
                    EffectsEnum.Effect_DamageAir,
                    EffectsEnum.Effect_DamageFire,
                    EffectsEnum.Effect_DamageNeutral,

                    EffectsEnum.Effect_StealHPWater,
                    EffectsEnum.Effect_StealHPEarth,
                    EffectsEnum.Effect_StealHPAir,
                    EffectsEnum.Effect_StealHPFire,
                    EffectsEnum.Effect_StealHPNeutral,

                    EffectsEnum.Effect_LostAP,

                    EffectsEnum.Effect_RemainingFights,

                    EffectsEnum.Effect_HealHP_108,

                    EffectsEnum.Effect_SoulStone,
                    EffectsEnum.Effect_SoulStoneSummon,

                    EffectsEnum.Effect_CastSpell_1175,

                    EffectsEnum.Effect_Exchangeable,

                    EffectsEnum.Effect_LastMeal,
                    EffectsEnum.Effect_LastMealDate,

                    EffectsEnum.Effect_Corpulence,


                    EffectsEnum.Effect_999,
                };

        #endregion
    }
}