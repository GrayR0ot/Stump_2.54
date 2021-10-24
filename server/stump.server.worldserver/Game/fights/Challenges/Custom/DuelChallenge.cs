using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.DUEL)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_COCO_ROYAL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_GRIOTTE_ROYAL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_INDIGO_ROYAL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_REINETTE_ROYAL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.GELEE_ROYALE_BLEUE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.GELEE_ROYALE_CITRON_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.GELEE_ROYALE_FRAISE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.GELEE_ROYALE_MENTHE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.BLOP_MULTICOLORE_ROYAL_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.EL_PIKO_CHALLENGE_1)]
    public class DuelChallenge : DefaultChallenge
    {
        private readonly Dictionary<MonsterFighter, CharacterFighter> m_history = new Dictionary<MonsterFighter, CharacterFighter>();

        public DuelChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 40;
            BonusMax = 40;
        }

        public override void Initialize()
        {
            base.Initialize();

            foreach (var fighter in Fight.GetAllFighters<MonsterFighter>())
                fighter.DamageInflicted += OnDamageInflicted;
        }

        public override bool IsEligible() => Fight.GetAllFighters<MonsterFighter>().Count() > 1;

        void OnDamageInflicted(FightActor fighter, Damage damage)
        {
            var source = (damage.Source is SummonedFighter) ? ((SummonedFighter) damage.Source).Summoner : damage.Source;

            if (!(source is CharacterFighter))
                return;

            CharacterFighter caster;
            m_history.TryGetValue((MonsterFighter) fighter, out caster);

            if (caster == null)
            {
                m_history.Add((MonsterFighter)fighter, (CharacterFighter)source);
                return;
            }

            if (caster == source)
                return;

            UpdateStatus(ChallengeStatusEnum.FAILED, source);
        }

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            base.OnWinnersDetermined(fight, winners, losers, draw);

            foreach (var fighter in Fight.GetAllFighters<MonsterFighter>())
                fighter.DamageInflicted -= OnDamageInflicted;
        }
    }
}
