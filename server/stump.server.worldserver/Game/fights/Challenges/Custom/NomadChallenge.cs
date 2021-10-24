using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.NOMADE)]
    [ChallengeIdentifier((int)ChallengeEnum.CHAFER_RONIN_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.COFFRE_DES_FORGERONS_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.ABRAKNYDE_ANCESTRAL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.LE_CHOUQUE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.KRALAMOUR_GEANT_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.MISSIZ_FRIZZ_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.KLIME_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_FATIGUES_CHALLENGE_1)]

    [ChallengeIdentifier((int)ChallengeEnum.PETULANT)]
    public class NomadChallenge : DefaultChallenge
    {

        static readonly int[] Nomade =
        {
            (int)ChallengeEnum.NOMADE,
            (int)ChallengeEnum.CHAFER_RONIN_CHALLENGE_1,
            (int)ChallengeEnum.COFFRE_DES_FORGERONS_CHALLENGE_1,
            (int)ChallengeEnum.ABRAKNYDE_ANCESTRAL_CHALLENGE_1,
            (int)ChallengeEnum.LE_CHOUQUE_CHALLENGE_2,
            (int)ChallengeEnum.KRALAMOUR_GEANT_CHALLENGE_1,
            (int)ChallengeEnum.MISSIZ_FRIZZ_CHALLENGE_1,
            (int)ChallengeEnum.KLIME_CHALLENGE_2,
            (int)ChallengeEnum.GROZILLA_ET_GRASMERA_FATIGUES_CHALLENGE_1,
        };

        public NomadChallenge(int id, IFight fight)
            : base(id, fight)
        {
            if (Nomade.Contains(id))
            {
                BonusMin = 20;
                BonusMax = 55;
            }
            else
            {
                BonusMin = 10;
                BonusMax = 10;
            }
        }

        public override void Initialize()
        {
            base.Initialize();

            Fight.BeforeTurnStopped += OnTurnStopped;
            Fight.Tackled += OnTackled;
        }

        private void OnTackled(FightActor fighter, int apTackled, int mpTackled)
        {
            if (!(fighter is CharacterFighter))
                return;

            Fight.Tackled -= OnTackled;
            UpdateStatus(ChallengeStatusEnum.FAILED, fighter);
        }

        private void OnTurnStopped(IFight fight, FightActor fighter)
        {
            if (fighter.IsDead())
                return;

            if (!(fighter is CharacterFighter))
                return;

            if (Nomade.Contains(Id) && fighter.MP <= 0)
                return;

            if (Id == (int)ChallengeEnum.PETULANT && fighter.AP <= 0)
                return;

            UpdateStatus(ChallengeStatusEnum.FAILED);
            Fight.BeforeTurnStopped -= OnTurnStopped;
        }

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            OnTurnStopped(fight, fight.FighterPlaying);

            base.OnWinnersDetermined(fight, winners, losers, draw);

            Fight.BeforeTurnStopped -= OnTurnStopped;
            Fight.Tackled -= OnTackled;
        }
    }
}
