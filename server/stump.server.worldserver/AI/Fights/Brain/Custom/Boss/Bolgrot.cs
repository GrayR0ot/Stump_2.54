using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Boss
{
    [BrainIdentifier((int) MonsterIdEnum.ESPRIT_DE_BOLGROT)]
    public class Bolgrot : Brain
    {
        public Bolgrot(AIFighter fighter)
            : base(fighter)
        {
            fighter.Fight.FightStarted += Fight_FightStarted;
            fighter.Fight.TurnStarted += OnTurnStarted;
        }

        private void Fight_FightStarted(IFight obj)
        {
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.BOLGROT_S_FIRE, 2), Fighter.Cell);
            Fighter.Stats[PlayerFields.SummonLimit].Additional = 9999;
            var bosscell = Fighter.Fight.Map.GetRandomAdjacentFreeCell(Fighter.Cell);
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.BOLGROT_S_FIRE, 3), bosscell);
        }

        private void OnTurnStarted(IFight obj, FightActor actor)
        {
            if (!(actor is SummonedMonster))
            {
                var cell = Fighter.Fight.Map.GetRandomFreeCell();
                Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.BOLGROT_S_FIRE, 3), cell);
            }

            foreach (var entry in Fighter.Fight.GetAllFighters<MonsterFighter>())
                if (entry is MonsterFighter)
                    if (entry.Monster.Template.Id == 4045 && !(actor is SummonedMonster) &&
                        !(actor is CharacterFighter))
                        entry.CastAutoSpell(new Spell((int) SpellIdEnum.BOLGROT_S_FIRE, 4), entry.Cell);
        }
    }
}