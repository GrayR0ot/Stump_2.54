using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Conditions.Criterions
{
    public class AchievementCriterion : Criterion
    {
        public const string Identifier = "OA";

        public override void Build()
        {
        }

        public override bool Eval(Character character)
        {
            return true;
        }
    }
}