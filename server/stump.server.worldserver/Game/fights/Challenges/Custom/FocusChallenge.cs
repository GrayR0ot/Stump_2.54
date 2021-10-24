using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.FOCUS)]
    [ChallengeIdentifier((int)ChallengeEnum.TANUKOUÏ_SAN_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.CAPITAINE_EKARLATTE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.VORTEX_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.TAL_KASHA_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.ILYZAELLE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.SOLAR_CHALLENGE_2)]
    public class FocusChallenge : DefaultChallenge
    {
        public FocusChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 30;
            BonusMax = 50;
        }

        public override void Initialize()
        {
            base.Initialize();

            foreach (var fighter in Fight.GetAllFighters<MonsterFighter>())
            {
                fighter.BeforeDamageInflicted += OnBeforeDamageInflicted;
                fighter.Dead += OnDead;
            }
        }

        void OnDead(FightActor fighter, FightActor killer)
        {
            if (fighter == Target)
                Target = null;
        }

        void OnBeforeDamageInflicted(FightActor fighter, Damage damage)
        {
            if (!(damage.Source is CharacterFighter))
                return;

            if (damage.ReflectedDamages)
                return;

            if (Target == null || Target == fighter)
                Target = fighter;
            else
                UpdateStatus(ChallengeStatusEnum.FAILED, damage.Source);
        }

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            base.OnWinnersDetermined(fight, winners, losers, draw);

            foreach (var fighter in Fight.GetAllFighters<MonsterFighter>())
            {
                fighter.BeforeDamageInflicted -= OnBeforeDamageInflicted;
                fighter.Dead -= OnDead;
            }
        }
    }
}
