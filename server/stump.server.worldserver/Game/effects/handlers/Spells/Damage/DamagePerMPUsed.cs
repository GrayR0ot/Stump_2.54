using System;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Fights.Buffs;
using Stump.Server.WorldServer.Game.Spells;

using Stump.Server.WorldServer.Game.Spells.Casts;
namespace Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Damage
{
    [EffectHandler(EffectsEnum.Effect_1136)] 
    [EffectHandler(EffectsEnum.Effect_1140)]
    [EffectHandler(EffectsEnum.Effect_1138)]
    [EffectHandler(EffectsEnum.Effect_1137)]
    [EffectHandler(EffectsEnum.Effect_1139)]
    public class DamagePerMPUsed : SpellEffectHandler
    {
        public DamagePerMPUsed(EffectDice effect, FightActor caster, SpellCastHandler castHandler, Cell targetedCell, bool critical)
            : base(effect, caster, castHandler, targetedCell, critical)
        {
        }

        protected override bool InternalApply()
        {
            foreach (var actor in GetAffectedActors())
            {
                AddTriggerBuff(actor, BuffTriggerType.OnTurnEnd, OnBuffTriggered);
            }

            return true;
        }

        void OnBuffTriggered(TriggerBuff buff, FightActor triggerrer, BuffTriggerType trigger, object token)
        {
            var usedMP = buff.Target.UsedMP;
            if (usedMP <= 0)
                return;

            var damages = new Fights.Damage(Dice)
            {
                Source = buff.Caster,
                Buff = buff,
                School = GetEffectSchool(buff.Dice.EffectId),
                MarkTrigger = MarkTrigger,
                IsCritical = Critical,
                Spell = buff.Spell
            };

            damages.GenerateDamages();
            damages.Amount = usedMP * damages.BaseMaxDamages;

            buff.Target.InflictDamage(damages);
        }

        static EffectSchoolEnum GetEffectSchool(EffectsEnum effect)
        {
            switch (effect)
            {
                case EffectsEnum.Effect_1137:
                    return EffectSchoolEnum.Water;
                case EffectsEnum.Effect_1140:
                    return EffectSchoolEnum.Earth;
                case EffectsEnum.Effect_1136:
                    return EffectSchoolEnum.Air;
                case EffectsEnum.Effect_1138:
                    return EffectSchoolEnum.Fire;
                case EffectsEnum.Effect_1139:
                    return EffectSchoolEnum.Neutral;
                default:
                    throw new Exception(string.Format("Effect {0} has not associated School Type", effect));
            }
        }
    }
}