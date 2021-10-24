using Stump.Core.Collections;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Database.Items.Templates;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;
using Stump.Server.WorldServer.Game.Spells.Casts;
using System.Collections.Generic;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.VERSATILE)]
    [ChallengeIdentifier((int)ChallengeEnum.MOB_LEPONGE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.BATOFU_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.SHIN_LARVE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.DRAGON_COCHON_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.MOON_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.GROLLOUM_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.HAREBOURG_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.SOLAR_CHALLENGE_1)]
    public class VersatileChallenge : DefaultChallenge
    {
        readonly List<Pair<FightActor, int>> m_weaponsUsed = new List<Pair<FightActor, int>>();

        public VersatileChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 50;
            BonusMax = 85;

        }

        public override void Initialize()
        {
            base.Initialize();

            foreach (var fighter in Fight.GetAllFighters<CharacterFighter>())
            {
                fighter.SpellCasting += OnSpellCasting;
                fighter.WeaponUsed += OnWeaponUsed;
            }
        }

        void OnWeaponUsed(FightActor fighter, WeaponTemplate weapon, Cell cell, FightSpellCastCriticalEnum critical, bool silentCast)
        {
            if (critical == FightSpellCastCriticalEnum.CRITICAL_FAIL)
                return;
            if (fighter is CharacterFighter)
            {
                if (m_weaponsUsed.Any(x => x.First == fighter && x.Second == Fight.TimeLine.RoundNumber))
                    UpdateStatus(ChallengeStatusEnum.FAILED);
                else
                    m_weaponsUsed.Add(new Pair<FightActor, int>(fighter, Fight.TimeLine.RoundNumber));
            }

        }

        void OnSpellCasting(FightActor caster, SpellCastHandler castHandler)
        {
            if (caster is CharacterFighter)
            {
                if (castHandler.Informations.Critical == FightSpellCastCriticalEnum.CRITICAL_FAIL || !(caster is CharacterFighter) || !(caster as CharacterFighter).Character.Spells.Any(x => x.Id == castHandler.Spell.Id))
                    return;

                var entries = caster.SpellHistory.GetEntries(x => x.Spell.SpellId == castHandler.Spell.Id && x.CastRound == Fight.TimeLine.RoundNumber);

                if (!entries.Any())
                    return;

                UpdateStatus(ChallengeStatusEnum.FAILED);
            }
        }

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            base.OnWinnersDetermined(fight, winners, losers, draw);

            foreach (var fighter in Fight.GetAllFighters<CharacterFighter>())
            {
                fighter.SpellCasting -= OnSpellCasting;
                fighter.WeaponUsed -= OnWeaponUsed;
            }
        }
    }
}
