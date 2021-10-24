using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.STATUE)]
    [ChallengeIdentifier((int)ChallengeEnum.BATOFU_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.BWORKETTE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.MOON_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.MAÎTRE_DES_PANTINS_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.POUNICHEUR_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.TOFU_ROYAL_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.SKEUNK_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.CAPITAINE_EKARLATTE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.PEKI_PEKI_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.BEN_LE_RIPATE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.KIMBO_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.OBSIDIANTRE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.TENGU_GIVREFOUX_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.FUJI_GIVREFOUX_NOURRICIERE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.HAREBOURG_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.ROI_NIDAS_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.PROTOZORREUR_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.DANTINEA_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.TAL_KASHA_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_SOMNAMBULES_CHALLENGE_1)]
    public class StatueChallenge : DefaultChallenge
    {
        public StatueChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 25;
            BonusMax = 55;
        }

        public override void Initialize()
        {
            base.Initialize();

            Fight.TurnStopped += OnTurnStopped;
        }

        void OnTurnStopped(IFight fight, FightActor fighter)
        {
            if (!(fighter is CharacterFighter))
                return;

            if (fighter.Position?.Cell.Id == fighter.TurnStartPosition?.Cell.Id)
                return;

            UpdateStatus(ChallengeStatusEnum.FAILED);

            Fight.TurnStopped -= OnTurnStopped;
        }

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            OnTurnStopped(fight, fight.FighterPlaying);

            base.OnWinnersDetermined(fight, winners, losers, draw);

            Fight.TurnStopped -= OnTurnStopped;
        }
    }
}
