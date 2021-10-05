﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Effects;
using Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Damage;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Fights;

namespace Stump.Server.WorldServer.Game.Spells.Casts.Ocra
{
    //[SpellCastHandler(SpellIdEnum.TYRANNICAL_ARROW_9315)]
    //public class FlechaTiranica : DefaultSpellCastHandler
    //{
    //    public FlechaTiranica(SpellCastInformations cast) : base(cast)
    //    {

    //    }

    //    public override void Execute()
    //    {
    //        Handlers[0].Duration = 2;
    //        Handlers[0].Effect.Duration = 2;
    //        Handlers[0].Apply();

    //        Handlers[1].Duration = 2;
    //        Handlers[1].Effect.Duration = 2;
    //        Handlers[1].Apply();

    //        Handlers[2].Duration = 2;
    //        Handlers[2].Effect.Duration = 2;
    //        Handlers[2].Apply();

    //        Handlers[3].Duration = 2;
    //        Handlers[3].Effect.Duration = 2;
    //        Handlers[3].Apply();
    //    }
    //}

    //[SpellCastHandler(SpellIdEnum.SENTINEL_9320)]
    //public class Sentinel : DefaultSpellCastHandler
    //{
    //    public Sentinel(SpellCastInformations cast) : base(cast)
    //    {

    //    }

    //    public override void Execute()
    //    {
    //        var s = Handlers;
    //        base.Execute();
    //    }
    //}

    [SpellCastHandler(SpellIdEnum.TYRANNICAL_ARROW_9517)]
    public class FlechaTiranicaFuego : DefaultSpellCastHandler
    {
        public FlechaTiranicaFuego(SpellCastInformations cast) : base(cast)
        {
        }

        public override void Execute()
        {
            var target = Fight.GetOneFighter(TargetedCell);
            var buff = target.GetBuffs().Where(x => x.Dice.Id == 99).FirstOrDefault();

            if (buff != null)
                target.RemoveBuff(buff);

            buff = target.GetBuffs().Where(x => x.Dice.Id == 98).FirstOrDefault();
            if (buff != null)
                target.RemoveBuff(buff);

            var effect = new EffectDice(EffectsEnum.Effect_DamageFire, 12, 12, 12);
            var actorBuffId = Caster.PopNextBuffId();
            var handler = EffectManager.Instance.GetSpellEffectHandler(effect, Caster, this, TargetedCell, Critical);

            var buff2 = new DirectDamage(effect, Caster, this, TargetedCell, false);
            buff2.Apply();
        }
    }

    [SpellCastHandler(SpellIdEnum.TYRANNICAL_ARROW)]
    public class FlechaTiranicaAire : DefaultSpellCastHandler
    {
        public FlechaTiranicaAire(SpellCastInformations cast) : base(cast)
        {

        }

        public override void Execute()
        {
            var target = Fight.GetOneFighter(TargetedCell);
            var buff = target.GetBuffs().Where(x => x.Dice.Id == 99).FirstOrDefault();

            if (buff != null)
                target.RemoveBuff(buff);

            buff = target.GetBuffs().Where(x => x.Dice.Id == 98).FirstOrDefault();
            if (buff != null)
                target.RemoveBuff(buff);

            var effect = new EffectDice(EffectsEnum.Effect_DamageAir, 12, 12, 12);
            var actorBuffId = Caster.PopNextBuffId();
            var handler = EffectManager.Instance.GetSpellEffectHandler(effect, Caster, this, TargetedCell, Critical);

            var buff2 = new DirectDamage(effect, Caster, this, TargetedCell, false);
            buff2.Apply();
        }
    }
}