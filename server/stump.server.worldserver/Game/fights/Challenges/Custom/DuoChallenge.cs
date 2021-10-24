using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.ABRAKNYDE_ANCESTRAL_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.BATOFU_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.BEN_LE_RIPATE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_COCO_ROYAL_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_GRIOTTE_ROYAL_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_INDIGO_ROYAL_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_MULTICOLORE_ROYAL_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_REINETTE_ROYAL_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.BOOSTACHE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.BOUFTOU_ROYAL_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.BULBIG_BROZEUR_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.BWORKER_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.BWORKETTE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.CHAFER_RONIN_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.CAPITAINE_EKARLATTE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.CHENE_MOU_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.COFFRE_DES_FORGERONS_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.CORAILLEUR_MAGISTRAL_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.CRAQUELEUR_LEGENDAIRE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.CROCABULIA_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.DAÏGORO_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.DRAGON_COCHON_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.FRAKTALE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.FUJI_GIVREFOUX_NOURRICIERE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.GELEE_ROYALE_BLEUE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.GELEE_ROYALE_CITRON_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.GELEE_ROYALE_FRAISE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.GELEE_ROYALE_MENTHE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.GLOURSELESTE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.GOURLO_LE_TERRIBLE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.GROLLOUM_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_FATIGUES_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_SOMNAMBULES_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_EPUISES_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.HALOUINE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.HAREBOURG_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.HAUTE_TRUCHE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.KANIGROULA_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.KANKREBLATH_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.KANNIBOUL_EBIL_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.KARDORIM_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.KIMBO_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.KLIME_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.KOLOSSO_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.KORRIANDRE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.KOULOSSE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.KRALAMOUR_GEANT_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.KWAKWA_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.MALLEFISK_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.MANSOT_ROYAL_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.MAÎTRE_CORBAC_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.MAÎTRE_DES_PANTINS_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.MAÎTRE_PANDORE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.MERKATOR_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.MEULOU_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.MINOTOROR_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.MINOTOT_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.MISSIZ_FRIZZ_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.MOB_LEPONGE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.MOON_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.NELWEEN_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.NILEZA_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.OBSIDIANTRE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.OMBRE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.OUGAH_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.PAPA_NOWEL_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.PHOSSILE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.PROTOZORREUR_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.PERE_FWETAR_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.PEKI_PEKI_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.RAT_BLANC_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.RAT_NOIR_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.REINE_NYEE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.ROYALMOUTH_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.SAPIK_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.SCARABOSSE_DORE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.SHIN_LARVE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.SILF_LE_RASBOUL_MAJEUR_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.SKEUNK_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.SPHINCTER_CELL_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.SYLARGH_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.TANUKOUÏ_SAN_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.TENGU_GIVREFOUX_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.TOFU_ROYAL_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.TOURNESOL_AFFAME_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.TOXOLIATH_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.TYNRIL_AHURI_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.WA_WABBIT_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.WA_WOBOT_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.XLII_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.DAZAK_MARTEGEL_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.BETHEL_AKARNA_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.SOLAR_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.ILYZAELLE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.ANERICE_LA_SHUSHESS_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.CHOUDINI_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.COMTE_RAZOF_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.TAL_KASHA_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.PERE_VER_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.EL_PIKO_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.MANTISCORE_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.DANTINEA_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.LARVE_DE_KOUTOULOU_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.CAPITAINE_MENO_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.USH_GALESH_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.POUNICHEUR_CHALLENGE_DUO)]
    [ChallengeIdentifier((int)ChallengeEnum.LE_CHOUQUE_CHALLENGE_DUO)]

    [ChallengeIdentifier((int)ChallengeEnum.CHALŒIL_CHALLENGE_TRIO)]
    [ChallengeIdentifier((int)ChallengeEnum.REINE_DES_VOLEURS_CHALLENGE_TRIO)]
    [ChallengeIdentifier((int)ChallengeEnum.ROI_NIDAS_CHALLENGE_TRIO)]
    [ChallengeIdentifier((int)ChallengeEnum.VORTEX_CHALLENGE_TRIO)]
    public class DuoChallenge : DefaultChallenge
    {
        private static int[] Trio =
        {
            (int)ChallengeEnum.CHALŒIL_CHALLENGE_TRIO,
            (int)ChallengeEnum.REINE_DES_VOLEURS_CHALLENGE_TRIO,
            (int)ChallengeEnum.ROI_NIDAS_CHALLENGE_TRIO,
            (int)ChallengeEnum.VORTEX_CHALLENGE_TRIO,
        };

        public DuoChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 0;
            BonusMax = 0;
        }

        public override void Initialize()
        {
            base.Initialize();

            Fight.FightStarted += OnFightStarted;
        }

        void OnFightStarted(IFight fight)
        {
            if (Trio.Contains(Id))
            {
                if (fight.Fighters.OfType<CharacterFighter>().Count() > 3)
                    UpdateStatus(ChallengeStatusEnum.FAILED);
            }
            else
            {
                if (fight.Fighters.OfType<CharacterFighter>().Count() > 2)
                    UpdateStatus(ChallengeStatusEnum.FAILED);
            }
        }

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            base.OnWinnersDetermined(fight, winners, losers, draw);

            Fight.FightStarted -= OnFightStarted;
        }
    }
}
