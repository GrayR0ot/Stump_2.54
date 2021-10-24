using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.SURSIS)]
    [ChallengeIdentifier((int)ChallengeEnum.BOOSTACHE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.KANKREBLATH_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.NELWEEN_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.LE_CHOUQUE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.TOFU_ROYAL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.MANSOT_ROYAL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.SPHINCTER_CELL_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.OUGAH_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.KOLOSSO_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.FUJI_GIVREFOUX_NOURRICIERE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.NILEZA_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.MERKATOR_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.DANTINEA_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.HALOUINE_CHALLENGE_2)]
    public class ReprieveChallenge : DefaultChallenge
    {
        public ReprieveChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 20;
            BonusMax = 55;
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
            if (Target.Team.Fighters.Where(x => x.IsAlive()).Count() != 0 && victim == Target)
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
