using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.MAINS_PROPRES)]
    [ChallengeIdentifier((int)ChallengeEnum.SCARABOSSE_DORE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.KWAKWA_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.BULBIG_BROZEUR_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.WA_WOBOT_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.MANTISCORE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.KOULOSSE_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.MINOTOROR_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.ROYALMOUTH_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.MAÎTRE_DES_PANTINS_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.GROZILLA_ET_GRASMERA_SOMNAMBULES_CHALLENGE_2)]

    public class CleanHandsChallenge : DefaultChallenge
    {
        public CleanHandsChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 20;
            BonusMax = 20;
        }

        public override void Initialize()
        {
            base.Initialize();

            foreach (var fighter in Fight.GetAllFighters<MonsterFighter>())
                fighter.DamageInflicted += OnDamageInflicted;
        }

        void OnDamageInflicted(FightActor fighter, Damage damage)

        {
            if (fighter.IsAlive())
                return;

            if (!(damage.Source is CharacterFighter))
                return;

            if (damage.Spell != null /*|| damage.IsWeaponAttack*/ )
            {
                //UpdateStatus(ChallengeStatusEnum.FAILED, damage.Source);
                return;
            }

            if (fighter.IsIndirectSpellCast(damage.Spell) /*|| fighter.IsPoisonSpellCast(damage.Spell)*/)
                return;

            //UpdateStatus(ChallengeStatusEnum.FAILED, damage.Source);
        }

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            base.OnWinnersDetermined(fight, winners, losers, draw);

            foreach (var fighter in Fight.GetAllFighters<MonsterFighter>())
                fighter.DamageInflicted -= OnDamageInflicted;
        }
    }
}
