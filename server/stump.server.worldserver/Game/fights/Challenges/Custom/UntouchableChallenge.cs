using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;
using System;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.INTOUCHABLE)]
    [ChallengeIdentifier((int)ChallengeEnum.TYNRIL_AHURI__CHALLENGE_1_)]
    public class UntouchableChallenge : DefaultChallenge
    {
        public UntouchableChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 120;
            BonusMax = 160;
        }

        public Action<FightActor, Damage> OnDamageInflicted { get; private set; }
        public Action<IFight, FightActor> OnTurnStarted { get; private set; }

        public override void Initialize()
        {
            base.Initialize();

            foreach (var fighter in Fight.GetAllFighters<CharacterFighter>())
            {
                fighter.DamageInflicted += OnDamageInflicted;
            }

            void OnDamageInflicted(FightActor fighter, Damage damage)
            {

                if (!(fighter is CharacterFighter))
                    return;

                if (damage.Source is MonsterFighter)
                    UpdateStatus(ChallengeStatusEnum.FAILED, fighter);

            }
        }

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            base.OnWinnersDetermined(fight, winners, losers, draw);

            foreach (var fighter in Fight.GetAllFighters<CharacterFighter>())
            {
                fighter.DamageInflicted -= OnDamageInflicted;
            }

            Fight.TurnStarted -= OnTurnStarted;
        }
    }
}