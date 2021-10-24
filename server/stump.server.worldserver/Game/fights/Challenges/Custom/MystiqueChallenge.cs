using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Database.Items.Templates;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.MYSTIQUE)]
    [ChallengeIdentifier((int)ChallengeEnum.KORRIANDRE_CHALLENGE_1)]
    [ChallengeIdentifier((int)ChallengeEnum.MERKATOR_CHALLENGE_2)]
    [ChallengeIdentifier((int)ChallengeEnum.BETHEL_AKARNA_CHALLENGE_1)]
    public class MystiqueChallenge : DefaultChallenge
    {
        public MystiqueChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 70;
            BonusMax = 80;
        }

        public override void Initialize()
        {
            base.Initialize();

            foreach (var fighter in Fight.GetAllFighters<CharacterFighter>())
                fighter.WeaponUsed += OnWeaponUsed;
        }

        void OnWeaponUsed(FightActor caster, WeaponTemplate weapon, Cell target, FightSpellCastCriticalEnum critical, bool silentCast)
            => UpdateStatus(ChallengeStatusEnum.FAILED);

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            base.OnWinnersDetermined(fight, winners, losers, draw);

            foreach (var fighter in Fight.GetAllFighters<CharacterFighter>())
                fighter.WeaponUsed -= OnWeaponUsed;
        }
    }
}
