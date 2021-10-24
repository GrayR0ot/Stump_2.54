using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Actors.Stats;
using Stump.Server.WorldServer.Game.Fights.Teams;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int) ChallengeEnum.PERDU_DE_VUE)]

    // Liberty criterion
    [ChallengeIdentifier((int) ChallengeEnum.CHENE_MOU_CHALLENGE_1)]
    [ChallengeIdentifier((int) ChallengeEnum.PHOSSILE_CHALLENGE_2)]
    [ChallengeIdentifier((int) ChallengeEnum.COMTE_RAZOF_CHALLENGE_1)]
    [ChallengeIdentifier((int) ChallengeEnum.CHALŒIL_CHALLENGE_1)]
    [ChallengeIdentifier((int) ChallengeEnum.ILYZAELLE_CHALLENGE_1)]
    [ChallengeIdentifier((int) ChallengeEnum.DAZAK_MARTEGEL_CHALLENGE_1)]
    public class SightseeingChallenge : DefaultChallenge
    {
        public SightseeingChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 15;
            BonusMax = 15;
        }

        public override void Initialize()
        {
            base.Initialize();

            foreach (var fighter in Fight.GetAllFighters<MonsterFighter>())
                fighter.Stats[PlayerFields.Range].Modified += OnRangeModified;
        }

        public override bool IsEligible()
            => Fight.GetAllCharacters().Any(x => x.BreedId == PlayableBreedEnum.Enutrof ||
                                                 x.BreedId == PlayableBreedEnum.Cra);

        void OnRangeModified(StatsData stats, int amount)
        {
            if (amount >= 0)
                return;

            stats.Owner.Stats[PlayerFields.Range].Modified -= OnRangeModified;
            UpdateStatus(ChallengeStatusEnum.FAILED);
        }

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            base.OnWinnersDetermined(fight, winners, losers, draw);

            foreach (var fighter in Fight.GetAllFighters<MonsterFighter>())
                fighter.Stats[PlayerFields.Range].Modified -= OnRangeModified;
        }
    }
}
