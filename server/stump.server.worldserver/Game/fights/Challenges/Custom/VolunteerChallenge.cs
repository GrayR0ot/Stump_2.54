using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.DESIGNE_VOLONTAIRE)]
    [ChallengeIdentifier((int)ChallengeEnum.KARDORIM_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.TOURNESOL_AFFAME_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.CHAFER_RONIN_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.BWORKETTE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.COFFRE_DES_FORGERONS_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.KANNIBOUL_EBIL_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.CRAQUELEUR_LEGENDAIRE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.DAÏGORO_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.REINE_NYEE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.ABRAKNYDE_ANCESTRAL_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.MEULOU_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.SILF_LE_RASBOUL_MAJEUR_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.MAÎTRE_CORBAC_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.RAT_BLANC_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.ROYALMOUTH_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.MAÎTRE_PANDORE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.HAUTE_TRUCHE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.CHENE_MOU_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.KIMBO_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.MINOTOT_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.OBSIDIANTRE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.KANIGROULA_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.USH_GALESH_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.TENGU_GIVREFOUX_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.PERE_VER_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.KOLOSSO_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.GLOURSELESTE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.OMBRE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.COMTE_RAZOF_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.ROI_NIDAS_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.REINE_DES_VOLEURS_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.ANERICE_LA_SHUSHESS_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.DAZAK_MARTEGEL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.GOURLO_LE_TERRIBLE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_EPUISES_CHALLENGE_1)]

    public class VolunteerChallenge : DefaultChallenge
    {
        public VolunteerChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 30;
            BonusMax = 60;
        }

        public override void Initialize()
        {
            base.Initialize();

            Target = Fight.GetRandomFighter<MonsterFighter>();

            foreach (var fighter in Target.Team.Fighters)
                fighter.Dead += OnDead;
        }

        public override bool IsEligible() => Fight.GetAllFighters<MonsterFighter>().Count() > 1;

        void OnDead(FightActor victim, FightActor killer)
        {
            if (victim == Target)
                UpdateStatus(ChallengeStatusEnum.SUCCESS);

            UpdateStatus(ChallengeStatusEnum.FAILED);
        }

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            base.OnWinnersDetermined(fight, winners, losers, draw);

            foreach (var fighter in Target.Team.Fighters)
                fighter.Dead -= OnDead;
        }
    }
}
