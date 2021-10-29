using System;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Database.Achievements;
using Stump.Server.WorldServer.Database.Monsters;
using Stump.Server.WorldServer.Game.Achievements.Criterions.Data;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;
using Stump.Server.WorldServer.Game.Conditions;

namespace Stump.Server.WorldServer.Game.Achievements.Criterions
{
    public class KillBossWithChallengeCriterion :
        AbstractCriterion<KillBossWithChallengeCriterion, DefaultCriterionData>
    {
        // FIELDS
        public const string Identifier = "EH";
        private ushort? m_maxValue;

        // CONSTRUCTORS
        public KillBossWithChallengeCriterion(AchievementObjectiveRecord objective)
            : base(objective)
        {
            var monsterId = GetMonsterIdByChallId(ChallIdentifier);
            if (monsterId != 0)
                Monster = Singleton<MonsterManager>.Instance.GetTemplate(monsterId);
        }

        // PROPERTIES
        public int ChallIdentifier => this[0][0];

        public MonsterTemplate Monster { get; }

        public int Number => this[0][1];

        public override bool IsIncrementable => false;

        public override ushort MaxValue
        {
            get
            {
                if (m_maxValue == null)
                {
                    m_maxValue = (ushort) Number;

                    switch (base[0].Operator)
                    {
                        case ComparaisonOperatorEnum.EQUALS:
                            break;

                        case ComparaisonOperatorEnum.INFERIOR:
                            throw new Exception();

                        case ComparaisonOperatorEnum.SUPERIOR:
                            m_maxValue++;
                            break;
                    }
                }

                return m_maxValue.Value;
            }
        }

        public int GetMonsterIdByChallId(int id)
        {
            switch (id)
            {
                case (int) ChallengeEnum.KARDORIM_CHALLENGE_1:
                case (int) ChallengeEnum.KARDORIM_CHALLENGE_2:
                case (int) ChallengeEnum.KARDORIM_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.KARDORIM;

                case (int) ChallengeEnum.TOURNESOL_AFFAME_CHALLENGE_1:
                case (int) ChallengeEnum.TOURNESOL_AFFAME_CHALLENGE_2:
                case (int) ChallengeEnum.TOURNESOL_AFFAME_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.TOURNESOL_AFFAME;

                case (int) ChallengeEnum.CHAFER_RONIN_CHALLENGE_1:
                case (int) ChallengeEnum.CHAFER_RONIN_CHALLENGE_2:
                case (int) ChallengeEnum.CHAFER_RONIN_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.CHAFER_RONIN;

                case (int) ChallengeEnum.BWORKETTE_CHALLENGE_1:
                case (int) ChallengeEnum.BWORKETTE_CHALLENGE_2:
                case (int) ChallengeEnum.BWORKETTE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.BWORKETTE;

                case (int) ChallengeEnum.COFFRE_DES_FORGERONS_CHALLENGE_1:
                case (int) ChallengeEnum.COFFRE_DES_FORGERONS_CHALLENGE_2:
                case (int) ChallengeEnum.COFFRE_DES_FORGERONS_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.COFFRE_DES_FORGERONS;

                case (int) ChallengeEnum.KANNIBOUL_EBIL_CHALLENGE_1:
                case (int) ChallengeEnum.KANNIBOUL_EBIL_CHALLENGE_2:
                case (int) ChallengeEnum.KANNIBOUL_EBIL_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.KANNIBOUL_EBIL;

                case (int) ChallengeEnum.CRAQUELEUR_LEGENDAIRE_CHALLENGE_1:
                case (int) ChallengeEnum.CRAQUELEUR_LEGENDAIRE_CHALLENGE_2:
                case (int) ChallengeEnum.CRAQUELEUR_LEGENDAIRE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.CRAQUELEUR_LEGENDAIRE;

                case (int) ChallengeEnum.DAÏGORO_CHALLENGE_1:
                case (int) ChallengeEnum.DAÏGORO_CHALLENGE_2:
                case (int) ChallengeEnum.DAÏGORO_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.DAIGORO;

                case (int) ChallengeEnum.REINE_NYEE_CHALLENGE_1:
                case (int) ChallengeEnum.REINE_NYEE_CHALLENGE_2:
                case (int) ChallengeEnum.REINE_NYEE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.REINE_NYEE;

                case (int) ChallengeEnum.ABRAKNYDE_ANCESTRAL_CHALLENGE_1:
                case (int) ChallengeEnum.ABRAKNYDE_ANCESTRAL_CHALLENGE_2:
                case (int) ChallengeEnum.ABRAKNYDE_ANCESTRAL_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.ABRAKNYDE_ANCESTRAL;

                case (int) ChallengeEnum.MEULOU_CHALLENGE_1:
                case (int) ChallengeEnum.MEULOU_CHALLENGE_2:
                case (int) ChallengeEnum.MEULOU_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.MEULOU;

                case (int) ChallengeEnum.SILF_LE_RASBOUL_MAJEUR_CHALLENGE_1:
                case (int) ChallengeEnum.SILF_LE_RASBOUL_MAJEUR_CHALLENGE_2:
                case (int) ChallengeEnum.SILF_LE_RASBOUL_MAJEUR_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.SILF_LE_RASBOUL_MAJEUR;

                case (int) ChallengeEnum.MAÎTRE_CORBAC_CHALLENGE_1:
                case (int) ChallengeEnum.MAÎTRE_CORBAC_CHALLENGE_2:
                case (int) ChallengeEnum.MAÎTRE_CORBAC_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.MAITRE_CORBAC;

                case (int) ChallengeEnum.RAT_BLANC_CHALLENGE_1:
                case (int) ChallengeEnum.RAT_BLANC_CHALLENGE_2:
                case (int) ChallengeEnum.RAT_BLANC_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.RAT_BLANC;

                case (int) ChallengeEnum.ROYALMOUTH_CHALLENGE_1:
                case (int) ChallengeEnum.ROYALMOUTH_CHALLENGE_2:
                case (int) ChallengeEnum.ROYALMOUTH_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.ROYALMOUTH;

                case (int) ChallengeEnum.MAÎTRE_PANDORE_CHALLENGE_1:
                case (int) ChallengeEnum.MAÎTRE_PANDORE_CHALLENGE_2:
                case (int) ChallengeEnum.MAÎTRE_PANDORE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.MAITRE_PANDORE;

                case (int) ChallengeEnum.HAUTE_TRUCHE_CHALLENGE_1:
                case (int) ChallengeEnum.HAUTE_TRUCHE_CHALLENGE_2:
                case (int) ChallengeEnum.HAUTE_TRUCHE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.HAUTE_TRUCHE;

                case (int) ChallengeEnum.CHENE_MOU_CHALLENGE_1:
                case (int) ChallengeEnum.CHENE_MOU_CHALLENGE_2:
                case (int) ChallengeEnum.CHENE_MOU_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.CHENE_MOU;

                case (int) ChallengeEnum.KIMBO_CHALLENGE_1:
                case (int) ChallengeEnum.KIMBO_CHALLENGE_2:
                case (int) ChallengeEnum.KIMBO_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.KIMBO;

                case (int) ChallengeEnum.MINOTOT_CHALLENGE_1:
                case (int) ChallengeEnum.MINOTOT_CHALLENGE_2:
                case (int) ChallengeEnum.MINOTOT_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.MINOTOT;

                case (int) ChallengeEnum.OBSIDIANTRE_CHALLENGE_1:
                case (int) ChallengeEnum.OBSIDIANTRE_CHALLENGE_2:
                case (int) ChallengeEnum.OBSIDIANTRE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.OBSIDIANTRE;

                case (int) ChallengeEnum.KANIGROULA_CHALLENGE_1:
                case (int) ChallengeEnum.KANIGROULA_CHALLENGE_2:
                case (int) ChallengeEnum.KANIGROULA_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.KANIGROULA;

                case (int) ChallengeEnum.USH_GALESH_CHALLENGE_1:
                case (int) ChallengeEnum.USH_GALESH_CHALLENGE_2:
                case (int) ChallengeEnum.USH_GALESH_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.USH_GALESH_4264;

                case (int) ChallengeEnum.TENGU_GIVREFOUX_CHALLENGE_1:
                case (int) ChallengeEnum.TENGU_GIVREFOUX_CHALLENGE_2:
                case (int) ChallengeEnum.TENGU_GIVREFOUX_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.TENGU_GIVREFOUX;

                case (int) ChallengeEnum.PERE_VER_CHALLENGE_1:
                case (int) ChallengeEnum.PERE_VER_CHALLENGE_2:
                case (int) ChallengeEnum.PERE_VER_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.PERE_VER;

                case (int) ChallengeEnum.KOLOSSO_CHALLENGE_1:
                case (int) ChallengeEnum.KOLOSSO_CHALLENGE_2:
                case (int) ChallengeEnum.KOLOSSO_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.KOLOSSO;

                case (int) ChallengeEnum.GLOURSELESTE_CHALLENGE_1:
                case (int) ChallengeEnum.GLOURSELESTE_CHALLENGE_2:
                case (int) ChallengeEnum.GLOURSELESTE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.GLOURSELESTE;

                case (int) ChallengeEnum.OMBRE_CHALLENGE_1:
                case (int) ChallengeEnum.OMBRE_CHALLENGE_2:
                case (int) ChallengeEnum.OMBRE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.OMBRE_3564;

                case (int) ChallengeEnum.COMTE_RAZOF_CHALLENGE_1:
                case (int) ChallengeEnum.COMTE_RAZOF_CHALLENGE_2:
                case (int) ChallengeEnum.COMTE_RAZOF_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.COMTE_RAZOF;

                case (int) ChallengeEnum.ROI_NIDAS_CHALLENGE_1:
                case (int) ChallengeEnum.ROI_NIDAS_CHALLENGE_2:
                case (int) ChallengeEnum.ROI_NIDAS_CHALLENGE_TRIO:
                    return (int) MonsterIdEnum.ROI_NIDAS;

                case (int) ChallengeEnum.REINE_DES_VOLEURS_CHALLENGE_1:
                case (int) ChallengeEnum.REINE_DES_VOLEURS_CHALLENGE_2:
                case (int) ChallengeEnum.REINE_DES_VOLEURS_CHALLENGE_TRIO:
                    return (int) MonsterIdEnum.REINE_DES_VOLEURS_3726;

                case (int) ChallengeEnum.ANERICE_LA_SHUSHESS_CHALLENGE_1:
                case (int) ChallengeEnum.ANERICE_LA_SHUSHESS_CHALLENGE_2:
                case (int) ChallengeEnum.ANERICE_LA_SHUSHESS_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.ANERICE_LA_SHUSHESS;

                case (int) ChallengeEnum.DAZAK_MARTEGEL_CHALLENGE_1:
                case (int) ChallengeEnum.DAZAK_MARTEGEL_CHALLENGE_2:
                case (int) ChallengeEnum.DAZAK_MARTEGEL_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.DAZAK_MARTEGEL;

                case (int) ChallengeEnum.KANKREBLATH_CHALLENGE_1:
                case (int) ChallengeEnum.KANKREBLATH_CHALLENGE_2:
                case (int) ChallengeEnum.KANKREBLATH_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.KANKREBLATH;

                case (int) ChallengeEnum.GELEE_ROYALE_BLEUE_CHALLENGE_1:
                case (int) ChallengeEnum.GELEE_ROYALE_BLEUE_CHALLENGE_2:
                case (int) ChallengeEnum.GELEE_ROYALE_BLEUE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.GELEE_ROYALE_BLEUE;

                case (int) ChallengeEnum.GELEE_ROYALE_CITRON_CHALLENGE_1:
                case (int) ChallengeEnum.GELEE_ROYALE_CITRON_CHALLENGE_2:
                case (int) ChallengeEnum.GELEE_ROYALE_CITRON_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.GELEE_ROYALE_CITRON;

                case (int) ChallengeEnum.GELEE_ROYALE_FRAISE_CHALLENGE_1:
                case (int) ChallengeEnum.GELEE_ROYALE_FRAISE_CHALLENGE_2:
                case (int) ChallengeEnum.GELEE_ROYALE_FRAISE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.GELEE_ROYALE_FRAISE;

                case (int) ChallengeEnum.GELEE_ROYALE_MENTHE_CHALLENGE_1:
                case (int) ChallengeEnum.GELEE_ROYALE_MENTHE_CHALLENGE_2:
                case (int) ChallengeEnum.GELEE_ROYALE_MENTHE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.GELEE_ROYALE_MENTHE;

                case (int) ChallengeEnum.CROCABULIA_CHALLENGE_1:
                case (int) ChallengeEnum.CROCABULIA_CHALLENGE_2:
                case (int) ChallengeEnum.CROCABULIA_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.CROCABULIA;

                case (int) ChallengeEnum.OUGAH_CHALLENGE_1:
                case (int) ChallengeEnum.OUGAH_CHALLENGE_2:
                case (int) ChallengeEnum.OUGAH_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.OUGAH;

                case (int) ChallengeEnum.MISSIZ_FRIZZ_CHALLENGE_1:
                case (int) ChallengeEnum.MISSIZ_FRIZZ_CHALLENGE_2:
                case (int) ChallengeEnum.MISSIZ_FRIZZ_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.MISSIZ_FRIZZ;

                case (int) ChallengeEnum.SCARABOSSE_DORE_CHALLENGE_1:
                case (int) ChallengeEnum.SCARABOSSE_DORE_CHALLENGE_2:
                case (int) ChallengeEnum.SCARABOSSE_DORE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.SCARABOSSE_DORE;

                case (int) ChallengeEnum.KWAKWA_CHALLENGE_1:
                case (int) ChallengeEnum.KWAKWA_CHALLENGE_2:
                case (int) ChallengeEnum.KWAKWA_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.KWAKWA;

                case (int) ChallengeEnum.MANTISCORE_CHALLENGE_1:
                case (int) ChallengeEnum.MANTISCORE_CHALLENGE_2:
                case (int) ChallengeEnum.MANTISCORE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.MANTISCORE;

                case (int) ChallengeEnum.KOULOSSE_CHALLENGE_1:
                case (int) ChallengeEnum.KOULOSSE_CHALLENGE_2:
                case (int) ChallengeEnum.KOULOSSE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.KOULOSSE;

                case (int) ChallengeEnum.TYNRIL_AHURI_CHALLENGE_1:
                case (int) ChallengeEnum.TYNRIL_AHURI_CHALLENGE_2:
                case (int) ChallengeEnum.TYNRIL_AHURI_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.TYNRIL_AHURI;

                case (int) ChallengeEnum.XLII_CHALLENGE_1:
                case (int) ChallengeEnum.XLII_CHALLENGE_2:
                case (int) ChallengeEnum.XLII_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.XLII;

                case (int) ChallengeEnum.KORRIANDRE_CHALLENGE_1:
                case (int) ChallengeEnum.KORRIANDRE_CHALLENGE_2:
                case (int) ChallengeEnum.KORRIANDRE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.KORRIANDRE;

                case (int) ChallengeEnum.BETHEL_AKARNA_CHALLENGE_1:
                case (int) ChallengeEnum.BETHEL_AKARNA_CHALLENGE_2:
                case (int) ChallengeEnum.BETHEL_AKARNA_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.BETHEL_AKARNA;

                case (int) ChallengeEnum.MOB_LEPONGE_CHALLENGE_1:
                case (int) ChallengeEnum.MOB_LEPONGE_CHALLENGE_2:
                case (int) ChallengeEnum.MOB_LEPONGE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.MOB_L_EPONGE;

                case (int) ChallengeEnum.BOOSTACHE_CHALLENGE_1:
                case (int) ChallengeEnum.BOOSTACHE_CHALLENGE_2:
                case (int) ChallengeEnum.BOOSTACHE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.BOOSTACHE;

                case (int) ChallengeEnum.BULBIG_BROZEUR_CHALLENGE_1:
                case (int) ChallengeEnum.BULBIG_BROZEUR_CHALLENGE_2:
                case (int) ChallengeEnum.BULBIG_BROZEUR_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.BULBIG_BROZEUR;

                case (int) ChallengeEnum.MINOTOROR_CHALLENGE_1:
                case (int) ChallengeEnum.MINOTOROR_CHALLENGE_2:
                case (int) ChallengeEnum.MINOTOROR_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.MINOTOROR;

                case (int) ChallengeEnum.FRAKTALE_CHALLENGE_1:
                case (int) ChallengeEnum.FRAKTALE_CHALLENGE_2:
                case (int) ChallengeEnum.FRAKTALE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.FRAKTALE;

                case (int) ChallengeEnum.TOXOLIATH_CHALLENGE_1:
                case (int) ChallengeEnum.TOXOLIATH_CHALLENGE_2:
                case (int) ChallengeEnum.TOXOLIATH_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.TOXOLIATH;

                case (int) ChallengeEnum.SYLARGH_CHALLENGE_1:
                case (int) ChallengeEnum.SYLARGH_CHALLENGE_2:
                case (int) ChallengeEnum.SYLARGH_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.SYLARGH;

                case (int) ChallengeEnum.BATOFU_CHALLENGE_1:
                case (int) ChallengeEnum.BATOFU_CHALLENGE_2:
                case (int) ChallengeEnum.BATOFU_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.BATOFU;

                case (int) ChallengeEnum.SHIN_LARVE_CHALLENGE_1:
                case (int) ChallengeEnum.SHIN_LARVE_CHALLENGE_2:
                case (int) ChallengeEnum.SHIN_LARVE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.SHIN_LARVE;

                case (int) ChallengeEnum.DRAGON_COCHON_CHALLENGE_1:
                case (int) ChallengeEnum.DRAGON_COCHON_CHALLENGE_2:
                case (int) ChallengeEnum.DRAGON_COCHON_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.DRAGON_COCHON;

                case (int) ChallengeEnum.MOON_CHALLENGE_1:
                case (int) ChallengeEnum.MOON_CHALLENGE_2:
                case (int) ChallengeEnum.MOON_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.MOON;

                case (int) ChallengeEnum.GROLLOUM_CHALLENGE_1:
                case (int) ChallengeEnum.GROLLOUM_CHALLENGE_2:
                case (int) ChallengeEnum.GROLLOUM_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.GROLLOUM;

                case (int) ChallengeEnum.HAREBOURG_CHALLENGE_1:
                case (int) ChallengeEnum.HAREBOURG_CHALLENGE_2:
                case (int) ChallengeEnum.HAREBOURG_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.COMTE_HAREBOURG;

                case (int) ChallengeEnum.SOLAR_CHALLENGE_1:
                case (int) ChallengeEnum.SOLAR_CHALLENGE_2:
                case (int) ChallengeEnum.SOLAR_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.SOLAR;

                case (int) ChallengeEnum.BLOP_COCO_ROYAL_CHALLENGE_1:
                case (int) ChallengeEnum.BLOP_COCO_ROYAL_CHALLENGE_2:
                case (int) ChallengeEnum.BLOP_COCO_ROYAL_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.BLOP_COCO_ROYAL;

                case (int) ChallengeEnum.BLOP_GRIOTTE_ROYAL_CHALLENGE_1:
                case (int) ChallengeEnum.BLOP_GRIOTTE_ROYAL_CHALLENGE_2:
                case (int) ChallengeEnum.BLOP_GRIOTTE_ROYAL_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.BLOP_GRIOTTE_ROYAL;

                case (int) ChallengeEnum.BLOP_INDIGO_ROYAL_CHALLENGE_1:
                case (int) ChallengeEnum.BLOP_INDIGO_ROYAL_CHALLENGE_2:
                case (int) ChallengeEnum.BLOP_INDIGO_ROYAL_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.BLOP_INDIGO_ROYAL;

                case (int) ChallengeEnum.BLOP_REINETTE_ROYAL_CHALLENGE_1:
                case (int) ChallengeEnum.BLOP_REINETTE_ROYAL_CHALLENGE_2:
                case (int) ChallengeEnum.BLOP_REINETTE_ROYAL_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.BLOP_REINETTE_ROYAL;

                case (int) ChallengeEnum.BOUFTOU_ROYAL_CHALLENGE_1:
                case (int) ChallengeEnum.BOUFTOU_ROYAL_CHALLENGE_2:
                case (int) ChallengeEnum.BOUFTOU_ROYAL_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.BOUFTOU_ROYAL;

                case (int) ChallengeEnum.KLIME_CHALLENGE_1:
                case (int) ChallengeEnum.KLIME_CHALLENGE_2:
                case (int) ChallengeEnum.KLIME_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.KLIME;

                case (int) ChallengeEnum.NILEZA_CHALLENGE_1:
                case (int) ChallengeEnum.NILEZA_CHALLENGE_2:
                case (int) ChallengeEnum.NILEZA_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.NILEZA;

                case (int) ChallengeEnum.CHALŒIL_CHALLENGE_1:
                case (int) ChallengeEnum.CHALŒIL_CHALLENGE_2:
                case (int) ChallengeEnum.CHALŒIL_CHALLENGE_TRIO:
                    return (int) MonsterIdEnum.CHALOEIL;

                case (int) ChallengeEnum.CAPITAINE_MENO_CHALLENGE_1:
                case (int) ChallengeEnum.CAPITAINE_MENO_CHALLENGE_2:
                case (int) ChallengeEnum.CAPITAINE_MENO_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.CAPITAINE_MENO;

                case (int) ChallengeEnum.LARVE_DE_KOUTOULOU_CHALLENGE_1:
                case (int) ChallengeEnum.LARVE_DE_KOUTOULOU_CHALLENGE_2:
                case (int) ChallengeEnum.LARVE_DE_KOUTOULOU_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.LARVE_DE_KOUTOULOU;

                case (int) ChallengeEnum.CORAILLEUR_MAGISTRAL_CHALLENGE_1:
                case (int) ChallengeEnum.CORAILLEUR_MAGISTRAL_CHALLENGE_2:
                case (int) ChallengeEnum.CORAILLEUR_MAGISTRAL_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.CORAILLEUR_MAGISTRAL;

                case (int) ChallengeEnum.WA_WABBIT_CHALLENGE_1:
                case (int) ChallengeEnum.WA_WABBIT_CHALLENGE_2:
                case (int) ChallengeEnum.WA_WABBIT_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.WA_WABBIT;

                case (int) ChallengeEnum.WA_WOBOT_CHALLENGE_1:
                case (int) ChallengeEnum.WA_WOBOT_CHALLENGE_2:
                case (int) ChallengeEnum.WA_WOBOT_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.WA_WOBOT;

                case (int) ChallengeEnum.MALLEFISK_CHALLENGE_1:
                case (int) ChallengeEnum.MALLEFISK_CHALLENGE_2:
                case (int) ChallengeEnum.MALLEFISK_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.MALLEFISK;

                case (int) ChallengeEnum.RAT_NOIR_CHALLENGE_1:
                case (int) ChallengeEnum.RAT_NOIR_CHALLENGE_2:
                case (int) ChallengeEnum.RAT_NOIR_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.RAT_NOIR;

                case (int) ChallengeEnum.POUNICHEUR_CHALLENGE_1:
                case (int) ChallengeEnum.POUNICHEUR_CHALLENGE_2:
                case (int) ChallengeEnum.POUNICHEUR_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.POUNICHEUR;

                case (int) ChallengeEnum.SKEUNK_CHALLENGE_1:
                case (int) ChallengeEnum.SKEUNK_CHALLENGE_2:
                case (int) ChallengeEnum.SKEUNK_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.SKEUNK;

                case (int) ChallengeEnum.EL_PIKO_CHALLENGE_1:
                case (int) ChallengeEnum.EL_PIKO_CHALLENGE_2:
                case (int) ChallengeEnum.EL_PIKO_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.EL_PIKO;

                case (int) ChallengeEnum.KRALAMOUR_GEANT_CHALLENGE_1:
                case (int) ChallengeEnum.KRALAMOUR_GEANT_CHALLENGE_2:
                case (int) ChallengeEnum.KRALAMOUR_GEANT_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.KRALAMOURE_GEANT;

                case (int) ChallengeEnum.BWORKER_CHALLENGE_1:
                case (int) ChallengeEnum.BWORKER_CHALLENGE_2:
                case (int) ChallengeEnum.BWORKER_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.BWORKER;

                case (int) ChallengeEnum.MAÎTRE_DES_PANTINS_CHALLENGE_1:
                case (int) ChallengeEnum.MAÎTRE_DES_PANTINS_CHALLENGE_2:
                case (int) ChallengeEnum.MAÎTRE_DES_PANTINS_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.MAITRE_DES_PANTINS;

                case (int) ChallengeEnum.TOFU_ROYAL_CHALLENGE_1:
                case (int) ChallengeEnum.TOFU_ROYAL_CHALLENGE_2:
                case (int) ChallengeEnum.TOFU_ROYAL_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.TOFU_ROYAL;

                case (int) ChallengeEnum.CAPITAINE_EKARLATTE_CHALLENGE_1:
                case (int) ChallengeEnum.CAPITAINE_EKARLATTE_CHALLENGE_2:
                case (int) ChallengeEnum.CAPITAINE_EKARLATTE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.CAPITAINE_EKARLATTE;

                case (int) ChallengeEnum.PEKI_PEKI_CHALLENGE_1:
                case (int) ChallengeEnum.PEKI_PEKI_CHALLENGE_2:
                case (int) ChallengeEnum.PEKI_PEKI_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.PEKI_PEKI;

                case (int) ChallengeEnum.BEN_LE_RIPATE_CHALLENGE_1:
                case (int) ChallengeEnum.BEN_LE_RIPATE_CHALLENGE_2:
                case (int) ChallengeEnum.BEN_LE_RIPATE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.BEN_LE_RIPATE;

                case (int) ChallengeEnum.FUJI_GIVREFOUX_NOURRICIERE_CHALLENGE_1:
                case (int) ChallengeEnum.FUJI_GIVREFOUX_NOURRICIERE_CHALLENGE_2:
                case (int) ChallengeEnum.FUJI_GIVREFOUX_NOURRICIERE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.FUJI_GIVREFOUX_NOURRICIERE;

                case (int) ChallengeEnum.PROTOZORREUR_CHALLENGE_1:
                case (int) ChallengeEnum.PROTOZORREUR_CHALLENGE_2:
                case (int) ChallengeEnum.PROTOZORREUR_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.PROTOZORREUR;

                case (int) ChallengeEnum.DANTINEA_CHALLENGE_1:
                case (int) ChallengeEnum.DANTINEA_CHALLENGE_2:
                case (int) ChallengeEnum.DANTINEA_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.DANTINEA;

                case (int) ChallengeEnum.TAL_KASHA_CHALLENGE_1:
                case (int) ChallengeEnum.TAL_KASHA_CHALLENGE_2:
                case (int) ChallengeEnum.TAL_KASHA_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.TAL_KASHA;

                case (int) ChallengeEnum.CHOUDINI_CHALLENGE_1:
                case (int) ChallengeEnum.CHOUDINI_CHALLENGE_2:
                case (int) ChallengeEnum.CHOUDINI_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.CHOUDINI;

                case (int) ChallengeEnum.BLOP_MULTICOLORE_ROYAL_CHALLENGE_1:
                case (int) ChallengeEnum.BLOP_MULTICOLORE_ROYAL_CHALLENGE_2:
                case (int) ChallengeEnum.BLOP_MULTICOLORE_ROYAL_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.BLOP_MULTICOLORE_ROYAL;

                case (int) ChallengeEnum.TANUKOUÏ_SAN_CHALLENGE_1:
                case (int) ChallengeEnum.TANUKOUÏ_SAN_CHALLENGE_2:
                case (int) ChallengeEnum.TANUKOUÏ_SAN_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.TANUKOUI_SAN;

                case (int) ChallengeEnum.SPHINCTER_CELL_CHALLENGE_1:
                case (int) ChallengeEnum.SPHINCTER_CELL_CHALLENGE_2:
                case (int) ChallengeEnum.SPHINCTER_CELL_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.SPHINCTER_CELL;

                case (int) ChallengeEnum.PHOSSILE_CHALLENGE_1:
                case (int) ChallengeEnum.PHOSSILE_CHALLENGE_2:
                case (int) ChallengeEnum.PHOSSILE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.PHOSSILE;

                case (int) ChallengeEnum.VORTEX_CHALLENGE_1:
                case (int) ChallengeEnum.VORTEX_CHALLENGE_2:
                case (int) ChallengeEnum.VORTEX_CHALLENGE_TRIO:
                    return (int) MonsterIdEnum.VORTEX;

                case (int) ChallengeEnum.NELWEEN_CHALLENGE_1:
                case (int) ChallengeEnum.NELWEEN_CHALLENGE_2:
                case (int) ChallengeEnum.NELWEEN_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.NELWEEN;

                case (int) ChallengeEnum.LE_CHOUQUE_CHALLENGE_1:
                case (int) ChallengeEnum.LE_CHOUQUE_CHALLENGE_2:
                case (int) ChallengeEnum.LE_CHOUQUE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.LE_CHOUQUE;

                case (int) ChallengeEnum.MANSOT_ROYAL_CHALLENGE_1:
                case (int) ChallengeEnum.MANSOT_ROYAL_CHALLENGE_2:
                case (int) ChallengeEnum.MANSOT_ROYAL_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.MANSOT_ROYAL;

                case (int) ChallengeEnum.MERKATOR_CHALLENGE_1:
                case (int) ChallengeEnum.MERKATOR_CHALLENGE_2:
                case (int) ChallengeEnum.MERKATOR_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.MERKATOR;

                case (int) ChallengeEnum.ILYZAELLE_CHALLENGE_1:
                case (int) ChallengeEnum.ILYZAELLE_CHALLENGE_2:
                case (int) ChallengeEnum.ILYZAELLE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.ILYZAELLE;

                case (int) ChallengeEnum.GOURLO_LE_TERRIBLE_CHALLENGE_1:
                case (int) ChallengeEnum.GOURLO_LE_TERRIBLE_CHALLENGE_2:
                case (int) ChallengeEnum.GOURLO_LE_TERRIBLE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.GOURLO_LE_TERRIBLE;

                case (int) ChallengeEnum.HALOUINE_CHALLENGE_1:
                case (int) ChallengeEnum.HALOUINE_CHALLENGE_2:
                case (int) ChallengeEnum.HALOUINE_CHALLENGE_CHRONO:
                case (int) ChallengeEnum.HALOUINE_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.HALOUINE;

                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_FATIGUES_CHALLENGE_1:
                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_FATIGUES_CHALLENGE_2:
                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_FATIGUES_CHALLENGE_CHRONO:
                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_FATIGUES_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.GROZILLA_FATIGUE;

                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_SOMNAMBULES_CHALLENGE_1:
                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_SOMNAMBULES_CHALLENGE_2:
                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_SOMNAMBULES_CHALLENGE_CHRONO:
                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_SOMNAMBULES_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.GROZILLA_SOMNAMBULE;

                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_EPUISES_CHALLENGE_1:
                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_EPUISES_CHALLENGE_2:
                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_EPUISES_CHALLENGE_CHRONO:
                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_EPUISES_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.GRASMERA_EPUISE;

                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_CHALLENGE_1:
                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_CHALLENGE_2:
                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_CHALLENGE_CHRONO:
                case (int) ChallengeEnum.GROZILLA_ET_GRASMERA_CHALLENGE_DUO:
                    return (int) MonsterIdEnum.GROZILLA;

                case (int) ChallengeEnum.PRETRESSE_DE_KAO_CHALLENGE_1:
                case (int) ChallengeEnum.PRETRESSE_DE_KAO_CHALLENGE_2:
                case (int) ChallengeEnum.PRETRESSE_DE_KAO_CHALLENGE_DUO:
                case (int) ChallengeEnum.PRETRESSE_DE_KAO_CHALLENGE_CHRONO:
                    return (int) MonsterIdEnum.GROZILLA;


                default:
                    return 0;
            }
        }

        // METHODS
        public override DefaultCriterionData Parse(ComparaisonOperatorEnum @operator, params string[] parameters)
        {
            return new DefaultCriterionData(@operator, parameters);
        }

        public override bool Eval(Character character)
        {
            return character.Achievement.GetRunningCriterion(this) >= Number;
        }

        public override bool Lower(AbstractCriterion left)
        {
            return Number < ((KillBossWithChallengeCriterion) left).Number;
        }

        public override bool Greater(AbstractCriterion left)
        {
            return Number > ((KillBossWithChallengeCriterion) left).Number;
        }

        public override ushort GetPlayerValue(PlayerAchievement player)
        {
            return (ushort) Math.Min(MaxValue, player.GetRunningCriterion(this));
        }
    }
}