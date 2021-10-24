using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{

    [ChallengeIdentifier((int)ChallengeEnum.HALOUINE_CHALLENGE_CHRONO)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_SOMNAMBULES_CHALLENGE_CHRONO)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_FATIGUES_CHALLENGE_CHRONO)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_CHALLENGE_CHRONO)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_EPUISES_CHALLENGE_CHRONO)]

    public class ChronoChallenge : DefaultChallenge
    {


        public ChronoChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 0;
            BonusMax = 0;
        }

        public override void Initialize()
        {
            base.Initialize();

            Fight.TurnStarted += OnTurnStarted;
        }

        void OnTurnStarted(IFight fight, FightActor fighter)
        {
            if (!(fighter is CharacterFighter))
                return;

            if ((Fight.TimeLine.RoundNumber) >= 9)
                UpdateStatus(ChallengeStatusEnum.FAILED, fighter);
        }


        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            base.OnWinnersDetermined(fight, winners, losers, draw);
            Fight.TurnStarted -= OnTurnStarted;
        }
    }
}
