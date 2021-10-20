using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.AI.Fights.Actions;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Spells;
using TreeSharp;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Summons.Coffre
{
    [BrainIdentifier((int) MonsterIdEnum.TRESOR_3724)]
    public class Tresor : Brain
    {
        public Tresor(AIFighter fighter)
            : base(fighter)
        {
            fighter.Fight.FightStarted += Fight_FightStarted;
        }

        private void Fight_FightStarted(IFight obj)
        {
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.FORTUNE_8974, 6), Fighter.Cell);
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.INIMOUTH_2356, 1), Fighter.Cell);
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.TELEPATHIE_2554, 1), Fighter.Cell);
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.CLAKO_2602, 1), Fighter.Cell);
        }

        public override void Play()
        {
            foreach (var spell in Fighter.Spells.Values)
            {
                var target =
                    Environment.GetNearestFighter(
                        entry => entry.IsEnnemyWith(Fighter) && entry.IsAlive());

                var selector = new PrioritySelector();
                selector.AddChild(new Decorator(ctx => target == null, new DecoratorContinue(new RandomMove(Fighter))));
                selector.AddChild(new Decorator(ctx => spell == null, new DecoratorContinue(new FleeAction(Fighter))));

                if (target != null && spell != null)
                    selector.AddChild(new PrioritySelector(
                        new Decorator(ctx => Fighter.CanCastSpell(spell, target.Cell) == SpellCastResult.OK,
                            new Sequence(
                                new SpellCastAction(Fighter, spell, target.Cell, true),
                                new PrioritySelector(
                                    new Decorator(new FleeAction(Fighter))))),
                        new Sequence(
                            new MoveNearTo(Fighter, target),
                            new Decorator(
                                ctx => Fighter.CanCastSpell(spell, target.Cell) == SpellCastResult.OK,
                                new Sequence(
                                    new SpellCastAction(Fighter, spell, target.Cell, true))))));

                foreach (var action in selector.Execute(this))
                {
                }
            }
        }
    }
}