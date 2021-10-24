using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.HARDI)]
    [ChallengeIdentifier((int)ChallengeEnum.CORAILLEUR_MAGISTRAL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.WA_WABBIT_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.REINE_NYEE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.CHOUDINI_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.DRAGON_COCHON_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.MEULOU_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.RAT_BLANC_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.RAT_NOIR_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_MULTICOLORE_ROYAL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.TANUKOUÏ_SAN_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.PEKI_PEKI_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.SPHINCTER_CELL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.PHOSSILE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.KANIGROULA_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.BWORKER_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.VORTEX_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.LARVE_DE_KOUTOULOU_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.HALOUINE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_CHALLENGE_1)]


    [ChallengeIdentifier((int)ChallengeEnum.COLLANT)]
    [ChallengeIdentifier((int)ChallengeEnum.TOURNESOL_AFFAME_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.KANKREBLATH_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.GELEE_ROYALE_BLEUE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.GELEE_ROYALE_CITRON_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.GELEE_ROYALE_FRAISE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.GELEE_ROYALE_MENTHE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.CHOUDINI_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.MAÎTRE_CORBAC_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.MAÎTRE_PANDORE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.CROCABULIA_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.OUGAH_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.GLOURSELESTE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.OMBRE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.MISSIZ_FRIZZ_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.REINE_DES_VOLEURS_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.XLII_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_EPUISES_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.MANSOT_ROYAL_CHALLENGE_2)]

    public class ImpertinenceChallenge : DefaultChallenge
    {
        private readonly FightTeam m_team;

        static readonly int[] Collant =
        {
            (int) ChallengeEnum.COLLANT,
            (int) ChallengeEnum.TOURNESOL_AFFAME_CHALLENGE_1,
            (int) ChallengeEnum.KANKREBLATH_CHALLENGE_2,
            (int) ChallengeEnum.GELEE_ROYALE_BLEUE_CHALLENGE_2,
            (int) ChallengeEnum.GELEE_ROYALE_CITRON_CHALLENGE_2,
            (int) ChallengeEnum.GELEE_ROYALE_FRAISE_CHALLENGE_2,
            (int) ChallengeEnum.GELEE_ROYALE_MENTHE_CHALLENGE_2,
            (int) ChallengeEnum.CHOUDINI_CHALLENGE_1,
            (int) ChallengeEnum.MAÎTRE_CORBAC_CHALLENGE_1,
            (int) ChallengeEnum.MAÎTRE_PANDORE_CHALLENGE_2,
            (int) ChallengeEnum.CROCABULIA_CHALLENGE_1,
            (int) ChallengeEnum.OUGAH_CHALLENGE_1,
            (int) ChallengeEnum.GLOURSELESTE_CHALLENGE_1,
            (int) ChallengeEnum.OMBRE_CHALLENGE_2,
            (int) ChallengeEnum.MISSIZ_FRIZZ_CHALLENGE_2,
            (int) ChallengeEnum.REINE_DES_VOLEURS_CHALLENGE_2,
            (int) ChallengeEnum.XLII_CHALLENGE_2,
            (int)ChallengeEnum.GROZILLA_ET_GRASMERA_EPUISES_CHALLENGE_2,
            (int)ChallengeEnum.MANSOT_ROYAL_CHALLENGE_2
        };

        public ImpertinenceChallenge(int id, IFight fight)
            : base(id, fight)
        {
            if (id == (int)ChallengeEnum.HARDI)
            {
                BonusMin = 25;
                BonusMax = 25;
            }
            else
            {
                BonusMin = 40;
                BonusMax = 40;
            }

            m_team = Fight.DefendersTeam is FightMonsterTeam ? Fight.DefendersTeam : Fight.ChallengersTeam;
            if (Collant.Contains(id))
                m_team = m_team.OpposedTeam;
        }

        public override void Initialize()
        {
            base.Initialize();

            Fight.BeforeTurnStopped += OnBeforeTurnStopped;
        }

        public override bool IsEligible() => m_team.GetAllFighters().Count() > 1;

        void OnBeforeTurnStopped(IFight fight, FightActor fighter)
        {
            if (!(fighter is CharacterFighter))
                return;

            if (fighter.Position.Point.GetAdjacentCells(x => m_team.GetOneFighter(Fight.Map.GetCell(x)) != null).Any())
                return;

            if (fighter.IsCarrying() && (m_team.GetAllFighters().Contains(fighter.GetCarriedActor()) || m_team.GetAllFighters().Contains(fighter.GetCarryingActor())))
                return;

            if (fighter.IsCarried())
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
