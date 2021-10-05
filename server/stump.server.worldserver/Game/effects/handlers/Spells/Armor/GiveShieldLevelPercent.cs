﻿using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Spells.Casts;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Armor
{
    [EffectHandler(EffectsEnum.Effect_AddShieldLevelPercent)]
    public class GiveShieldLevelPercent : SpellEffectHandler
    {
        public GiveShieldLevelPercent(EffectDice effect, FightActor caster, SpellCastHandler castHandler, Cell targetedCell, bool critical)
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

                if (actor.Stats[PlayerFields.Shield].Context < 0)
                    actor.Stats[PlayerFields.Shield].Context = 0;

                var shieldAmount = (short)(Caster.Level * (integerEffect.Value / 100d));

                if(Caster.Level > 200)
                {
                    shieldAmount = (short)(200 * (integerEffect.Value / 100d));
                }

                if (Effect.Duration != 0 || Effect.Delay != 0)
                {
                    AddStatBuff(actor, shieldAmount, PlayerFields.Shield, (short)EffectsEnum.Effect_AddShield);
                }
                else
                {
                    actor.Stats[PlayerFields.Shield].Context += shieldAmount;
                }
            }

            return true;
        }
    }
}
