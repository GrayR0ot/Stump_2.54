using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.ZOMBIE)]
    [ChallengeIdentifier((int)ChallengeEnum.KARDORIM_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.SCARABOSSE_DORE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.KWAKWA_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.KANNIBOUL_EBIL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.MANTISCORE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.KOULOSSE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.TYNRIL_AHURI_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.USH_GALESH_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.PERE_VER_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.KORRIANDRE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.BETHEL_AKARNA_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_CHALLENGE_1)]

    public class ZombieChallenge : DefaultChallenge
    {
        public ZombieChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 30;
            BonusMax = 50;
        }

        public override void Initialize()
        {
            base.Initialize();

            Fight.BeforeTurnStopped += OnBeforeTurnStopped;
        }

        private void OnBeforeTurnStopped(IFight fight, FightActor fighter)
        {
            if (!(fighter is CharacterFighter))
                return;

            if (fighter.UsedMP == 1)
                return;

            UpdateStatus(ChallengeStatusEnum.FAILED);
            Fight.BeforeTurnStopped -= OnBeforeTurnStopped;
        }

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            OnBeforeTurnStopped(fight, fight.FighterPlaying);

            base.OnWinnersDetermined(fight, winners, losers, draw);

            Fight.BeforeTurnStopped -= OnBeforeTurnStopped;
        }
    }
}
