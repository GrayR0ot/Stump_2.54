using System.Linq;
using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.ANACHORETE)]
    [ChallengeIdentifier((int)ChallengeEnum.MOB_LEPONGE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.BOOSTACHE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.BWORKETTE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.BULBIG_BROZEUR_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.NELWEEN_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.CRAQUELEUR_LEGENDAIRE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.DAÏGORO_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.MINOTOROR_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.FRAKTALE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.TOXOLIATH_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.SYLARGH_CHALLENGE_1)]

    [ChallengeIdentifier((int)ChallengeEnum.PUSILLANIME)]
    [ChallengeIdentifier((int)ChallengeEnum.BOUFTOU_ROYAL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.SHIN_LARVE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_COCO_ROYAL_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_GRIOTTE_ROYAL_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_INDIGO_ROYAL_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_REINETTE_ROYAL_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.DAÏGORO_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.KLIME_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.NILEZA_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.CHALŒIL_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.CAPITAINE_MENO_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.LARVE_DE_KOUTOULOU_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.ANERICE_LA_SHUSHESS_CHALLENGE_1)]
    public class HermitChallenge : DefaultChallenge
    {
        readonly FightTeam m_team;

        static readonly int[] Anacho =
        {
            (int)ChallengeEnum.ANACHORETE,
            (int)ChallengeEnum.MOB_LEPONGE_CHALLENGE_1,
            (int)ChallengeEnum.BOOSTACHE_CHALLENGE_1,
            (int)ChallengeEnum.BWORKETTE_CHALLENGE_1,
            (int)ChallengeEnum.BULBIG_BROZEUR_CHALLENGE_1,
            (int)ChallengeEnum.NELWEEN_CHALLENGE_2,
            (int)ChallengeEnum.CRAQUELEUR_LEGENDAIRE_CHALLENGE_1,
            (int)ChallengeEnum.DAÏGORO_CHALLENGE_1,
            (int)ChallengeEnum.MINOTOROR_CHALLENGE_1,
            (int)ChallengeEnum.FRAKTALE_CHALLENGE_1,
            (int)ChallengeEnum.TOXOLIATH_CHALLENGE_2,
            (int)ChallengeEnum.SYLARGH_CHALLENGE_1,
        };

        public HermitChallenge(int id, IFight fight)
            : base(id, fight)
        {
            if (id == (int)ChallengeEnum.ANACHORETE)
            {
                BonusMin = 20;
                BonusMax = 30;
            }
            else
            {
                BonusMin = 30;
                BonusMax = 30;  
            }

            m_team = Fight.DefendersTeam is FightMonsterTeam ? Fight.DefendersTeam : Fight.ChallengersTeam;
            if (Anacho.Contains(id))
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
            if (!(fighter is CharacterFighter) || fighter.IsDead())
                return;

            if (!fighter.Position.Point.GetAdjacentCells(x => m_team.GetOneFighter(y => y.IsAlive() && y.Cell == Fight.Map.GetCell(x)) != null).Any())
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
