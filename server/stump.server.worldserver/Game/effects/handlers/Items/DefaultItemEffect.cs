using System;
using System.Collections.Generic;
using NLog;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Items.Templates;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Items.Player;

namespace Stump.Server.WorldServer.Game.Effects.Handlers.Items
{
    [DefaultEffectHandler]
    public class DefaultItemEffect : ItemEffectHandler
    {
        #region Delegates

        public delegate void EffectComputeHandler(Character target, EffectInteger effect, bool isBoost, double efficiency);

        #endregion

        #region Binds

         readonly Dictionary<PlayerFields, EffectComputeHandler> m_addMethods = new Dictionary
            <PlayerFields, EffectComputeHandler>
            {
                {PlayerFields.Health, AddHealth},
                {PlayerFields.Initiative, AddInitiative},
                {PlayerFields.Prospecting, AddProspecting},
                {PlayerFields.AP, AddAP},
                {PlayerFields.MP, AddMP},
                {PlayerFields.Strength, AddStrength},
                {PlayerFields.Vitality, AddVitality},
                {PlayerFields.Wisdom, AddWisdom},
                {PlayerFields.Chance, AddChance},
                {PlayerFields.Agility, AddAgility},
                {PlayerFields.Intelligence, AddIntelligence},
                {PlayerFields.Range, AddRange},
                {PlayerFields.SummonLimit, AddSummonLimit},
                {PlayerFields.DamageReflection, AddDamageReflection},
                {PlayerFields.CriticalHit, AddCriticalHit},
                {PlayerFields.CriticalMiss, AddCriticalMiss},
                {PlayerFields.HealBonus, AddHealBonus},
                {PlayerFields.DamageBonus, AddDamageBonus},
                {PlayerFields.WeaponDamageBonus, AddWeaponDamageBonus},
                {PlayerFields.DamageBonusPercent, AddDamageBonusPercent},
                {PlayerFields.TrapBonus, AddTrapBonus},
                {PlayerFields.TrapBonusPercent, AddTrapBonusPercent},
                {PlayerFields.PermanentDamagePercent, AddPermanentDamagePercent},
                {PlayerFields.TackleBlock, AddTackleBlock},
                {PlayerFields.TackleEvade, AddTackleEvade},
                {PlayerFields.APAttack, AddAPAttack},
                {PlayerFields.MPAttack, AddMPAttack},
                {PlayerFields.PushDamageBonus, AddPushDamageBonus},
                {PlayerFields.CriticalDamageBonus, AddCriticalDamageBonus},
                {PlayerFields.NeutralDamageBonus, AddNeutralDamageBonus},
                {PlayerFields.EarthDamageBonus, AddEarthDamageBonus},
                {PlayerFields.WaterDamageBonus, AddWaterDamageBonus},
                {PlayerFields.AirDamageBonus, AddAirDamageBonus},
                {PlayerFields.FireDamageBonus, AddFireDamageBonus},
                {PlayerFields.DodgeAPProbability, AddDodgeAPProbability},
                {PlayerFields.DodgeMPProbability, AddDodgeMPProbability},
                {PlayerFields.NeutralResistPercent, AddNeutralResistPercent},
                {PlayerFields.EarthResistPercent, AddEarthResistPercent},
                {PlayerFields.WaterResistPercent, AddWaterResistPercent},
                {PlayerFields.AirResistPercent, AddAirResistPercent},
                {PlayerFields.FireResistPercent, AddFireResistPercent},
                {PlayerFields.NeutralElementReduction, AddNeutralElementReduction},
                {PlayerFields.EarthElementReduction, AddEarthElementReduction},
                {PlayerFields.WaterElementReduction, AddWaterElementReduction},
                {PlayerFields.AirElementReduction, AddAirElementReduction},
                {PlayerFields.FireElementReduction, AddFireElementReduction},
                {PlayerFields.PushDamageReduction, AddPushDamageReduction},
                {PlayerFields.CriticalDamageReduction, AddCriticalDamageReduction},
                {PlayerFields.PvpNeutralResistPercent, AddPvpNeutralResistPercent},
                {PlayerFields.PvpEarthResistPercent, AddPvpEarthResistPercent},
                {PlayerFields.PvpWaterResistPercent, AddPvpWaterResistPercent},
                {PlayerFields.PvpAirResistPercent, AddPvpAirResistPercent},
                {PlayerFields.PvpFireResistPercent, AddPvpFireResistPercent},
                {PlayerFields.PvpNeutralElementReduction, AddPvpNeutralElementReduction},
                {PlayerFields.PvpEarthElementReduction, AddPvpEarthElementReduction},
                {PlayerFields.PvpWaterElementReduction, AddPvpWaterElementReduction},
                {PlayerFields.PvpAirElementReduction, AddPvpAirElementReduction},
                {PlayerFields.PvpFireElementReduction, AddPvpFireElementReduction},
                {PlayerFields.GlobalDamageReduction, AddGlobalDamageReduction},
                {PlayerFields.DamageMultiplicator, AddDamageMultiplicator},
                {PlayerFields.PhysicalDamage, AddPhysicalDamage},
                {PlayerFields.MagicDamage, AddMagicDamage},
                {PlayerFields.PhysicalDamageReduction, AddPhysicalDamageReduction},
                {PlayerFields.MagicDamageReduction, AddMagicDamageReduction},
                {PlayerFields.Weight, AddWeight},
                {PlayerFields.MeleeDamageDonePercent, AddMeeleDamage},
                {PlayerFields.MeleeDamageReceivedPercent, AddMeeleResistence},
                {PlayerFields.RangedDamageDonePercent, AddRangedDamage},
                {PlayerFields.RangedDamageReceivedPercent, AddRangedResistence},
                {PlayerFields.WeaponDamageDonePercent, AddWeaponDamage},
                {PlayerFields.WeaponDamageReceivedPercent, AddWeaponResistence},
                {PlayerFields.SpellDamageDonePercent, AddSpellDamage},
                {PlayerFields.SpellDamageReceivedPercent, AddSpellResistence},
            };

         readonly Dictionary<PlayerFields, EffectComputeHandler> m_subMethods = new Dictionary
            <PlayerFields, EffectComputeHandler>
            {
                {PlayerFields.Health, SubHealth},
                {PlayerFields.Initiative, SubInitiative},
                {PlayerFields.Prospecting, SubProspecting},
                {PlayerFields.AP, SubAP},
                {PlayerFields.MP, SubMP},
                {PlayerFields.Strength, SubStrength},
                {PlayerFields.Vitality, SubVitality},
                {PlayerFields.Wisdom, SubWisdom},
                {PlayerFields.Chance, SubChance},
                {PlayerFields.Agility, SubAgility},
                {PlayerFields.Intelligence, SubIntelligence},
                {PlayerFields.Range, SubRange},
                {PlayerFields.SummonLimit, SubSummonLimit},
                {PlayerFields.DamageReflection, SubDamageReflection},
                {PlayerFields.CriticalHit, SubCriticalHit},
                {PlayerFields.CriticalMiss, SubCriticalMiss},
                {PlayerFields.HealBonus, SubHealBonus},
                {PlayerFields.DamageBonus, SubDamageBonus},
                {PlayerFields.WeaponDamageBonus, SubWeaponDamageBonus},
                {PlayerFields.DamageBonusPercent, SubDamageBonusPercent},
                {PlayerFields.TrapBonus, SubTrapBonus},
                {PlayerFields.TrapBonusPercent, SubTrapBonusPercent},
                {PlayerFields.PermanentDamagePercent, SubPermanentDamagePercent},
                {PlayerFields.TackleBlock, SubTackleBlock},
                {PlayerFields.TackleEvade, SubTackleEvade},
                {PlayerFields.APAttack, SubAPAttack},
                {PlayerFields.MPAttack, SubMPAttack},
                {PlayerFields.PushDamageBonus, SubPushDamageBonus},
                {PlayerFields.CriticalDamageBonus, SubCriticalDamageBonus},
                {PlayerFields.NeutralDamageBonus, SubNeutralDamageBonus},
                {PlayerFields.EarthDamageBonus, SubEarthDamageBonus},
                {PlayerFields.WaterDamageBonus, SubWaterDamageBonus},
                {PlayerFields.AirDamageBonus, SubAirDamageBonus},
                {PlayerFields.FireDamageBonus, SubFireDamageBonus},
                {PlayerFields.DodgeAPProbability, SubDodgeAPProbability},
                {PlayerFields.DodgeMPProbability, SubDodgeMPProbability},
                {PlayerFields.NeutralResistPercent, SubNeutralResistPercent},
                {PlayerFields.EarthResistPercent, SubEarthResistPercent},
                {PlayerFields.WaterResistPercent, SubWaterResistPercent},
                {PlayerFields.AirResistPercent, SubAirResistPercent},
                {PlayerFields.FireResistPercent, SubFireResistPercent},
                {PlayerFields.NeutralElementReduction, SubNeutralElementReduction},
                {PlayerFields.EarthElementReduction, SubEarthElementReduction},
                {PlayerFields.WaterElementReduction, SubWaterElementReduction},
                {PlayerFields.AirElementReduction, SubAirElementReduction},
                {PlayerFields.FireElementReduction, SubFireElementReduction},
                {PlayerFields.PushDamageReduction, SubPushDamageReduction},
                {PlayerFields.CriticalDamageReduction, SubCriticalDamageReduction},
                {PlayerFields.PvpNeutralResistPercent, SubPvpNeutralResistPercent},
                {PlayerFields.PvpEarthResistPercent, SubPvpEarthResistPercent},
                {PlayerFields.PvpWaterResistPercent, SubPvpWaterResistPercent},
                {PlayerFields.PvpAirResistPercent, SubPvpAirResistPercent},
                {PlayerFields.PvpFireResistPercent, SubPvpFireResistPercent},
                {PlayerFields.PvpNeutralElementReduction, SubPvpNeutralElementReduction},
                {PlayerFields.PvpEarthElementReduction, SubPvpEarthElementReduction},
                {PlayerFields.PvpWaterElementReduction, SubPvpWaterElementReduction},
                {PlayerFields.PvpAirElementReduction, SubPvpAirElementReduction},
                {PlayerFields.PvpFireElementReduction, SubPvpFireElementReduction},
                {PlayerFields.GlobalDamageReduction, SubGlobalDamageReduction},
                {PlayerFields.DamageMultiplicator, SubDamageMultiplicator},
                {PlayerFields.PhysicalDamage, SubPhysicalDamage},
                {PlayerFields.MagicDamage, SubMagicDamage},
                {PlayerFields.PhysicalDamageReduction, SubPhysicalDamageReduction},
                {PlayerFields.MagicDamageReduction, SubMagicDamageReduction},
                {PlayerFields.Weight, SubWeight},
                {PlayerFields.MeleeDamageDonePercent, SubMeeleDamage},
                {PlayerFields.MeleeDamageReceivedPercent, SubMeeleResistence},
                {PlayerFields.RangedDamageDonePercent, SubRangedDamage},
                {PlayerFields.RangedDamageReceivedPercent, SubRangedResistence},
                {PlayerFields.WeaponDamageDonePercent, SubWeaponDamage},
                {PlayerFields.WeaponDamageReceivedPercent, SubWeaponResistence},
                {PlayerFields.SpellDamageDonePercent, SubSpellDamage},
                {PlayerFields.SpellDamageReceivedPercent, SubSpellResistence},
            };


        private  readonly Dictionary<EffectsEnum, PlayerFields> m_addEffectsBinds =
            new Dictionary<EffectsEnum, PlayerFields>
                {
                    {EffectsEnum.Effect_110, PlayerFields.Health},
                    {EffectsEnum.Effect_174, PlayerFields.Initiative},
                    {EffectsEnum.Effect_176, PlayerFields.Prospecting},
                    {EffectsEnum.Effect_111, PlayerFields.AP},
                    {EffectsEnum.Effect_120, PlayerFields.AP},
                    {EffectsEnum.Effect_78, PlayerFields.MP},
                    {EffectsEnum.Effect_128, PlayerFields.MP},
                    {EffectsEnum.Effect_118, PlayerFields.Strength},
                    {EffectsEnum.Effect_125, PlayerFields.Vitality},
                    {EffectsEnum.Effect_124, PlayerFields.Wisdom},
                    {EffectsEnum.Effect_123, PlayerFields.Chance},
                    {EffectsEnum.Effect_119, PlayerFields.Agility},
                    {EffectsEnum.Effect_126, PlayerFields.Intelligence},
                    {EffectsEnum.Effect_117, PlayerFields.Range},
                    {EffectsEnum.Effect_182, PlayerFields.SummonLimit},
                    {EffectsEnum.Effect_220, PlayerFields.DamageReflection},
                    {EffectsEnum.Effect_115, PlayerFields.CriticalHit},
                    {EffectsEnum.Effect_122, PlayerFields.CriticalMiss},
                    {EffectsEnum.Effect_178, PlayerFields.HealBonus},
                    {EffectsEnum.Effect_112, PlayerFields.DamageBonus},
                    {EffectsEnum.Effect_121, PlayerFields.DamageBonus},
                    {EffectsEnum.Effect_138, PlayerFields.DamageBonusPercent},
                    {EffectsEnum.Effect_165, PlayerFields.DamageBonusPercent},
                    {EffectsEnum.Effect_225, PlayerFields.TrapBonus},
                    {EffectsEnum.Effect_226, PlayerFields.TrapBonusPercent},
                    {EffectsEnum.Effect_753,PlayerFields.TackleBlock},
                    {EffectsEnum.Effect_752,PlayerFields.TackleEvade},
                    {EffectsEnum.Effect_410,PlayerFields.APAttack},
                    {EffectsEnum.Effect_412,PlayerFields.MPAttack},
                    {EffectsEnum.Effect_414,PlayerFields.PushDamageBonus},
                    {EffectsEnum.Effect_418, PlayerFields.CriticalDamageBonus},
                    {EffectsEnum.Effect_430, PlayerFields.NeutralDamageBonus},
                    {EffectsEnum.Effect_422, PlayerFields.EarthDamageBonus},
                    {EffectsEnum.Effect_426, PlayerFields.WaterDamageBonus},
                    {EffectsEnum.Effect_428, PlayerFields.AirDamageBonus},
                    {EffectsEnum.Effect_424, PlayerFields.FireDamageBonus},
                    {EffectsEnum.Effect_160,PlayerFields.DodgeAPProbability},
                    {EffectsEnum.Effect_161,PlayerFields.DodgeMPProbability},
                    {EffectsEnum.Effect_214, PlayerFields.NeutralResistPercent},
                    {EffectsEnum.Effect_210, PlayerFields.EarthResistPercent},
                    {EffectsEnum.Effect_211, PlayerFields.WaterResistPercent},
                    {EffectsEnum.Effect_212, PlayerFields.AirResistPercent},
                    {EffectsEnum.Effect_213, PlayerFields.FireResistPercent},
                    {EffectsEnum.Effect_244, PlayerFields.NeutralElementReduction},
                    {EffectsEnum.Effect_240, PlayerFields.EarthElementReduction},
                    {EffectsEnum.Effect_241, PlayerFields.WaterElementReduction},
                    {EffectsEnum.Effect_242, PlayerFields.AirElementReduction},
                    {EffectsEnum.Effect_243, PlayerFields.FireElementReduction},
                    {EffectsEnum.Effect_416, PlayerFields.PushDamageReduction},
                    {EffectsEnum.Effect_420, PlayerFields.CriticalDamageReduction},
                    {EffectsEnum.Effect_254, PlayerFields.PvpNeutralResistPercent},
                    {EffectsEnum.Effect_250, PlayerFields.PvpEarthResistPercent},
                    {EffectsEnum.Effect_251, PlayerFields.PvpWaterResistPercent},
                    {EffectsEnum.Effect_252, PlayerFields.PvpAirResistPercent},
                    {EffectsEnum.Effect_253, PlayerFields.PvpFireResistPercent},
                    {EffectsEnum.Effect_264, PlayerFields.PvpNeutralElementReduction},
                    {EffectsEnum.Effect_260, PlayerFields.PvpEarthElementReduction},
                    {EffectsEnum.Effect_261, PlayerFields.PvpWaterElementReduction},
                    {EffectsEnum.Effect_262, PlayerFields.PvpAirElementReduction},
                    {EffectsEnum.Effect_263, PlayerFields.PvpFireElementReduction},
                    {EffectsEnum.Effect_164, PlayerFields.GlobalDamageReduction},
                    {EffectsEnum.Effect_114, PlayerFields.DamageMultiplicator},
                    {EffectsEnum.Effect_137, PlayerFields.PhysicalDamage},
                    {EffectsEnum.Effect_142, PlayerFields.PhysicalDamage},
                    //{EffectsEnum.Effect_AddMagicDamage,PlayerFields.MagicDamage},
                    {EffectsEnum.Effect_184, PlayerFields.PhysicalDamageReduction},
                    {EffectsEnum.Effect_183, PlayerFields.MagicDamageReduction},
                    {EffectsEnum.Effect_158, PlayerFields.Weight},
                    {EffectsEnum.Effect_2800, PlayerFields.MeleeDamageDonePercent},
                    {EffectsEnum.Effect_2803, PlayerFields.MeleeDamageReceivedPercent},
                    {EffectsEnum.Effect_2804, PlayerFields.RangedDamageDonePercent},
                    {EffectsEnum.Effect_2807, PlayerFields.RangedDamageReceivedPercent},
                    {EffectsEnum.Effect_2808, PlayerFields.WeaponDamageDonePercent},
                    {EffectsEnum.Effect_2811, PlayerFields.WeaponDamageReceivedPercent},
                    {EffectsEnum.Effect_2812, PlayerFields.SpellDamageDonePercent},
                    {EffectsEnum.Effect_2815, PlayerFields.SpellDamageReceivedPercent}
                };

        private  readonly Dictionary<EffectsEnum, PlayerFields> m_subEffectsBinds =
            new Dictionary<EffectsEnum, PlayerFields>
                {
                    //EffectsEnum.Effect_SubHealth,PlayerFields.Health},
                    {EffectsEnum.Effect_175, PlayerFields.Initiative},
                    {EffectsEnum.Effect_177, PlayerFields.Prospecting},
                    {EffectsEnum.Effect_168, PlayerFields.AP},
                    {EffectsEnum.Effect_169, PlayerFields.MP},
                    {EffectsEnum.Effect_157, PlayerFields.Strength},
                    {EffectsEnum.Effect_153, PlayerFields.Vitality},
                    {EffectsEnum.Effect_156, PlayerFields.Wisdom},
                    {EffectsEnum.Effect_152, PlayerFields.Chance},
                    {EffectsEnum.Effect_154, PlayerFields.Agility},
                    {EffectsEnum.Effect_155, PlayerFields.Intelligence},
                    {EffectsEnum.Effect_116, PlayerFields.Range},
                    //{EffectsEnum.Effect_SubSummonLimit,PlayerFields.SummonLimit},
                    //{EffectsEnum.Effect_SubDamageReflection,PlayerFields.DamageReflection},
                    {EffectsEnum.Effect_171, PlayerFields.CriticalHit},
                    //{EffectsEnum.Effect_SubCriticalMiss,PlayerFields.CriticalMiss},
                    {EffectsEnum.Effect_179, PlayerFields.HealBonus},
                    {EffectsEnum.Effect_145, PlayerFields.DamageBonus},
                    //{EffectsEnum.Effect_SubWeaponDamageBonus,PlayerFields.WeaponDamageBonus},
                    {EffectsEnum.Effect_186, PlayerFields.DamageBonusPercent},
                    //{EffectsEnum.Effect_SubTrapBonus,PlayerFields.TrapBonus},
                    //{EffectsEnum.Effect_SubPermanentDamagePercent,PlayerFields.PermanentDamagePercent},
                    {EffectsEnum.Effect_755,PlayerFields.TackleBlock},
                    {EffectsEnum.Effect_754,PlayerFields.TackleEvade},
                    {EffectsEnum.Effect_411,PlayerFields.APAttack},
                    {EffectsEnum.Effect_413,PlayerFields.MPAttack},
                    {EffectsEnum.Effect_415, PlayerFields.PushDamageBonus},
                    {EffectsEnum.Effect_419, PlayerFields.CriticalDamageBonus},
                    {EffectsEnum.Effect_431, PlayerFields.NeutralDamageBonus},
                    {EffectsEnum.Effect_423, PlayerFields.EarthDamageBonus},
                    {EffectsEnum.Effect_427, PlayerFields.WaterDamageBonus},
                    {EffectsEnum.Effect_429, PlayerFields.AirDamageBonus},
                    {EffectsEnum.Effect_425, PlayerFields.FireDamageBonus},
                    {EffectsEnum.Effect_162, PlayerFields.DodgeAPProbability},
                    {EffectsEnum.Effect_163, PlayerFields.DodgeMPProbability},
                    {EffectsEnum.Effect_219, PlayerFields.NeutralResistPercent},
                    {EffectsEnum.Effect_215, PlayerFields.EarthResistPercent},
                    {EffectsEnum.Effect_216, PlayerFields.WaterResistPercent},
                    {EffectsEnum.Effect_217, PlayerFields.AirResistPercent},
                    {EffectsEnum.Effect_218, PlayerFields.FireResistPercent},
                    {EffectsEnum.Effect_249, PlayerFields.NeutralElementReduction},
                    {EffectsEnum.Effect_245, PlayerFields.EarthElementReduction},
                    {EffectsEnum.Effect_246, PlayerFields.WaterElementReduction},
                    {EffectsEnum.Effect_247, PlayerFields.AirElementReduction},
                    {EffectsEnum.Effect_248, PlayerFields.FireElementReduction},
                    {EffectsEnum.Effect_417, PlayerFields.PushDamageReduction},
                    {EffectsEnum.Effect_421, PlayerFields.CriticalDamageReduction},
                    {EffectsEnum.Effect_259, PlayerFields.PvpNeutralResistPercent},
                    {EffectsEnum.Effect_255, PlayerFields.PvpEarthResistPercent},
                    {EffectsEnum.Effect_256, PlayerFields.PvpWaterResistPercent},
                    {EffectsEnum.Effect_257, PlayerFields.PvpAirResistPercent},
                    {EffectsEnum.Effect_258, PlayerFields.PvpFireResistPercent},
                    //{EffectsEnum.Effect_SubPvpNeutralElementReduction, PlayerFields.PvpNeutralElementReduction},
                    //{EffectsEnum.Effect_SubPvpEarthElementReduction, PlayerFields.PvpEarthElementReduction},
                    //{EffectsEnum.Effect_SubPvpWaterElementReduction, PlayerFields.PvpWaterElementReduction},
                    //{EffectsEnum.Effect_SubPvpAirElementReduction, PlayerFields.PvpAirElementReduction},
                    //{EffectsEnum.Effect_SubPvpFireElementReduction, PlayerFields.PvpFireElementReduction},
                    //{EffectsEnum.Effect_SubGlobalDamageReduction, PlayerFields.GlobalDamageReduction},
                    //{EffectsEnum.Effect_SubDamageMultiplicator, PlayerFields.DamageMultiplicator},
                    //{EffectsEnum.Effect_SubPhysicalDamage, PlayerFields.PhysicalDamage},
                    //{EffectsEnum.Effect_SubMagicDamage, PlayerFields.MagicDamage},
                    {EffectsEnum.Effect_173, PlayerFields.PhysicalDamageReduction},
                    {EffectsEnum.Effect_172, PlayerFields.MagicDamageReduction},
                    {EffectsEnum.Effect_159, PlayerFields.Weight},
                    {EffectsEnum.Effect_2801, PlayerFields.MeleeDamageDonePercent},
                    {EffectsEnum.Effect_2802, PlayerFields.MeleeDamageReceivedPercent},
                    {EffectsEnum.Effect_2805, PlayerFields.RangedDamageDonePercent},
                    {EffectsEnum.Effect_2806, PlayerFields.RangedDamageReceivedPercent},
                    {EffectsEnum.Effect_2809, PlayerFields.WeaponDamageDonePercent},
                    {EffectsEnum.Effect_2810, PlayerFields.WeaponDamageReceivedPercent},
                    {EffectsEnum.Effect_2813, PlayerFields.SpellDamageDonePercent},
                    {EffectsEnum.Effect_2814, PlayerFields.SpellDamageReceivedPercent}
                };

        #endregion

        public DefaultItemEffect(EffectBase effect, Character target, BasePlayerItem item)
            : base(effect, target, item)
        {
        }

        public DefaultItemEffect(EffectBase effect, Character target, ItemSetTemplate itemSet, bool apply) 
            : base(effect, target, itemSet, apply)
        {
        }
        protected override bool InternalApply()
        {
            if (!(Effect is EffectInteger))
                return false;

            EffectComputeHandler handler;

            PlayerFields caracteritic;
            if (m_addEffectsBinds.ContainsKey(Effect.EffectId))
            {
                caracteritic = m_addEffectsBinds[Effect.EffectId];

                if (!m_addMethods.ContainsKey(caracteritic) ||
                    !m_subMethods.ContainsKey(caracteritic))
                    return false;

                handler = Operation == HandlerOperation.APPLY ? m_addMethods[caracteritic] : m_subMethods[caracteritic];
            }
            else if (m_subEffectsBinds.ContainsKey(Effect.EffectId))
            {
                caracteritic = m_subEffectsBinds[Effect.EffectId];

                if (!m_addMethods.ContainsKey(caracteritic) ||
                    !m_subMethods.ContainsKey(caracteritic))
                    return false;

                handler = Operation == HandlerOperation.APPLY ? m_subMethods[caracteritic] : m_addMethods[caracteritic];
            }
            else
            {
                return false;
            }

            if (handler != null)
                handler(Target, (EffectInteger) Effect, Boost, Efficiency);

            return true;
        }

        #region Add Methods

        private static void AddHealth(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.Health].Equiped += (int) Math.Floor(effect.Value*efficiency);
        }

        private static void AddInitiative(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Initiative].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddProspecting(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Prospecting].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddAP(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.AP].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddMP(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.MP].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddStrength(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Strength].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddVitality(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Vitality].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddWisdom(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Wisdom].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddChance(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Chance].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddAgility(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Agility].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddIntelligence(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Intelligence].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddRange(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Range].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddSummonLimit(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.SummonLimit].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddDamageReflection(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.DamageReflection].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddCriticalHit(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.CriticalHit].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddCriticalMiss(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.CriticalMiss].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddHealBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.HealBonus].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.DamageBonus].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddWeaponDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.WeaponDamageBonus].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddDamageBonusPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.DamageBonusPercent].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddTrapBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.TrapBonus].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddTrapBonusPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.TrapBonusPercent].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddPermanentDamagePercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PermanentDamagePercent].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddTackleBlock(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.TackleBlock].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddTackleEvade(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.TackleEvade].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddAPAttack(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.APAttack].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddMPAttack(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.MPAttack].Equiped += (int) Math.Floor(effect.Value*efficiency);
        }

        private static void AddPushDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PushDamageBonus].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddCriticalDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.CriticalDamageBonus].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddNeutralDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.NeutralDamageBonus].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddEarthDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.EarthDamageBonus].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddWaterDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.WaterDamageBonus].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddAirDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.AirDamageBonus].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddFireDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.FireDamageBonus].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddDodgeAPProbability(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.DodgeAPProbability].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddDodgeMPProbability(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.DodgeMPProbability].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddNeutralResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.NeutralResistPercent].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddEarthResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.EarthResistPercent].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddWaterResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.WaterResistPercent].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddAirResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.AirResistPercent].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddFireResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.FireResistPercent].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddNeutralElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.NeutralElementReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddEarthElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.EarthElementReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddWaterElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.WaterElementReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddAirElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.AirElementReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddFireElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.FireElementReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddPushDamageReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PushDamageReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddCriticalDamageReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.CriticalDamageReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddPvpNeutralResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpNeutralResistPercent].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddPvpEarthResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpEarthResistPercent].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddPvpWaterResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpWaterResistPercent].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddPvpAirResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpAirResistPercent].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddPvpFireResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpFireResistPercent].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddPvpNeutralElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpNeutralElementReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddPvpEarthElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpEarthElementReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddPvpWaterElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpWaterElementReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddPvpAirElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpAirElementReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddPvpFireElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpFireElementReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddGlobalDamageReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.GlobalDamageReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddDamageMultiplicator(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.DamageMultiplicator].Equiped += ((int)Math.Floor(effect.Value*efficiency) * 100);
        }

        private static void AddPhysicalDamage(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PhysicalDamage].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddMagicDamage(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.MagicDamage].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddPhysicalDamageReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PhysicalDamageReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddMagicDamageReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.MagicDamageReduction].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddWeight(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Weight].Equiped += (int)Math.Floor(effect.Value*efficiency);
        }

        private static void AddMeeleDamage(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.MeleeDamageDonePercent].Equiped += (int)Math.Floor(effect.Value * efficiency);
        }

        private static void AddMeeleResistence(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.MeleeDamageReceivedPercent].Equiped += (int)Math.Floor(effect.Value * efficiency);
        }

        private static void AddRangedDamage(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.RangedDamageDonePercent].Equiped += (int)Math.Floor(effect.Value * efficiency);
        }

        private static void AddRangedResistence(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.RangedDamageReceivedPercent].Equiped += (int)Math.Floor(effect.Value * efficiency);
        }

        private static void AddWeaponDamage(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.WeaponDamageDonePercent].Equiped += (int)Math.Floor(effect.Value * efficiency);
        }

        private static void AddWeaponResistence(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.WeaponDamageReceivedPercent].Equiped += (int)Math.Floor(effect.Value * efficiency);
        }

        private static void AddSpellDamage(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.SpellDamageDonePercent].Equiped += (int)Math.Floor(effect.Value * efficiency);
        }

        private static void AddSpellResistence(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.SpellDamageReceivedPercent].Equiped += (int)Math.Floor(effect.Value * efficiency);
        }
        
        #endregion

        #region Sub Methods

        private static void SubHealth(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Health].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubInitiative(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Initiative].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubProspecting(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Prospecting].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubAP(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.AP].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubMP(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.MP].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubStrength(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Strength].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubVitality(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Vitality].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubWisdom(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Wisdom].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubChance(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Chance].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubAgility(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Agility].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubIntelligence(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Intelligence].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubRange(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Range].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubSummonLimit(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.SummonLimit].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubDamageReflection(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.DamageReflection].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubCriticalHit(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.CriticalHit].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubCriticalMiss(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.CriticalMiss].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubHealBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.HealBonus].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.DamageBonus].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubWeaponDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.WeaponDamageBonus].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubDamageBonusPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.DamageBonusPercent].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubTrapBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.TrapBonus].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubTrapBonusPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.TrapBonusPercent].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubPermanentDamagePercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PermanentDamagePercent].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubTackleBlock(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.TackleBlock].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubTackleEvade(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.TackleEvade].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubAPAttack(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.APAttack].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubMPAttack(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.MPAttack].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubPushDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PushDamageBonus].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubCriticalDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.CriticalDamageBonus].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubNeutralDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.NeutralDamageBonus].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubEarthDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.EarthDamageBonus].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubWaterDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.WaterDamageBonus].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubAirDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.AirDamageBonus].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubFireDamageBonus(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.FireDamageBonus].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubDodgeAPProbability(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.DodgeAPProbability].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubDodgeMPProbability(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.DodgeMPProbability].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubNeutralResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.NeutralResistPercent].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubEarthResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.EarthResistPercent].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubWaterResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.WaterResistPercent].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubAirResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.AirResistPercent].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubFireResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.FireResistPercent].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubNeutralElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.NeutralElementReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubEarthElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.EarthElementReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubWaterElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.WaterElementReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubAirElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.AirElementReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubFireElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.FireElementReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubPushDamageReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PushDamageReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubCriticalDamageReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.CriticalDamageReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubPvpNeutralResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpNeutralResistPercent].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubPvpEarthResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpEarthResistPercent].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubPvpWaterResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpWaterResistPercent].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubPvpAirResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpAirResistPercent].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubPvpFireResistPercent(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpFireResistPercent].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubPvpNeutralElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpNeutralElementReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubPvpEarthElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpEarthElementReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubPvpWaterElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpWaterElementReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubPvpAirElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpAirElementReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubPvpFireElementReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PvpFireElementReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubGlobalDamageReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.GlobalDamageReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubDamageMultiplicator(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.DamageMultiplicator].Equiped -= ((int)Math.Floor(effect.Value*efficiency) * 100);
        }

        private static void SubPhysicalDamage(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PhysicalDamage].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubMagicDamage(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.MagicDamage].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubPhysicalDamageReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.PhysicalDamageReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubMagicDamageReduction(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.MagicDamageReduction].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubWeight(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
             target.Stats[PlayerFields.Weight].Equiped -= (int)Math.Floor(effect.Value*efficiency);
        }

        private static void SubMeeleDamage(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.MeleeDamageDonePercent].Equiped -= (int)Math.Floor(effect.Value * efficiency);
        }

        private static void SubMeeleResistence(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.MeleeDamageReceivedPercent].Equiped -= (int)Math.Floor(effect.Value * efficiency);
        }

        private static void SubRangedDamage(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.RangedDamageDonePercent].Equiped -= (int)Math.Floor(effect.Value * efficiency);
        }

        private static void SubRangedResistence(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.RangedDamageReceivedPercent].Equiped -= (int)Math.Floor(effect.Value * efficiency);
        }

        private static void SubWeaponDamage(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.WeaponDamageDonePercent].Equiped -= (int)Math.Floor(effect.Value * efficiency);
        }

        private static void SubWeaponResistence(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.WeaponDamageReceivedPercent].Equiped -= (int)Math.Floor(effect.Value * efficiency);
        }

        private static void SubSpellDamage(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.SpellDamageDonePercent].Equiped -= (int)Math.Floor(effect.Value * efficiency);
        }

        private static void SubSpellResistence(Character target, EffectInteger effect, bool isBoost, double efficiency)
        {
            target.Stats[PlayerFields.SpellDamageReceivedPercent].Equiped -= (int)Math.Floor(effect.Value * efficiency);
        }

        #endregion
    }
}