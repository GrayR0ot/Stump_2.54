using System;
using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Fights.Buffs;
using Stump.Server.WorldServer.Handlers.Actions;
using Spell = Stump.Server.WorldServer.Game.Spells.Spell;

using Stump.Server.WorldServer.Game.Spells.Casts;
namespace Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Damage
{
    [EffectHandler(EffectsEnum.Effect_87)]
    [EffectHandler(EffectsEnum.Effect_86)]
    [EffectHandler(EffectsEnum.Effect_88)]
    [EffectHandler(EffectsEnum.Effect_85)]
    [EffectHandler(EffectsEnum.Effect_89)]
    [EffectHandler(EffectsEnum.Effect_671)]
    public class DamagePercent : SpellEffectHandler
    {
        public DamagePercent(EffectDice effect, FightActor caster, SpellCastHandler castHandler, Cell targetedCell, bool critical)
            : base(effect, caster, castHandler, targetedCell, critical)
        {
        }

        protected override bool InternalApply()
        {
            foreach (var actor in GetAffectedActors().ToArray())
            {
                if (Effect.Duration != 0 || Effect.Delay != 0)
                {
                    AddTriggerBuff(actor, DamageBuffTrigger);
                }
                else
                {
                    var damage = new Fights.Damage(Dice, GetEffectSchool(Dice.EffectId), Caster, Spell, TargetedCell, EffectZone);
                    damage.GenerateDamages();
                    damage.Amount = (int)Math.Floor((Caster.LifePoints * Dice.DiceNum) / 100d);
                    damage.IgnoreDamageBoost = true;
                    damage.MarkTrigger = MarkTrigger;
                    damage.IsCritical = Critical;

                    // spell reflected
                    var buff = actor.GetBestReflectionBuff();
                    if (buff != null && buff.ReflectedLevel >= Spell.CurrentLevel && Spell.Template.Id != 0)
                    {
                        NotifySpellReflected(actor);
                        damage.Source = Caster;
                        damage.ReflectedDamages = true;
                        Caster.InflictDamage(damage);

                        actor.RemoveBuff(buff);
                    }
                    else
                    {
                        actor.InflictDamage(damage);
                    }
                }
            }

            return true;
        }

        void DamageBuffTrigger(TriggerBuff buff, FightActor triggerrer, BuffTriggerType trigger, object token)
        {
            var triggerDmg = token as Fights.Damage;

            if (triggerDmg == null)
                return;

            if (triggerDmg.ReflectedDamages)
                return;

            var damage = new Fights.Damage(buff.Dice, GetEffectSchool(buff.Dice.EffectId), buff.Target, buff.Spell, buff.Target.Cell)
            {
                Buff = buff,
                ReflectedDamages = true,
                IsCritical = Critical,
                MarkTrigger = MarkTrigger,
                IgnoreDamageBoost = true
            };

            damage.GenerateDamages();
            damage.Amount = (int)((buff.Target.LifePoints * (buff.Dice.DiceNum / 100.0)));

            buff.Target.InflictDamage(damage);

        }

        void NotifySpellReflected(FightActor source)
        {
            ActionsHandler.SendGameActionFightReflectSpellMessage(Fight.Clients, Caster, source);
        }

        static EffectSchoolEnum GetEffectSchool(EffectsEnum effect)
        {
            switch (effect)
            {
                case EffectsEnum.Effect_87:
                    return EffectSchoolEnum.Water;
                case EffectsEnum.Effect_86:
                    return EffectSchoolEnum.Earth;
                case EffectsEnum.Effect_88:
                    return EffectSchoolEnum.Air;
                case EffectsEnum.Effect_85:
                    return EffectSchoolEnum.Fire;
                case EffectsEnum.Effect_89:
                case EffectsEnum.Effect_671:
                    return EffectSchoolEnum.Neutral;
                default:
                    throw new Exception(string.Format("Effect {0} has not associated School Type", effect));
            }
        }
    }
}