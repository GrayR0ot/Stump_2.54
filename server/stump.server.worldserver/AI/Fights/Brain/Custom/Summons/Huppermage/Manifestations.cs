﻿using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Summons
{
    [BrainIdentifier((int) MonsterIdEnum.MANIFESTATION_D_AIR)]
    public class ManifestationAir : Brain
    {
        public ManifestationAir(AIFighter fighter) : base(fighter)
        {
            fighter.Team.FighterAdded += OnFighterAdded;
        }

        private void OnFighterAdded(FightTeam team, FightActor fighter)
        {
            if (fighter != Fighter)
                return;

            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum._6223, 1), Fighter.Cell);
        }
    }

    [BrainIdentifier((int) MonsterIdEnum.MANIFESTATION_DE_FEU)]
    public class ManifestationFeu : Brain
    {
        public ManifestationFeu(AIFighter fighter) : base(fighter)
        {
            fighter.Team.FighterAdded += OnFighterAdded;
        }

        private void OnFighterAdded(FightTeam team, FightActor fighter)
        {
            if (fighter != Fighter)
                return;

            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum._9720, 1), Fighter.Cell);
        }
    }

    [BrainIdentifier((int) MonsterIdEnum.MANIFESTATION_D_EAU)]
    public class ManifestationEau : Brain
    {
        public ManifestationEau(AIFighter fighter) : base(fighter)
        {
            fighter.Team.FighterAdded += OnFighterAdded;
        }

        private void OnFighterAdded(FightTeam team, FightActor fighter)
        {
            if (fighter != Fighter)
                return;

            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum._9722, 1), Fighter.Cell);
        }
    }

    [BrainIdentifier((int) MonsterIdEnum.MANIFESTATION_DE_TERRE)]
    public class ManifestationTerre : Brain
    {
        public ManifestationTerre(AIFighter fighter) : base(fighter)
        {
            fighter.Team.FighterAdded += OnFighterAdded;
        }

        private void OnFighterAdded(FightTeam team, FightActor fighter)
        {
            if (fighter != Fighter)
                return;

            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum._9724, 1), Fighter.Cell);
        }
    }
}