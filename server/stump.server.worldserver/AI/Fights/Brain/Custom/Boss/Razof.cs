//using Stump.DofusProtocol.Enums;
//using Stump.Server.WorldServer.Game.Actors.Fight;
//using Stump.Server.WorldServer.Game.Effects;
//using Stump.Server.WorldServer.Game.Effects.Instances;
//using Stump.Server.WorldServer.Game.Fights;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Boss
//{
//    [BrainIdentifier((int)MonsterIdEnum.COMTE_RAZOF)]
//    public class Razof : Brain
//    {
//        public Razof(AIFighter fighter)
//           : base(fighter)
//        {
//            fighter.Fight.FightStarted += Fight_FightStarted;
//        }

//        private void Fight_FightStarted(IFight obj)
//        {
//        }

//        public override void Play()
//        {
//            foreach(var entity in Fighter.Fight.GetAllFighters())
//            {
//                if(entity is SummonedFighter)
//                {
//                    var airEffect = new EffectDice(EffectsEnum.Effect_AddAirResistPercent, -20, -20, -20);
//                    var handler = EffectManager.Instance.GetSpellEffectHandler(airEffect, this.Fighter, null, null, false);
//                    /*Fighter.Stats.Fields.FirstOrDefault(x => x.Key == PlayerFields.AirResistPercent).Value.);
//                    Fighter.Stats.Fields.FirstOrDefault(x => x.Key == PlayerFields.EarthResistPercent).Value.Base = 20;
//                    Fighter.Stats.Fields.FirstOrDefault(x => x.Key == PlayerFields.WaterResistPercent).Value.Base = 20;
//                    Fighter.Stats.Fields.FirstOrDefault(x => x.Key == PlayerFields.FireResistPercent).Value.Base = 20;
//                    Fighter.Stats.Fields.FirstOrDefault(x => x.Key == PlayerFields.NeutralResistPercent).Value.Base = 20;*/
//                }
//            }
//        }
//    }
//}

