﻿using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Boss
{
    [BrainIdentifier((int) MonsterIdEnum.DISCIPLE_DU_KIMBO)]
    public class DiscipleDuKimboBrain : Brain
    {
        public DiscipleDuKimboBrain(AIFighter fighter)
            : base(fighter)
        {
            fighter.Fight.TurnStarted += OnTurnStarted;
        }

        private void OnTurnStarted(IFight obj, FightActor actor)
        {
            if (Fighter.IsSummoned())
            {
                if (Fighter.HasState((int) SpellStatesEnum.GLYPHE_IMPAIRE_29))
                    Fighter.CastSpell(
                        new Spell((int) SpellIdEnum.GLYPHE_IMPAIR_1073,
                            (short) (Fighter as SummonedMonster).MonsterGrade.GradeId), Fighter.Cell);
                else if (Fighter.HasState((int) SpellStatesEnum.GLYPHE_PAIRE_30))
                    Fighter.CastSpell(
                        new Spell((int) SpellIdEnum.GLYPHE_PAIR_1072,
                            (short) (Fighter as SummonedMonster).MonsterGrade.GradeId), Fighter.Cell);
            }
        }
    }
}