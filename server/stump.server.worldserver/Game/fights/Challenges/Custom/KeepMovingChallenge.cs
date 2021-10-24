using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.CIRCULEZ)]
    [ChallengeIdentifier((int)ChallengeEnum.MALLEFISK_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.BEN_LE_RIPATE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.MINOTOT_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.TOXOLIATH_CHALLENGE_1)]

    // Liberty criterion
    [ChallengeIdentifier((int)ChallengeEnum.CHENE_MOU_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.PHOSSILE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.COMTE_RAZOF_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.CHALŒIL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.ILYZAELLE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.DAZAK_MARTEGEL_CHALLENGE_1)]
    public class KeepMovingChallenge : DefaultChallenge
    {
        public KeepMovingChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 20;
            BonusMax = 20;
        }

        public override void Initialize()
        {
            base.Initialize();

            foreach (var fighter in Fight.GetAllFighters<MonsterFighter>())
                fighter.FightPointsVariation += OnFightPointsVariation;
        }

        public override bool IsEligible() => Fight.GetAllCharacters().Any(x => x.BreedId != PlayableBreedEnum.Pandawa);

        void OnFightPointsVariation(FightActor actor, ActionsEnum action, FightActor source, FightActor target, short delta)
        {
            if (delta >= 0)
                return;

            if (actor == source)
                return;

            if (action != ActionsEnum.ACTION_CHARACTER_MOVEMENT_POINTS_LOST)
                return;

            UpdateStatus(ChallengeStatusEnum.FAILED, source);
        }

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            base.OnWinnersDetermined(fight, winners, losers, draw);

            foreach (var fighter in Fight.GetAllFighters<MonsterFighter>())
                fighter.FightPointsVariation -= OnFightPointsVariation;
        }
    }
}
