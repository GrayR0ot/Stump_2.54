﻿using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Summons
{
    [BrainIdentifier((int) MonsterIdEnum.EGIDE)]
    public class EgideBrain : Brain
    {
        public EgideBrain(AIFighter fighter) : base(fighter)
        {
            fighter.Team.FighterAdded += OnFighterAdded;
        }

        private void OnFighterAdded(FightTeam team, FightActor fighter)
        {
            if (fighter != Fighter)
                return;

            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.SANCTUARY, 1), Fighter.Cell);
        }
    }
}