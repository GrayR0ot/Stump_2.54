//using System.Linq;
//using Stump.DofusProtocol.Enums;
//using Stump.Server.WorldServer.AI.Fights.Actions;
//using Stump.Server.WorldServer.Game.Actors.Fight;
//using Stump.Server.WorldServer.Game.Effects.Handlers.Spells.States;
//using Stump.Server.WorldServer.Game.Effects.Instances;
//using Stump.Server.WorldServer.Game.Fights;
//using Stump.Server.WorldServer.Game.Fights.Buffs;
//using Stump.Server.WorldServer.Game.Spells;
//using TreeSharp;

//namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Boss
//{
//    [BrainIdentifier((int)MonsterIdEnum.SOLAR)]
//    public class Solar : Brain
//    {
//        public Solar(AIFighter fighter) : base(fighter)
//        {
//            fighter.Fight.FightStarted += Fight_FightStarted;
//        }

//        private void Fight_FightStarted(IFight obj)
//        {
//            Fighter.CastAutoSpell(new Spell((int)9436, (byte)Fighter.Level), Fighter.Cell);
//        }

//        public override void Play()
//        {
//            foreach (var spell in Fighter.Spells.Values)
//            {
//                var target = Environment.GetNearestEnemy();

//                var selector = new PrioritySelector();

//                selector.AddChild(new Decorator(ctx => target == null, new DecoratorContinue(new RandomMove(Fighter))));
//                selector.AddChild(new Decorator(ctx => spell == null, new DecoratorContinue(new FleeAction(Fighter))));

//                if (target != null && spell != null)
//                {
//                    selector.AddChild(new PrioritySelector(
//                        new Decorator(ctx => Fighter.CanCastSpell(spell, target.Cell) == SpellCastResult.OK,
//                            new Sequence(
//                                new SpellCastAction(Fighter, spell, target.Cell, true),
//                                new Decorator(new MoveNearTo(Fighter, target)))),
//                        new Sequence(
//                            new MoveNearTo(Fighter, target),
//                            new Decorator(
//                                ctx => Fighter.CanCastSpell(spell, target.Cell) == SpellCastResult.OK,
//                                new Sequence(
//                                    new SpellCastAction(Fighter, spell, target.Cell, true))))));
//                }

//                foreach (var action in selector.Execute(this))
//                {

//                }
//            }
//        }
//    }
//}

