//using Stump.DofusProtocol.Enums;
//using Stump.Server.WorldServer.Game.Actors.Fight;
//using Stump.Server.WorldServer.Game.Fights;
//using Stump.Server.WorldServer.Game.Fights.Buffs;

//namespace Stump.Server.WorldServer.Game.Spells.Casts.Monsters
//{
//    [SpellCastHandler(SpellIdEnum.CALL_OF_THE_DEEP_SEA_6793)]
//    public class MenoCastHandler : DefaultSpellCastHandler
//    {
//        public MenoCastHandler(SpellCastInformations cast)
//            : base(cast)
//        {
//        }

//        public override void Execute()
//        {
//            if (!m_initialized)
//                Initialize();

//            var buffId = Caster.PopNextBuffId();
//            var effect = Spell.CurrentSpellLevel.Effects[0];

//            var buff = new TriggerBuff(buffId, Caster, Caster, Handlers[0], Spell, Spell, false, FightDispellableEnum.DISPELLABLE_BY_DEATH, 0, SpellBuffTrigger);
//        }

//        private void SpellBuffTrigger(TriggerBuff buff, FightActor triggerrer, BuffTriggerType trigger, object token)
//        {
//            Handlers[0].Apply();
//        }
//    }
//}
