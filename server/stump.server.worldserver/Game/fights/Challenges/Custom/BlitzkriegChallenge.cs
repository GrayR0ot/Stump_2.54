using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.BLITZKRIEG)]
    [ChallengeIdentifier((int)ChallengeEnum.BOUFTOU_ROYAL_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.CORAILLEUR_MAGISTRAL_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.WA_WABBIT_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.WA_WOBOT_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.MALLEFISK_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.RAT_NOIR_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.POUNICHEUR_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.CROCABULIA_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.SKEUNK_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.FRAKTALE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.EL_PIKO_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.KRALAMOUR_GEANT_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.BWORKER_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.GROLLOUM_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.CAPITAINE_MENO_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_FATIGUES_CHALLENGE_2)]
    public class BlitzkriegChallenge : DefaultChallenge
    {
        public BlitzkriegChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 80;
            BonusMax = 125;
        }

        public override void Initialize()
        {
            base.Initialize();

            foreach (var fighter in Fight.GetAllFighters<MonsterFighter>())
                fighter.BeforeDamageInflicted += OnBeforeDamageInflicted;

            Fight.TurnStarted += OnTurnStarted;
        }

        public override bool IsEligible() => Fight.GetAllFighters<MonsterFighter>().Count() > 1;

        void OnBeforeDamageInflicted(FightActor fighter, Damage damage)
        {
            if (fighter.IsFriendlyWith(damage.Source))
                return;

            Target = fighter;
        }

        void OnTurnStarted(IFight fight, FightActor fighter)
        {
            if (fighter == Target)
                UpdateStatus(ChallengeStatusEnum.FAILED);
        }

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            base.OnWinnersDetermined(fight, winners, losers, draw);

            foreach (var fighter in Fight.GetAllFighters<MonsterFighter>())
                fighter.BeforeDamageInflicted -= OnBeforeDamageInflicted;

            Fight.TurnStarted -= OnTurnStarted;
        }
    }
}
