using System;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Boss
{
    [BrainIdentifier((int) MonsterIdEnum.BETHEL_AKARNA)]
    public class Bethel : Brain
    {
        public Bethel(AIFighter fighter)
            : base(fighter)
        {
            fighter.Fight.FightStarted += Fight_FightStarted;
            fighter.Fight.TurnStarted += OnTurnStarted;
        }

        private void Fight_FightStarted(IFight obj)
        {
            var cell1 = Fighter.Fight.Map.GetRandomAdjacentFreeCell(Fighter.Cell, true);
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.CONTRAT_INDICIBLE_9542, 1), cell1);
            Fighter.Stats[PlayerFields.SummonLimit].Additional = 9999;
        }

        private void OnTurnStarted(IFight obj, FightActor actor)
        {
            {
                var monsters = Fighter.Fight.GetAllFighters<MonsterFighter>(x => x.Position.Point.IsInMap());
                foreach (var entry in monsters) // TOUS LES MOB
                    if (entry.Monster.Template.Id != 5110) // SAUF BETHEL
                        foreach (var states in entry.GetStates())
                        {
                            Console.WriteLine("Debug State +" + states.State.Id);
                            if (states.State.Id == 571) //AYANT L'ETAT
                            {
                                return;
                            }

                            if (entry.IsDead()) entry.Revive(100, Fighter);
                        }

                foreach (var summoned in Fighter.Fight.GetAllFighters<SummonedMonster>())
                    if (summoned is SummonedMonster)
                        if (summoned.Monster.Template.Id == 5122)
                            if (summoned.IsAlive())
                                Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.SCEAU_DINVULNERABILITE_9153, 1),
                                    Fighter.Cell);
            }
        }
    }
}