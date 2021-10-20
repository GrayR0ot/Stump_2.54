﻿using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Boss
{
    [BrainIdentifier((int) MonsterIdEnum.KORRIANDRE)]
    public class KorriandreBrain : Brain
    {
        public KorriandreBrain(AIFighter fighter)
            : base(fighter)
        {
            fighter.Fight.FightStarted += Fight_FightStarted;
        }

        private void Fight_FightStarted(IFight obj)
        {
            Fighter.Stats.Fields.FirstOrDefault(x => x.Key == PlayerFields.SummonLimit).Value.Base = 3;
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.KETE_2569, 1), Fighter.Cell);
        }

        [BrainIdentifier((int) MonsterIdEnum.SPORAKNE)]
        public class SporakneBrain : Brain
        {
            public SporakneBrain(AIFighter fighter)
                : base(fighter)
            {
                fighter.Fight.FightStarted += Fight_FightStarted;
            }

            private void Fight_FightStarted(IFight obj)
            {
                Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.HAIMJI_2495, 1), Fighter.Cell);
            }

            [BrainIdentifier((int) MonsterIdEnum.MERULETTE)]
            public class MeruletteBrain : Brain
            {
                public MeruletteBrain(AIFighter fighter)
                    : base(fighter)
                {
                    fighter.Fight.FightStarted += Fight_FightStarted;
                }

                private void Fight_FightStarted(IFight obj)
                {
                    Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.MERULE_TRAÇON_2697, 1), Fighter.Cell);
                }
            }
        }
    }
}