//using Stump.DofusProtocol.Enums;
//using Stump.Server.WorldServer.Game.Actors.Fight;
//using Stump.Server.WorldServer.Game.Fights;

//namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Boss
//{
//    [BrainIdentifier((int)MonsterIdEnum.DAGON_DES_PROFONDEURS)]
//    public class Dagon : Brain
//    {
//        public Dagon(AIFighter fighter)
//            : base(fighter)
//        {
//            fighter.Fight.FightStarted += Fight_FightStarted;
//        }

//        private void Fight_FightStarted(IFight obj)
//        {
//            //foreach (var monster in Fighter.Fight.GetAllFighters())
//            //{
//            //    if (monster is MonsterFighter)
//            //    {
//            //        MonsterFighter monsterFighter = monster as MonsterFighter;
//            //        if (monsterFighter.Monster.Template.Id == 5110)
//            //        {
//            //            monster.Invulnerable = true;
//            //        }
//            //    }
//            //}
//        }
//        public void OnBeforeDead(FightActor fighter, FightActor killer)
//        {
//            if (killer is CharacterFighter)
//            {
//                foreach (var monster in fighter.Fight.GetAllFighters())
//                {
//                    if (fighter is MonsterFighter)
//                    {
//                        MonsterFighter monsterFighter = fighter as MonsterFighter;
//                        if (monsterFighter.Monster.Template.Id == 5110)
//                        {
//                            monster.Invulnerable = false;
//                        }
//                    }
//                }
//            }
//        }

//    }
//}
