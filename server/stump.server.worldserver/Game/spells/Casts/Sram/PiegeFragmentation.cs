//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Stump.DofusProtocol.Enums;
//using Stump.Server.WorldServer.Game.Effects;
//using Stump.Server.WorldServer.Game.Effects.Handlers.Spells;
//using Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Damage;
//using Stump.Server.WorldServer.Game.Effects.Instances;
//using Stump.Server.WorldServer.Game.Fights;
//using Stump.Server.WorldServer.Game.Fights.Buffs;

//namespace Stump.Server.WorldServer.Game.Spells.Casts.Sram
//{

//    [SpellCastHandler(SpellIdEnum.FRAGMENTATION_TRAP_9804)]
//    public class PiegesFragmentation : DefaultSpellCastHandler
//    {
//        public PiegesFragmentation(SpellCastInformations cast) : base(cast) { }

//        public override void Execute()
//        {
//            if (!m_initialized)
//                Initialize();

//            List<SpellEffectHandler> effects = base.Handlers.ToList();


//            Handlers = effects.ToArray();

//            var Target = Fight.GetOneFighter(TargetedCell);
//            if (Target != null)
//            {

//                var h = Handlers;

//                short potencia = (short)250;

//                var effect = new EffectDice(EffectsEnum.Effect_Trap, potencia, potencia, potencia);
//                var actorBuffId = Caster.PopNextBuffId();
//                var handler = EffectManager.Instance.GetSpellEffectHandler(effect, Caster, this, TargetedCell, Critical);


//              //  var buff = new DirectDamage(effect, Caster, this, TargetedCell, false);
//              //  buff.Apply();
//            }
//        }
//    }
//}


//////    [SpellCastHandler(SpellIdEnum.FRAGMENTATION_TRAP_9804)]
//////    public class PiegesFragmentation : DefaultSpellCastHandler
//////    {
//////        public PiegesFragmentation(SpellCastInformations cast) : base(cast) { }


//////        public override void Execute()
//////        {
//////            if (!m_initialized)
//////                Initialize();

//////            List<SpellEffectHandler> effects = base.Handlers.ToList();


//////            Handlers = effects.ToArray();

//////            var Target = Fight.GetOneFighter(TargetedCell);
//////            if (Target != null)
//////            {

//////                var h = Handlers;

//////                short potencia = (short)250;

//////                var effect = new EffectDice(EffectsEnum.Effect_AddTrapBonusPercent, potencia, potencia, potencia);
//////                var actorBuffId = Caster.PopNextBuffId();
//////                var handler = EffectManager.Instance.GetSpellEffectHandler(effect, Caster, this, TargetedCell, Critical);


//////                var buff = new StatBuff(actorBuffId, Caster, Caster, handler, Spell, potencia, PlayerFields.TrapBonus, false, FightDispellableEnum.DISPELLABLE, Caster);
//////                buff.Duration = 2;

//////                buff.Value = potencia;
//////                buff.Dice.Value = potencia;
//////                buff.Dice.DiceNum = potencia;
//////                Caster.AddBuff(buff);

//////                base.Execute();
//////            }
//////        }
//////    }
//////}