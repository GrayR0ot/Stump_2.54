using D2pReader.MapInformations;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Effects;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Fights.Buffs;
using System;
using System.Collections.Generic;

namespace Stump.Server.WorldServer.Game.Spells.Casts
{
    [SpellCastHandler(9089)]
    public class DofusIvoire2 : DefaultSpellCastHandler
    {
        public DofusIvoire2(SpellCastInformations cast)
            : base(cast)
        {
        }

        public override void Execute()
        {

            foreach (var handler in Handlers)
            {
                handler.DefaultDispellableStatus = FightDispellableEnum.DISPELLABLE_BY_DEATH;
                handler.Apply();
            }
        }
    }

    [SpellCastHandler(6828)]
    public class Aby : DefaultSpellCastHandler
    {
        public Aby(SpellCastInformations cast)
            : base(cast)
        {
        }

        public override void Execute()
        {
            if (Fight.TimeLine.RoundNumber == 1 && !Caster.Abyssal)
            {
                Caster.Abyssal = true;
                EffectDice dice = new EffectDice(EffectsEnum.Effect_AddMP, 1, 0, 0);
                var cells = Caster.Position.Point.GetAdjacentCells();
                foreach (var cell in cells)
                {
                    var f = Fight.GetOneFighter(Map.GetCell(cell.CellId));
                    if (f != null)
                    {
                        if (f.IsEnnemyWith(Caster)) dice = new EffectDice(EffectsEnum.Effect_AddAP_111, 1, 0, 0);
                    }
                }
                var hand = EffectManager.Instance.GetSpellEffectHandler(dice, Caster, this, Caster.Cell, false);
                hand.DefaultDispellableStatus = FightDispellableEnum.REALLY_NOT_DISPELLABLE; // tocheck
                hand.Apply();
            }
            foreach (var handler in Handlers)
            {
                handler.DefaultDispellableStatus = FightDispellableEnum.DISPELLABLE_BY_DEATH;
                handler.Apply();
            }
        }
    }
    [SpellCastHandler(3646)]
    public class Galactic : DefaultSpellCastHandler
    {
        public Galactic(SpellCastInformations cast)
            : base(cast)
        {

        }

        public override void Execute()
        {

            var player = Fight.GetOneFighter(TargetedCell);
            List<Buff> buffToRemove = new List<Buff>();
            foreach (var buff in player.GetBuffs())
            {
                if (buff.Spell != null)
                {
                    if (buff.Spell.Id == 3646)
                    {
                        buff.Duration = 0;
                        buff.Dispell();
                        buffToRemove.Add(buff);
                    }
                }
            }
            buffToRemove.ForEach(x => player.RemoveBuff(x));
            List<Buff> buffs = new List<Buff>();
            var spell = new Spell(3646, (short)1);

            var hppercent = ((double)player.Stats.Health.Total / player.Stats.Health.TotalMax) * 100;
            var percentage = Convert.ToInt32(Math.Round(hppercent, 0));
            if (!(player.HasState(8)))
            {

                if (percentage >= 76)
                {
                    var effectHandler1 = EffectManager.Instance.GetSpellEffectHandler(new EffectDice(EffectsEnum.Effect_AddShield, 0, 0, 0), player, this, player.Cell, false);
                    var buffEffect1 = new StatBuff(Caster.PopNextBuffId(), Caster, Caster, effectHandler1, Spell, 200, PlayerFields.Shield, false, FightDispellableEnum.NOT_DISPELLABLE) { Duration = -1 };
                    Caster.AddBuff(buffEffect1);
                }
                else if (percentage >= 51 && percentage <= 75)
                {
                    var effectHandler0 = EffectManager.Instance.GetSpellEffectHandler(new EffectDice(EffectsEnum.Effect_AddCriticalDamageReduction, 0, 0, 0), player, this, player.Cell, false);
                    var buffEffect0 = new StatBuff(Caster.PopNextBuffId(), Caster, Caster, effectHandler0, Spell, 30, PlayerFields.CriticalDamageReduction, false, FightDispellableEnum.NOT_DISPELLABLE) { Duration = -1 };
                    Caster.AddBuff(buffEffect0);
                }
                else if (percentage >= 16 && percentage <= 50)
                {
                    var effectHandler0 = EffectManager.Instance.GetSpellEffectHandler(new EffectDice(EffectsEnum.Effect_IncreaseFinalDamages, 0, 0, 0), player, this, player.Cell, false);
                    var buffEffect0 = new StatBuff(Caster.PopNextBuffId(), Caster, Caster, effectHandler0, Spell, 5, PlayerFields.DamageBonusPercent, false, FightDispellableEnum.NOT_DISPELLABLE) { Duration = -1 };
                    Caster.AddBuff(buffEffect0);
                }
                else if (percentage <= 15)
                {
                    var effectHandler0 = EffectManager.Instance.GetSpellEffectHandler(new EffectDice(EffectsEnum.Effect_IncreaseFinalDamages, 0, 0, 0), player, this, player.Cell, false);
                    var buffEffect0 = new StatBuff(Caster.PopNextBuffId(), Caster, Caster, effectHandler0, Spell, 10, PlayerFields.DamageBonusPercent, false, FightDispellableEnum.NOT_DISPELLABLE) { Duration = -1 };
                    Caster.AddBuff(buffEffect0);
                }
                foreach (var buff in buffs)
                {
                    player.AddBuff(buff);
                    buff.Duration = 1;
                    buff.Apply();

                }
            }

        }
    }


}
