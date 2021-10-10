using System;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Spell = Stump.Server.WorldServer.Game.Spells.Spell;

using Stump.Server.WorldServer.Game.Spells.Casts;
namespace Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Steals
{
    [EffectHandler(EffectsEnum.Effect_266)]
    [EffectHandler(EffectsEnum.Effect_267)]
    [EffectHandler(EffectsEnum.Effect_270)]
    [EffectHandler(EffectsEnum.Effect_269)]
    [EffectHandler(EffectsEnum.Effect_268)]
    [EffectHandler(EffectsEnum.Effect_271)]
    [EffectHandler(EffectsEnum.Effect_320)]
    public class StatsSteal : SpellEffectHandler
    {
        public StatsSteal(EffectDice effect, FightActor caster, SpellCastHandler castHandler, Cell targetedCell, bool critical)
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

                var displayedEffects = GetBuffDisplayedEffect(Effect.EffectId);

                AddStatBuff(actor, (short) (-(integerEffect.Value)), GetEffectCaracteristic(Effect.EffectId), (short)displayedEffects[1]);
                AddStatBuff(Caster, (short)integerEffect.Value, GetEffectCaracteristic(Effect.EffectId), (short)displayedEffects[0]);
            }

            return true;
        }

        static PlayerFields GetEffectCaracteristic(EffectsEnum effect)
        {
            switch (effect)
            {
                case EffectsEnum.Effect_266:
                    return PlayerFields.Chance;
                case EffectsEnum.Effect_267:
                    return PlayerFields.Vitality;
                case EffectsEnum.Effect_270:
                    return PlayerFields.Wisdom;
                case EffectsEnum.Effect_269:
                    return PlayerFields.Intelligence;
                case EffectsEnum.Effect_268:
                    return PlayerFields.Agility;
                case EffectsEnum.Effect_271:
                    return PlayerFields.Strength;
                case EffectsEnum.Effect_320:
                    return PlayerFields.Range;
                default:
                    throw new Exception("No associated caracteristic to effect '" + effect + "'");
            }
        }

        static EffectsEnum[] GetBuffDisplayedEffect(EffectsEnum effect)
        {
            switch (effect)
            {
                case EffectsEnum.Effect_266:
                    return new[] { EffectsEnum.Effect_123, EffectsEnum.Effect_152 };
                case EffectsEnum.Effect_267:
                    return new[] { EffectsEnum.Effect_125, EffectsEnum.Effect_153 };
                case EffectsEnum.Effect_270:
                    return new[] { EffectsEnum.Effect_124, EffectsEnum.Effect_156 };
                case EffectsEnum.Effect_269:
                    return new[] { EffectsEnum.Effect_126, EffectsEnum.Effect_155 };
                case EffectsEnum.Effect_268:
                    return new[] { EffectsEnum.Effect_119, EffectsEnum.Effect_154 };
                case EffectsEnum.Effect_271:
                    return new[] { EffectsEnum.Effect_118, EffectsEnum.Effect_157 };
                case EffectsEnum.Effect_320:
                    return new[] { EffectsEnum.Effect_117, EffectsEnum.Effect_166 };
                default:
                    throw new Exception("No associated caracteristic to effect '" + effect + "'");
            }
        }
    }
}