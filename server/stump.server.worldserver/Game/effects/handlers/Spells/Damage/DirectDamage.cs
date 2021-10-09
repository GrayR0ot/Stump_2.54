using System;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Fights.Buffs;
using Stump.Server.WorldServer.Handlers.Actions;
using Spell = Stump.Server.WorldServer.Game.Spells.Spell;
using Stump.Server.WorldServer.Game.Spells.Casts;
using System.Collections.Generic;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Damage
{
    [EffectHandler(EffectsEnum.Effect_96)]
    [EffectHandler(EffectsEnum.Effect_97)]
    [EffectHandler(EffectsEnum.Effect_98)]
    [EffectHandler(EffectsEnum.Effect_99)]
    [EffectHandler(EffectsEnum.Effect_100)]
    public class DirectDamage : SpellEffectHandler
    {
        public DirectDamage(EffectDice effect, FightActor caster, SpellCastHandler castHandler, Cell targetedCell, bool critical)
            : base(effect, caster, castHandler, targetedCell, critical)
        {
            BuffTriggerType = BuffTriggerType.Unknown;
        }

        public BuffTriggerType BuffTriggerType
        {
            get;
            set;
        }

        protected override bool InternalApply()
        {
            if (IsCastByPortal)
            {
                double coef = (double)(((double)(2 * CastHandler.m_CastDistance) + 25d) / 100);
                Efficiency += coef;
            }
            foreach (var actor in GetAffectedActors())
            {
                if (Effect.Duration != 0 || Effect.Delay != 0)
                {
                    if(Caster.IsPoisonSpellCast(Spell)) BuffTriggerType = BuffTriggerType.OnTurnBegin;
                    if (BuffTriggerType == BuffTriggerType.Unknown)
                        AddTriggerBuff(actor, DamageBuffTrigger);
                    else
                        AddTriggerBuff(actor, BuffTriggerType, DamageBuffTrigger);
                }
                else
                {
                    // spell reflected
                    var buff = actor.GetBestReflectionBuff();
                    if (buff != null && buff.ReflectedLevel >= Spell.CurrentLevel
                        && Spell.Template.Id != 0 && !Caster.IsIndirectSpellCast(Spell) && !Caster.IsPoisonSpellCast(Spell))
                    {
                        NotifySpellReflected(actor);

                        var damage = new Fights.Damage(Dice, GetEffectSchool(Dice.EffectId), Caster, Spell, Caster.Cell)
                        {
                            ReflectedDamages = true,
                            MarkTrigger = MarkTrigger,
                            IsCritical = Critical
                        };
                        damage.GenerateDamages();
                        damage.Amount = (short)(damage.Amount * Efficiency);

                        Caster.InflictDamage(damage);

                        if (buff.Duration <= 0)
                            actor.RemoveBuff(buff);
                    }
                    else
                    {                        
                        var damage = new Fights.Damage(Dice, GetEffectSchool(Dice.EffectId), Caster, Spell, TargetedCell, EffectZone)
                        {
                            MarkTrigger = MarkTrigger,
                            IsCritical = Critical
                        };
                        damage.GenerateDamages();
                        damage.Amount = (short)(damage.Amount * Efficiency);

                        actor.InflictDamage(damage);
                    }
                }
            }

            return true;
        }

        void DamageBuffTrigger(TriggerBuff buff, FightActor triggerrer, BuffTriggerType trigger, object token)
        {
            var damages = token as Fights.Damage;

            if (damages != null && (damages.Spell == null || damages.ReflectedDamages))
                return;

            var damage = new Fights.Damage(buff.Dice, GetEffectSchool(Dice.EffectId), buff.Caster, null, buff.Target.Cell)
            {
                IsCritical = buff.Critical,
                ReflectedDamages = true
            };

            damage.GenerateDamages();
            damage.Amount = (short)(damage.Amount * buff.Efficiency);

            buff.Target.InflictDamage(damage);
        }

        static EffectSchoolEnum GetEffectSchool(EffectsEnum effect)
        {
            switch (effect)
            {
                case EffectsEnum.Effect_96:
                    return EffectSchoolEnum.Water;
                case EffectsEnum.Effect_97:
                    return EffectSchoolEnum.Earth;
                case EffectsEnum.Effect_98:
                    return EffectSchoolEnum.Air;
                case EffectsEnum.Effect_99:
                    return EffectSchoolEnum.Fire;
                case EffectsEnum.Effect_100:
                    return EffectSchoolEnum.Neutral;
                default:
                    throw new Exception(string.Format("Effect {0} has not associated School Type", effect));
            }
        }

        

        void NotifySpellReflected(FightActor source)
        {
            ActionsHandler.SendGameActionFightReflectSpellMessage(Fight.Clients, Caster, source);
        }
    }
}