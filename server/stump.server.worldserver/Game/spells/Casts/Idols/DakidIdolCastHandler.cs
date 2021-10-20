using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Effects.Handlers.Spells;
using Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Buffs;
using Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Damage;
using Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Move;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Fights.Buffs;
using Stump.Server.WorldServer.Game.Fights.Triggers;
using Stump.Server.WorldServer.Game.Maps.Cells.Shapes;

namespace Stump.Server.WorldServer.Game.Spells.Casts.Idols
{
    //[SpellCastHandler(5909)]
    //public class YocheIdolCastHandler : DefaultSpellCastHandler
    //{
    //    public YocheIdolCastHandler(SpellCastInformations cast)
    //        : base(cast)
    //    {
    //    }

    //    public override void Execute()
    //    {
    //        Handlers[0].DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //        foreach (SpellEffectHandler handler in Handlers)
    //        {
    //            Handlers[0].DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;

    //            foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                Handlers[0].AddTriggerBuff(monster, BuffTriggerType.OnDamagedByEnemy, Yoche);
    //        }
    //    }

    //    public void Yoche(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //    {
    //        if (token != null)
    //        {
    //            if (Caster != null)
    //            {
    //                FightActor target = Fight.GetOneFighter((token as Damage).TargetCell);
    //                if (trigerrer != null && trigerrer.Position != null && trigerrer.Position.Point != null) { }
    //                {
    //                    if (trigerrer.Position.Point.IsAdjacentTo(buff.Target.Position.Point) || trigerrer.Fight.DefendersTeam.Fighters.Contains(trigerrer))
    //                        return;
    //                    {
    //                        short percentage = default;
    //                        var damage = token as Damage;

    //                        switch (Spell.CurrentLevel)
    //                        {
    //                            case 1:
    //                                percentage = 10;
    //                                break;
    //                            case 2:
    //                                percentage = 20;
    //                                break;
    //                            case 3:
    //                                percentage = 40;
    //                                break;
    //                            case 4:
    //                                percentage = 80;
    //                                break;
    //                        }


    //                        var effectHandler = new StatsBuff(new EffectDice(EffectsEnum.Effect_IncreaseFinalDamages, 0, 0, 0),
    //                            buff.Target, this, buff.Target.Cell, false);
    //                        var buffEffect = new StatBuff(Caster.PopNextBuffId(), buff.Target, buff.Target, effectHandler, Spell,
    //                            percentage, PlayerFields.DamageMultiplicator, false, FightDispellableEnum.NOT_DISPELLABLE)
    //                        {
    //                            Duration = -1
    //                        };
    //                        buff.Target.AddBuff(buffEffect);

    //                    }
    //                }
    //            }
    //        }
    //    }

    //[SpellCastHandler(12680)]
    //public class VaudeIdolCastHandler : DefaultSpellCastHandler
    //{
    //    public VaudeIdolCastHandler(SpellCastInformations cast)
    //        : base(cast)
    //    {
    //    }

    //    public override void Execute()
    //    {
    //        Handlers[0].DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //        foreach (FightActor fighter in Fight.GetAllFighters(x => x.Team.Id == TeamEnum.TEAM_CHALLENGER))
    //            Handlers[0].AddTriggerBuff(fighter, BuffTriggerType.OnTurnEnd, Vaude);
    //    }

    //    public void Vaude(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //    {
    //        Cell[] cells = new Cross(0, 63).GetCells(buff.Target.Cell, buff.Target.Map);
    //        IEnumerable<FightActor> fighters = Fight.GetAllFighters(cells)
    //                                                .Where(x => x.Team.Id == TeamEnum.TEAM_CHALLENGER &&
    //                                                            x != trigerrer);

    //        foreach (FightActor fighter in fighters)
    //            fighter.IsFriendlyWith(Caster);
    //        new EffectDice(EffectsEnum.Effect_AddShield, 100, 0, 0);

    //        foreach (var handler in Handlers)
    //        {
    //            handler.DefaultDispellableStatus = FightDispellableEnum.DISPELLABLE_BY_DEATH;
    //            handler.Apply();
    //        }
    //    }

    //}

    //    [SpellCastHandler(SpellIdEnum.TELEB_5917)]
    //    public class TelebIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public TelebIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            Handlers[0].DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //            foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                Handlers[0].AddTriggerBuff(monster, BuffTriggerType.OnTurnEnd, Teleb);
    //        }

    //        public void Teleb(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            short distance = 4;
    //            double percentage = default;
    //            int damageSuffered = buff.Target.DamageTakenFromLastRound;

    //            if (damageSuffered > 0)
    //            {
    //                switch (Spell.CurrentLevel)
    //                {
    //                    case 1:
    //                        percentage = 0.25;
    //                        break;
    //                    case 2:
    //                        percentage = 0.5;
    //                        break;
    //                    case 3:
    //                        percentage = 1;
    //                        break;
    //                    case 4:
    //                        distance = 6;
    //                        percentage = 1;
    //                        break;
    //                }

    //                damageSuffered += (int)(damageSuffered * percentage);

    //                foreach (FightActor fighter in Fight.GetAllFighters(x =>
    //                    x.Team.Id == TeamEnum.TEAM_CHALLENGER &&
    //                    buff.Target.Position.Point.DistanceTo(x.Position.Point) < distance))
    //                    fighter.InflictDirectDamage(damageSuffered);
    //                buff.Target.DamageTakenFromLastRound = 0;
    //            }
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.SAK_5976)]
    //    public class SakMagistralIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public SakMagistralIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            Handlers[0].DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //            foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //            {
    //                Handlers[0].AddTriggerBuff(monster, BuffTriggerType.OnTurnEnd, Sak);
    //                var effectHandler = new StatsBuff(new EffectDice(EffectsEnum.Effect_IncreaseFinalDamages, 0, 0, 0),
    //                    monster, this, monster.Cell, false);
    //                var buffEffect = new StatBuff(monster.PopNextBuffId(), monster, monster, effectHandler, Spell, 800,
    //                    PlayerFields.DamageMultiplicator, false, FightDispellableEnum.NOT_DISPELLABLE)
    //                {
    //                    Duration = -1
    //                };
    //                monster.AddBuff(buffEffect);
    //            }
    //        }

    //        public void Sak(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            var effectHandler = new StatsBuff(new EffectDice(EffectsEnum.Effect_ReduceFinalDamages, 0, 0, 0),
    //                buff.Target, this, buff.Target.Cell, false);
    //            var buffEffect = new StatBuff(buff.Target.PopNextBuffId(), buff.Target, buff.Target, effectHandler, Spell,
    //                80, PlayerFields.DamageMultiplicator, false, FightDispellableEnum.NOT_DISPELLABLE)
    //            {
    //                Duration = -1
    //            };
    //            buff.Target.AddBuff(buffEffect);
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.SAK_5977)]
    //    public class SakMajorIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public SakMajorIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            Handlers[0].DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //            foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //            {
    //                Handlers[0].AddTriggerBuff(monster, BuffTriggerType.OnTurnEnd, Sak);
    //                var effectHandler = new StatsBuff(new EffectDice(EffectsEnum.Effect_IncreaseFinalDamages, 0, 0, 0),
    //                    monster, this, monster.Cell, false);
    //                var buffEffect = new StatBuff(monster.PopNextBuffId(), monster, monster, effectHandler, Spell, 400,
    //                    PlayerFields.DamageMultiplicator, false, FightDispellableEnum.NOT_DISPELLABLE)
    //                {
    //                    Duration = -1
    //                };
    //                monster.AddBuff(buffEffect);
    //            }
    //        }

    //        public void Sak(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            var effectHandler = new StatsBuff(new EffectDice(EffectsEnum.Effect_ReduceFinalDamages, 0, 0, 0),
    //                buff.Target, this, buff.Target.Cell, false);
    //            var buffEffect = new StatBuff(buff.Target.PopNextBuffId(), buff.Target, buff.Target, effectHandler, Spell,
    //                40, PlayerFields.DamageMultiplicator, false, FightDispellableEnum.NOT_DISPELLABLE)
    //            {
    //                Duration = -1
    //            };
    //            buff.Target.AddBuff(buffEffect);
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.SAK_5978)]
    //    public class SakIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public SakIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            Handlers[0].DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //            foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //            {
    //                Handlers[0].AddTriggerBuff(monster, BuffTriggerType.OnTurnEnd, Sak);
    //                var effectHandler = new StatsBuff(new EffectDice(EffectsEnum.Effect_IncreaseFinalDamages, 0, 0, 0),
    //                    monster, this, monster.Cell, false);
    //                var buffEffect = new StatBuff(monster.PopNextBuffId(), monster, monster, effectHandler, Spell, 200,
    //                    PlayerFields.DamageMultiplicator, false, FightDispellableEnum.NOT_DISPELLABLE)
    //                {
    //                    Duration = -1
    //                };
    //                monster.AddBuff(buffEffect);
    //            }
    //        }

    //        public void Sak(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            var effectHandler = new StatsBuff(new EffectDice(EffectsEnum.Effect_ReduceFinalDamages, 0, 0, 0),
    //                buff.Target, this, buff.Target.Cell, false);
    //            var buffEffect = new StatBuff(buff.Target.PopNextBuffId(), buff.Target, buff.Target, effectHandler, Spell,
    //                20, PlayerFields.DamageMultiplicator, false, FightDispellableEnum.NOT_DISPELLABLE)
    //            {
    //                Duration = -1
    //            };
    //            buff.Target.AddBuff(buffEffect);
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.SAK_5883)]
    //    public class SakMinorIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public SakMinorIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            Handlers[0].DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //            foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //            {
    //                Handlers[0].AddTriggerBuff(monster, BuffTriggerType.OnTurnEnd, Sak);
    //                var effectHandler = new StatsBuff(new EffectDice(EffectsEnum.Effect_IncreaseFinalDamages, 0, 0, 0),
    //                    monster, this, monster.Cell, false);
    //                var buffEffect = new StatBuff(monster.PopNextBuffId(), monster, monster, effectHandler, Spell, 100,
    //                    PlayerFields.DamageMultiplicator, false, FightDispellableEnum.NOT_DISPELLABLE)
    //                {
    //                    Duration = -1
    //                };
    //                monster.AddBuff(buffEffect);
    //            }
    //        }

    //        public void Sak(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            var effectHandler = new StatsBuff(new EffectDice(EffectsEnum.Effect_ReduceFinalDamages, 0, 0, 0),
    //                buff.Target, this, buff.Target.Cell, false);
    //            var buffEffect = new StatBuff(buff.Target.PopNextBuffId(), buff.Target, buff.Target, effectHandler, Spell,
    //                10, PlayerFields.DamageMultiplicator, false, FightDispellableEnum.NOT_DISPELLABLE)
    //            {
    //                Duration = -1
    //            };
    //            buff.Target.AddBuff(buffEffect);
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.PIKMI_5921)]
    //    public class PikmiIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public PikmiIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler handler in Handlers)
    //            {
    //                handler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                    handler.AddTriggerBuff(monster, BuffTriggerType.AfterDamaged, Pikmi);
    //            }
    //        }

    //        public void Pikmi(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            double percent = default;
    //            short zone = default;
    //            int damage = (token as Damage).Amount;

    //            switch (Spell.CurrentLevel)
    //            {
    //                case 1:
    //                    zone = 2;
    //                    percent = 0.5;
    //                    break;
    //                case 2:
    //                    zone = 3;
    //                    percent = 1;
    //                    break;
    //                case 3:
    //                    zone = 3;
    //                    percent = 2;
    //                    break;
    //                case 4:
    //                    zone = 4;
    //                    percent = 2;
    //                    break;
    //            }

    //            foreach (FightActor player in Fight.GetAllFighters(x =>
    //                x.Team.Id == TeamEnum.TEAM_CHALLENGER &&
    //                buff.Target.Position.Point.DistanceTo(x.Position.Point) < zone))
    //                player.InflictDirectDamage((int)(damage * percent));
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.PENITENT)]
    //    public class PenitentIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public PenitentIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler handler in Handlers)
    //            {
    //                handler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                handler.SetAffectedActors(Fight.GetAllFighters<CharacterFighter>());
    //                handler.Apply();
    //            }
    //        }
    //    }

    //    [SpellCastHandler(5918)]
    //    public class PehoIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public PehoIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler handler in Handlers)
    //            {
    //                handler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                    handler.AddTriggerBuff(monster, BuffTriggerType.OnTurnEnd, Peho);
    //            }
    //        }

    //        public void Peho(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            short distance = default;
    //            short attract = default;

    //            switch (Spell.CurrentLevel)
    //            {
    //                case 1:
    //                    distance = 8;
    //                    attract = 1;
    //                    break;
    //                case 2:
    //                    distance = 6;
    //                    attract = 1;
    //                    break;
    //                case 3:
    //                    distance = 4;
    //                    attract = 1;
    //                    break;
    //                case 4:
    //                    distance = 4;
    //                    attract = 2;
    //                    break;
    //            }

    //            foreach (FightActor player in Fight.GetAllFighters(x =>
    //                x.Team.Id == TeamEnum.TEAM_CHALLENGER &&
    //                buff.Target.Position.Point.DistanceTo(x.Position.Point) > distance))
    //            {
    //                var effectDice = new EffectDice(EffectsEnum.Effect_PullForward, attract, 0, 0);
    //                var effect = new Push(effectDice, trigerrer, this, player.Cell, false);
    //                effect.Apply();
    //            }
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.NYORO_5870)]
    //    public class NyoroIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public NyoroIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler handler in Handlers)
    //            {
    //                handler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                    handler.AddTriggerBuff(monster, BuffTriggerType.AfterDamaged, Nyoro);
    //            }
    //        }

    //        public void Nyoro(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            FightActor target = (token as Damage).Source;
    //            double percentage = default;

    //            switch (Spell.CurrentLevel)
    //            {
    //                case 1:
    //                    percentage = 0.1;
    //                    break;
    //                case 2:
    //                    percentage = 0.25;
    //                    break;
    //                case 3:
    //                    percentage = 0.5;
    //                    break;
    //                case 4:
    //                    percentage = 1;
    //                    break;
    //            }

    //            var damageAmount = (int)((token as Damage).Amount * percentage);
    //            target.InflictDirectDamage(damageAmount);
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.NEKINEKO)]
    //    public class NekinekoIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public NekinekoIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler handler in Handlers)
    //            {
    //                handler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                    handler.AddTriggerBuff(monster, BuffTriggerType.OnDamaged, Nekineko);
    //            }
    //        }

    //        public void Nekineko(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            var effectHandler = new MPBuff(new EffectDice(EffectsEnum.Effect_AddMP, 0, 0, 0), Caster, this,
    //                buff.Target.Cell, false);
    //            var buffEffect = new StatBuff(buff.Target.PopNextBuffId(), buff.Target, buff.Target, effectHandler, Spell,
    //                1, PlayerFields.MP, false, FightDispellableEnum.NOT_DISPELLABLE)
    //            { Duration = -1 };
    //            buff.Target.AddBuff(buffEffect);
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.NAHUATL)]
    //    public class NahuatlIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public NahuatlIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            base.Execute(); /*TODO*/
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.KYOUB)]
    //    public class KyoubIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public KyoubIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler handler in Handlers)
    //            {
    //                handler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                    handler.AddTriggerBuff(monster, BuffTriggerType.BeforeDamaged, Kyoub);
    //            }
    //        }

    //        public void Kyoub(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            FightActor source = (token as Damage).Source;

    //            if (!buff.Target.Position.Point.IsAdjacentTo(source.Position.Point))
    //            {
    //                double percentage = default;
    //                var damage = token as Damage;

    //                switch (Spell.CurrentLevel)
    //                {
    //                    case 1:
    //                        percentage = 0.1;
    //                        break;
    //                    case 2:
    //                        percentage = 0.2;
    //                        break;
    //                    case 3:
    //                        percentage = 0.4;
    //                        break;
    //                    case 4:
    //                        percentage = 0.8;
    //                        break;
    //                }

    //                damage.Amount -= (int)(damage.Amount * percentage);
    //            }
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.KORRIA)]
    //    public class KorriaIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public KorriaIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            if (Fight.TimeLine.RoundNumber == 1 && Fight.TimeLine.Fighters.First() == Caster)
    //            {
    //                var effect = new EffectDice { Duration = 100 };
    //                var glyph = new Glyph((short)Fight.PopNextTriggerId(), Caster, Spell, effect, Spell, Caster.Cell,
    //                    SpellShapeEnum.empty, (byte)effect.ZoneSize, (byte)effect.ZoneSize, Color.OrangeRed, false);

    //                Fight.AddTriger(glyph);
    //                Fight.KorriaCells.Add(Caster.Cell);
    //            }

    //            foreach (SpellEffectHandler handler in Handlers)
    //            {
    //                handler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                handler.AddTriggerBuff(Caster, BuffTriggerType.OnTurnBegin, Korria);
    //                handler.AddTriggerBuff(Caster, BuffTriggerType.OnTurnEnd, Korria);
    //            }
    //        }

    //        public void Korria(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            if (trigger == BuffTriggerType.OnTurnBegin && !Fight.KorriaCells.Contains(Caster.Cell))
    //            {
    //                var effect = new EffectDice { Duration = 100 };
    //                var glyph = new Glyph((short)Fight.PopNextTriggerId(), Caster, Spell, effect, Spell, Caster.Cell,
    //                    SpellShapeEnum.empty, (byte)effect.ZoneSize, (byte)effect.ZoneSize, Color.OrangeRed, false);

    //                Fight.AddTriger(glyph);
    //                Fight.KorriaCells.Add(Caster.Cell);
    //            }
    //            else
    //            {
    //                if (Fight.KorriaCells.Contains(Caster.Cell))
    //                    Caster.Die();
    //            }
    //        }
    //    }

    //[SpellCastHandler(SpellIdEnum.HORIZ)]
    //public class HorizIdolCastHandler : DefaultSpellCastHandler
    //{
    //    public HorizIdolCastHandler(SpellCastInformations cast)
    //        : base(cast)
    //    {
    //    }

    //    public override void Execute()
    //    {
    //        foreach (SpellEffectHandler handler in Handlers)
    //        {
    //            handler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //            foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                handler.AddTriggerBuff(monster, BuffTriggerType.BeforeAttack, Horiz);
    //        }
    //    }

    //    public void Horiz(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //    {
    //        FightActor target = Fight.GetOneFighter((token as Damage).TargetCell);

    //        if (!buff.Target.Position.Point.IsAdjacentTo(target.Position.Point))
    //        {
    //            double percentage = default;
    //            var damage = token as Damage;

    //            switch (Spell.CurrentLevel)
    //            {
    //                case 1:
    //                    percentage = 0.5;
    //                    break;
    //                case 2:
    //                    percentage = 1;
    //                    break;
    //                case 3:
    //                    percentage = 2;
    //                    break;
    //                case 4:
    //                    percentage = 4;
    //                    break;
    //            }

    //            damage.Amount += (int)(damage.Amount * percentage);
    //        }
    //    }
    //}

    [SpellCastHandler(SpellIdEnum.DYNAMO_5885)]
    public class DynamoIdolCastHandler : DefaultSpellCastHandler
    {
        public DynamoIdolCastHandler(SpellCastInformations cast)
            : base(cast)
        {
        }

        public override void Execute()
        {
            var effectHandler = new MPBuff(new EffectDice(EffectsEnum.Effect_78, 0, 0, 0), Caster, this, Caster.Cell,
                false);
            var buffEffect = new StatBuff(Caster.PopNextBuffId(), Caster, Caster, effectHandler, Spell,
                    (short) Spell.CurrentLevel, PlayerFields.MP, false, FightDispellableEnum.NOT_DISPELLABLE)
                {Duration = -1};
            Caster.AddBuff(buffEffect);
        }
    }

    //    [SpellCastHandler(SpellIdEnum.DJIM)]
    //    public class DjimIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public DjimIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler handler in Handlers)
    //            {
    //                handler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                {
    //                    monster.Invulnerable = true;
    //                    handler.AddTriggerBuff(monster, BuffTriggerType.OnMoved, Djim);
    //                }
    //            }
    //        }

    //        public void Djim(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            buff.Target.Invulnerable = false;
    //            Fight.ForEach(character =>
    //            {
    //                character.SendServerMessage(
    //                    $"<b>{(trigerrer as CharacterFighter).Name}</b> désactive l'état invulnérable de <b>{(buff.Target as MonsterFighter).Name}</b>.");
    //            });

    //            var effectHandler = new StatsBuff(new EffectDice(EffectsEnum.Effect_IncreaseFinalDamages, 0, 0, 0),
    //                buff.Target, this, buff.Target.Cell, false);
    //            var buffEffect = new StatBuff(buff.Target.PopNextBuffId(), buff.Target, buff.Target, effectHandler, Spell,
    //                200, PlayerFields.DamageMultiplicator, false, FightDispellableEnum.NOT_DISPELLABLE)
    //            {
    //                Duration = -1
    //            };
    //            buff.Target.AddBuff(buffEffect);
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.CRITUS)]
    //    public class CritusIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public CritusIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                monster.Critus = true;
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.CORRODE)]
    //    public class CorrodeIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public CorrodeIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                monster.Stats[PlayerFields.Erosion].Context += 40;
    //        }
    //    }

    //    [SpellCastHandler(5911)]
    //    public class CafraIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public CafraIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler handler in Handlers)
    //            {
    //                handler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;

    //                foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                    handler.AddTriggerBuff(monster, BuffTriggerType.OnTurnBegin, Cafra);
    //            }
    //        }

    //        public void Cafra(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            short damagePercent = default;
    //            FightActor nearestEnemy = (trigerrer as MonsterFighter).Brain.Environment.GetNearestEnemy();

    //            switch (Spell.CurrentLevel)
    //            {
    //                case 1:
    //                    damagePercent = 50;
    //                    break;
    //                case 2:
    //                    damagePercent = 100;
    //                    break;
    //                case 3:
    //                    damagePercent = 200;
    //                    break;
    //                case 4:
    //                    damagePercent = 400;
    //                    break;
    //            }

    //            var effectHandler = new StatsBuff(new EffectDice(EffectsEnum.Effect_DamageMultiplier, 0, 0, 0),
    //                nearestEnemy, this, nearestEnemy.Cell, false);
    //            var buffEffect = new StatBuff(nearestEnemy.PopNextBuffId(), nearestEnemy, nearestEnemy, effectHandler,
    //                Spell, damagePercent, PlayerFields.PvpEarthResistPercent, false, FightDispellableEnum.NOT_DISPELLABLE)
    //            {
    //                Duration = 1
    //            };
    //            nearestEnemy.AddBuff(buffEffect);
    //        }
    //    }

    //[SpellCastHandler(5879)]
    //public class ButorIdolCastHandler : DefaultSpellCastHandler
    //{
    //    public ButorIdolCastHandler(SpellCastInformations cast)
    //        : base(cast)
    //    {
    //    }

    //    public override void Execute()
    //    {
    //        foreach (SpellEffectHandler handler in Handlers)
    //        {
    //            handler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;

    //            foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                handler.AddTriggerBuff(monster, BuffTriggerType.BeforeAttack, Butor);
    //        }
    //    }

    /*public void Butor(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    {
        if (token != null)
        {
            if(Fight.GetOneFighter() != null)
            {
                FightActor target = Fight.GetOneFighter((token as Damage).TargetCell);
                if (trigerrer != null && trigerrer.Position != null && trigerrer.Position.Point != null)
                {
                    if (trigerrer.Position.Point.IsAdjacentTo(target.Position.Point))
                    {
                        double percentage = default;
                        var damage = token as Damage;

                        switch (Spell.CurrentLevel)
                        {
                            case 1:
                                percentage = 0.5;
                                break;
                            case 2:
                                percentage = 1;
                                break;
                            case 3:
                                percentage = 2;
                                break;
                            case 4:
                                percentage = 4;
                                break;
                        }

                        if (damage.Amount > 0)
                        {
                            damage.Amount += (int)(damage.Amount * percentage);
                        }
                    }
                }
            }
        }
    }
}*/

    [SpellCastHandler(SpellIdEnum.BINAR_5897)]
    public class BinarIdolCastHandler : DefaultSpellCastHandler
    {
        public BinarIdolCastHandler(SpellCastInformations cast)
            : base(cast)
        {
        }

        public override void Execute()
        {
            foreach (SpellEffectHandler effect in Handlers)
            {
                effect.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
                effect.AddTriggerBuff(Caster, BuffTriggerType.OnTurnEnd, Binar);
            }
        }

        public void Binar(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
        {
            if (Caster.Cell.Id % 3 == 0)
                foreach (FightActor fighter in Fight.GetAllFighters().Where(x =>
                    x.Team.Id == TeamEnum.TEAM_CHALLENGER &&
                    x.Cell.Id % 2 == 0 && x != Caster))
                    fighter.Stats[PlayerFields.Health].Context -= (int) (fighter.MaxLifePoints * 0.3);
        }
    }

    /*[SpellCastHandler(5881)]
    public class BihileteIdolCastHandler : DefaultSpellCastHandler
    {
        public BihileteIdolCastHandler(SpellCastInformations cast)
            : base(cast)
        {
        }

        public override void Execute()
        {
            Handlers[0].SetAffectedActors(Fight.GetAllFighters<MonsterFighter>());
            base.Execute();
        }
    }*/

    //    [SpellCastHandler(SpellIdEnum.DAKID)]
    //    public class DakidIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public DakidIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler spellEffectHandler in Handlers)
    //            {
    //                spellEffectHandler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                    spellEffectHandler.AddTriggerBuff(monster, BuffTriggerType.AfterDamaged, Dakid);
    //            }
    //        }

    //        public void Dakid(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            if (buff.EffectHandler.Effect.EffectId == EffectsEnum.Effect_PullForward && buff.Target.IsAlive())
    //            {
    //                var line1 = new Line(63, false) { Direction = DirectionsEnum.DIRECTION_NORTH_EAST };
    //                var line2 = new Line(63, false) { Direction = DirectionsEnum.DIRECTION_SOUTH_EAST };
    //                var line3 = new Line(63, false) { Direction = DirectionsEnum.DIRECTION_SOUTH_WEST };
    //                var line4 = new Line(63, false) { Direction = DirectionsEnum.DIRECTION_NORTH_WEST };

    //                var line5 = new Line(63, false) { Direction = DirectionsEnum.DIRECTION_EAST };
    //                var line6 = new Line(63, false) { Direction = DirectionsEnum.DIRECTION_WEST };
    //                var line7 = new Line(63, false) { Direction = DirectionsEnum.DIRECTION_NORTH };
    //                var line8 = new Line(63, false) { Direction = DirectionsEnum.DIRECTION_SOUTH };

    //                IEnumerable<FightActor> fighters1 = Fight.GetAllFighters(line1.GetCells(buff.Target.Cell, Fight.Map))
    //                                                         .Where(x => x.Team.Id == TeamEnum.TEAM_CHALLENGER);

    //                IEnumerable<FightActor> fighters2 = Fight.GetAllFighters(line2.GetCells(buff.Target.Cell, Fight.Map))
    //                                                         .Where(x => x.Team.Id == TeamEnum.TEAM_CHALLENGER);

    //                IEnumerable<FightActor> fighters3 = Fight.GetAllFighters(line3.GetCells(buff.Target.Cell, Fight.Map))
    //                                                         .Where(x => x.Team.Id == TeamEnum.TEAM_CHALLENGER);

    //                IEnumerable<FightActor> fighters4 = Fight.GetAllFighters(line4.GetCells(buff.Target.Cell, Fight.Map))
    //                                                         .Where(x => x.Team.Id == TeamEnum.TEAM_CHALLENGER);

    //                IEnumerable<FightActor> fighters5 = Fight.GetAllFighters(line5.GetCells(buff.Target.Cell, Fight.Map))
    //                                                         .Where(x => x.Team.Id == TeamEnum.TEAM_CHALLENGER);

    //                IEnumerable<FightActor> fighters6 = Fight.GetAllFighters(line6.GetCells(buff.Target.Cell, Fight.Map))
    //                                                         .Where(x => x.Team.Id == TeamEnum.TEAM_CHALLENGER);

    //                IEnumerable<FightActor> fighters7 = Fight.GetAllFighters(line7.GetCells(buff.Target.Cell, Fight.Map))
    //                                                         .Where(x => x.Team.Id == TeamEnum.TEAM_CHALLENGER);

    //                IEnumerable<FightActor> fighters8 = Fight.GetAllFighters(line8.GetCells(buff.Target.Cell, Fight.Map))
    //                                                         .Where(x => x.Team.Id == TeamEnum.TEAM_CHALLENGER);

    //                ApplyEffect(buff, fighters1);
    //                ApplyEffect(buff, fighters2);
    //                ApplyEffect(buff, fighters3);
    //                ApplyEffect(buff, fighters4);
    //                ApplyEffect(buff, fighters5);
    //                ApplyEffect(buff, fighters6);
    //                ApplyEffect(buff, fighters7);
    //                ApplyEffect(buff, fighters8);
    //            }
    //            else
    //            {
    //                var effectHandler = new StatsBuff(new EffectDice(EffectsEnum.Effect_IncreaseFinalDamages, 20, 20, 0),
    //                    buff.Target, this, buff.Target.Cell, false);
    //                var buffEffect = new StatBuff(trigerrer.PopNextBuffId(), buff.Target, buff.Target, effectHandler, Spell,
    //                        20, PlayerFields.DamageBonusPercent, false, FightDispellableEnum.NOT_DISPELLABLE)
    //                { Duration = 1 };
    //                trigerrer.AddBuff(buffEffect);
    //            }
    //        }

    //        private void ApplyEffect(TriggerBuff buff, IEnumerable<FightActor> fighters)
    //        {
    //            for (var i = 0; i < fighters.Count(); i++)
    //            {
    //                var distance =
    //                    (short)(fighters.ElementAt(i).Position.Point.ManhattanDistanceTo(buff.Target.Position.Point) - 1);
    //                var effectDice = new EffectDice(EffectsEnum.Effect_PullForward, distance, 0, 0);
    //                FightActor attractTrigger = i == 0 ? buff.Target : fighters.ElementAt(i - 1);
    //                var effect = new Attract(effectDice, attractTrigger, this, fighters.ElementAt(i).Cell, false);
    //                effect.Apply();
    //            }
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.DAGOB)]
    //    public class DagobIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public DagobIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler spellEffectHandler in Handlers)
    //                foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                    spellEffectHandler.AddTriggerBuff(monster, BuffTriggerType.OnTurnEnd, Dagob);
    //        }

    //        private void Dagob(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            short gain = default;

    //            switch (buff.Spell.CurrentLevel)
    //            {
    //                case 1:
    //                    gain = 10;
    //                    break;
    //                case 2:
    //                    gain = 20;
    //                    break;
    //                case 3:
    //                    gain = 40;
    //                    break;
    //                case 4:
    //                    gain = 80;
    //                    break;
    //            }

    //            var effectHandler = new StatsBuff(new EffectDice(EffectsEnum.Effect_IncreaseFinalDamages, 0, 0, 0),
    //                trigerrer, this, trigerrer.Cell, false);
    //            var buffEffect = new StatBuff(trigerrer.PopNextBuffId(), trigerrer, trigerrer, effectHandler, Spell, gain,
    //                PlayerFields.DamageMultiplicator, false, FightDispellableEnum.NOT_DISPELLABLE)
    //            {
    //                Duration = -1
    //            };
    //            trigerrer.AddBuff(buffEffect);
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.NYAN)]
    //    public class NyanIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public NyanIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler spellEffectHandler in Handlers)
    //            {
    //                spellEffectHandler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                spellEffectHandler.AddTriggerBuff(Caster, BuffTriggerType.OnTurnEnd, Nyan);
    //            }
    //        }

    //        private void Nyan(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            if (trigerrer.Cell == trigerrer.TurnStartPosition.Cell)
    //            {
    //                var pv = (int)(Caster.LifePoints * 0.5);
    //                var characterFighter = Caster as CharacterFighter;
    //                characterFighter.Hoskar.AddEffect(pv, Fight.TimeLine.RoundNumber + 2);

    //                Fight.ForEach(character =>
    //                {
    //                    character.SendServerMessage($"<b>{characterFighter.Name}</b> déclenche <b>Nyan</b>.");
    //                    character.SendServerMessage($"<b>{characterFighter.Name}</b> : -{pv} PV (2 tours).");
    //                });
    //            }
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.OUGAA)]
    //    public class OugaaIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public OugaaIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler spellEffectHandler in Handlers)
    //            {
    //                spellEffectHandler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                spellEffectHandler.AddTriggerBuff(Caster, BuffTriggerType.OnTurnEnd, Ougaa);
    //            }
    //        }

    //        private void Ougaa(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            IEnumerable<MonsterFighter> monsters =
    //                Fight.GetAllFighters<MonsterFighter>(x => x.Position.Point.IsAdjacentTo(Caster.Position.Point));

    //            if (monsters.Count() > 0)
    //                Caster.Stats[PlayerFields.Health].Context -= (int)(Caster.MaxLifePoints * 0.5);
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.PROXIMA)]
    //    public class ProximaIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public ProximaIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler spellEffectHandler in Handlers)
    //            {
    //                spellEffectHandler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;

    //                foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                    spellEffectHandler.AddTriggerBuff(monster, BuffTriggerType.OnDeath, Proxima);
    //            }
    //        }

    //        private void Proxima(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            IEnumerable<CharacterFighter> fighters =
    //                Fight.GetAllFighters<CharacterFighter>(x => x.Position.Point.IsAdjacentTo(trigerrer.Position.Point));

    //            foreach (CharacterFighter fighter in fighters)
    //                fighter.Die();
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.ZAIHN_5895)]
    //    public class ZaihnIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public ZaihnIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        //public override void Execute()
    //        //{
    //        //    foreach (SpellEffectHandler spellEffectHandler in Handlers)
    //        //    {
    //        //        spellEffectHandler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;

    //        //        foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //        //            spellEffectHandler.AddTriggerBuff(monster, BuffTriggerType.OnDeath, Zaihn);
    //        //    }
    //        //}

    //        private void Zaihn(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            short distance = default;
    //            int damage = default;

    //            switch (buff.Spell.CurrentLevel)
    //            {
    //                case 1:
    //                    distance = 6;
    //                    damage = (int)(trigerrer.MaxLifePoints * 0.25);
    //                    break;
    //                case 2:
    //                    distance = 2;
    //                    damage = (int)(trigerrer.MaxLifePoints * 0.5);
    //                    break;
    //                case 3:
    //                    distance = 6;
    //                    damage = trigerrer.MaxLifePoints;
    //                    break;
    //                case 4:
    //                    distance = 4;
    //                    damage = trigerrer.MaxLifePoints;
    //                    break;
    //            }

    //            foreach (CharacterFighter player in Fight.GetAllFighters<CharacterFighter>(x =>
    //                x.Position.Point.DistanceTo(trigerrer.Position.Point) > distance))
    //                player.InflictDirectDamage(damage);
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.HULHU_5908)]
    //    public class HulhuIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public HulhuIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler spellEffectHandler in Handlers)
    //            {
    //                spellEffectHandler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                    spellEffectHandler.AddTriggerBuff(monster, BuffTriggerType.OnDeath, Hulhu);
    //            }
    //        }

    //        private void Hulhu(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            short duration = default;
    //            short gain = default;

    //            switch (buff.Spell.CurrentLevel)
    //            {
    //                case 1:
    //                    duration = 1;
    //                    gain = 1;
    //                    break;
    //                case 2:
    //                    duration = 2;
    //                    gain = 1;
    //                    break;
    //                case 3:
    //                    duration = 2;
    //                    gain = 2;
    //                    break;
    //                case 4:
    //                    duration = 2;
    //                    gain = 3;
    //                    break;
    //            }

    //            foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>(x => x.IsAlive()))
    //            {
    //                var effectHandler = new MPBuff(new EffectDice(EffectsEnum.Effect_AddMP, 0, 0, 0), Caster, this,
    //                    monster.Cell, false);
    //                var buffEffect = new StatBuff(monster.PopNextBuffId(), monster, Caster, effectHandler, Spell, gain,
    //                    PlayerFields.MP, false, FightDispellableEnum.NOT_DISPELLABLE)
    //                {
    //                    Duration = duration
    //                };
    //                monster.AddBuff(buffEffect);
    //            }
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.BOBLE_5889)]
    //    public class BobleIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public BobleIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler spellEffectHandler in Handlers)
    //            {
    //                spellEffectHandler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;

    //                foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
    //                    spellEffectHandler.AddTriggerBuff(monster, BuffTriggerType.OnDeath, Boble);
    //            }
    //        }

    //        private void Boble(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            short duration = default;
    //            short gain = default;

    //            switch (buff.Spell.CurrentLevel)
    //            {
    //                case 1:
    //                    duration = 2;
    //                    gain = 100;
    //                    break;
    //                case 2:
    //                    duration = 2;
    //                    gain = 200;
    //                    break;
    //                case 3:
    //                    duration = 2;
    //                    gain = 400;
    //                    break;
    //                case 4:
    //                    duration = 2;
    //                    gain = 800;
    //                    break;
    //            }

    //            foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>(x => x.IsAlive()))
    //            {
    //                var effectHandler = new StatsBuff(new EffectDice(EffectsEnum.Effect_IncreaseFinalDamages, 0, 0, 0),
    //                    trigerrer, this, monster.Cell, false);
    //                var buffEffect = new StatBuff(monster.PopNextBuffId(), monster, trigerrer, effectHandler, Spell, gain,
    //                    PlayerFields.DamageMultiplicator, false, FightDispellableEnum.NOT_DISPELLABLE)
    //                {
    //                    Duration = duration
    //                };
    //                monster.AddBuff(buffEffect);
    //            }
    //        }
    //    }

    [SpellCastHandler(SpellIdEnum.DOMO_5919)]
    public class DomoSpellIdolCastHandler : DefaultSpellCastHandler
    {
        public DomoSpellIdolCastHandler(SpellCastInformations cast)
            : base(cast)
        {
        }

        public override void Execute()
        {
            foreach (SpellEffectHandler spellEffectHandler in Handlers)
            {
                spellEffectHandler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
                spellEffectHandler.AddTriggerBuff(Caster, BuffTriggerType.OnTurnEnd, Domo);
            }
        }

        private void Domo(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
        {
            byte zonesize = 0;
            short gain = 0;

            switch (buff.Spell.CurrentLevel)
            {
                case 1:
                    zonesize = 1;
                    gain = 1;
                    break;
                case 2:
                    zonesize = 2;
                    gain = 1;
                    break;
                case 3:
                    zonesize = 2;
                    gain = 2;
                    break;
                case 4:
                    zonesize = 3;
                    gain = 2;
                    break;
            }

            IShape shape = new Lozenge(0, zonesize);
            Cell[] cells = shape.GetCells(Caster.Cell, Caster.Map);

            IEnumerable<FightActor> fighters = Fight.GetAllFighters(cells)
                .Where(x => x != Caster && x.Team.Id == TeamEnum.TEAM_CHALLENGER);


            if (fighters.Count() > 0)
            {
                Console.WriteLine("Debug domo 0");
                foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
                {
                    Console.WriteLine("Debug domo 1");
                    monster.AddMPContext(gain);
                }
            }
        }
    }

    //    [SpellCastHandler(SpellIdEnum.PETUNIA_5914)]
    //    public class PetuniaIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public PetuniaIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler spellEffectHandler in Handlers)
    //            {
    //                spellEffectHandler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                spellEffectHandler.AddTriggerBuff(Caster, BuffTriggerType.AfterDamaged, Petunia);
    //            }
    //        }

    //        private void Petunia(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            var damage = token as Damage;
    //            if (damage == null)
    //                return;

    //            byte zonesize = default;

    //            switch (buff.Spell.CurrentLevel)
    //            {
    //                case 1:
    //                    damage.Amount = (int)(damage.Amount * 0.5);
    //                    zonesize = 2;
    //                    break;
    //                case 2:
    //                    zonesize = 2;
    //                    break;
    //                case 3:
    //                    damage.Amount = damage.Amount * 2;
    //                    zonesize = 2;
    //                    break;
    //                case 4:
    //                    damage.Amount = damage.Amount * 2;
    //                    zonesize = 4;
    //                    break;
    //            }

    //            IShape shape = new Lozenge(0, zonesize);
    //            Cell[] cells = shape.GetCells(Caster.Cell, Caster.Map);

    //            IEnumerable<FightActor> fighters =
    //                Fight.GetAllFighters(cells).Where(x => x != Caster && x.Team.Id == TeamEnum.TEAM_CHALLENGER);


    //            foreach (FightActor fighter in fighters)
    //                fighter.InflictDirectDamage(damage.Amount);
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.AROUMB)]
    //    public class AroumbIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public AroumbIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler spellEffectHandler in Handlers)
    //            {
    //                spellEffectHandler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                spellEffectHandler.AddTriggerBuff(Caster, BuffTriggerType.OnTurnEnd, Aroumb);
    //            }
    //        }

    //        private void Aroumb(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            Cell[] cells = new Cross(0, 63).GetCells(Caster.Cell, Caster.Map);
    //            IEnumerable<FightActor> fighters = Fight.GetAllFighters(cells);

    //            foreach (MonsterFighter monster in fighters
    //                                              .Where(x => x.Team.Id != Caster.Team.Id && x.LifePoints < x.MaxLifePoints)
    //                                              .Select(x => x as MonsterFighter))
    //            {
    //                monster.Heal(monster.MaxLifePoints - monster.LifePoints, Caster);
    //                Fight.ForEach(character =>
    //                {
    //                    character.SendServerMessage($"<b>{(Caster as CharacterFighter).Name}</b> déclenche <b>Aroumb</b>.");
    //                    character.SendServerMessage(
    //                        $"<b>{monster.Name}</b> : +{monster.MaxLifePoints - monster.LifePoints} PV.");
    //                });
    //            }
    //        }
    //    }

    //    [SpellCastHandler(SpellIdEnum.HOSKAR)]
    //    public class HoskarIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public HoskarIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            foreach (SpellEffectHandler spellEffectHandler in Handlers)
    //            {
    //                spellEffectHandler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                spellEffectHandler.AddTriggerBuff(Caster, BuffTriggerType.OnTurnEnd, Hoskar);
    //            }
    //        }

    //        private void Hoskar(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            Cell[] cells = new Cross(0, 63).GetCells(buff.Target.Cell, buff.Target.Map);
    //            IEnumerable<FightActor> fighters = Fight.GetAllFighters(cells);

    //            if (fighters.Count() > 0)
    //            {
    //                var pv = (int)(Caster.LifePoints * 0.5);
    //                var characterFighter = Caster as CharacterFighter;
    //                characterFighter.Hoskar.AddEffect(pv, Fight.TimeLine.RoundNumber + 2);

    //                Fight.ForEach(character =>
    //                {
    //                    character.SendServerMessage($"<b>{characterFighter.Name}</b> déclenche <b>Hoskar</b>.");
    //                    character.SendServerMessage($"<b>{characterFighter.Name}</b> : -{pv} PV (2 tours).");
    //                });
    //            }
    //        }
    //    }

    [SpellCastHandler(SpellIdEnum.MUTA_5891)]
    public class MutaIdolCastHandler : DefaultSpellCastHandler
    {
        public MutaIdolCastHandler(SpellCastInformations cast)
            : base(cast)
        {
        }

        public override void Execute()
        {
            foreach (SpellEffectHandler spellEffectHandler in Handlers)
            {
                spellEffectHandler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
                spellEffectHandler.AddTriggerBuff(Caster, BuffTriggerType.OnTurnEnd, Muta);
            }
        }

        private void Muta(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
        {
            if (Fight.GetAllFighters(Caster.Position.Point.GetAdjacentCells().Select(x => Caster.Map.Cells[x.CellId]))
                .Where(x => x.Team == Fight.DefendersTeam).Count() == 0)
            {
                var pv = (int) (Caster.LifePoints * 0.5);
                Caster.Stats.Health.Context -= pv;
            }
        }
    }

    //    [SpellCastHandler(SpellIdEnum.ULTRAM)]
    //    public class UltramIdolCastHandler : DefaultSpellCastHandler
    //    {
    //        public UltramIdolCastHandler(SpellCastInformations cast)
    //            : base(cast)
    //        {
    //        }

    //        public override void Execute()
    //        {
    //            if (Fight.TimeLine.RoundNumber == 1)
    //            {
    //                if (Caster == Fight.TimeLine.Fighters.First() && !Fight.UltramCells.Contains(Caster.Cell))
    //                {
    //                    var effect = new EffectDice { Duration = 100 };
    //                    var glyph = new Glyph((short)Fight.PopNextTriggerId(), Caster, Spell, effect, Spell, Caster.Cell,
    //                        SpellShapeEnum.empty, (byte)effect.ZoneSize, (byte)effect.ZoneSize, Color.White, false);

    //                    Fight.AddTriger(glyph);
    //                    Fight.UltramCells.Add(Caster.Cell);
    //                }

    //                foreach (SpellEffectHandler spellEffectHandler in Handlers)
    //                {
    //                    spellEffectHandler.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
    //                    spellEffectHandler.AddTriggerBuff(Caster, BuffTriggerType.OnTurnBegin, Ultram);
    //                }
    //            }
    //        }

    //        private void Ultram(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
    //        {
    //            if (!Fight.UltramCells.Contains(Caster.Cell))
    //            {
    //                var effect = new EffectDice { Duration = 100 };
    //                var glyph = new Glyph((short)Fight.PopNextTriggerId(), Caster, Spell, effect, Spell, Caster.Cell,
    //                    SpellShapeEnum.empty, (byte)effect.ZoneSize, (byte)effect.ZoneSize, Color.White, false);

    //                Fight.AddTriger(glyph);
    //                Fight.UltramCells.Add(Caster.Cell);
    //            }
    //        }
    //    }
}