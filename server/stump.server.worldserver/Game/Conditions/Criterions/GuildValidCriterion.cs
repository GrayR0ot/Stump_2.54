using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Conditions.Criterions
{
    public class GuildValidCriterion : Criterion
    {
        public const string Identifier = "Pw";

        public override bool Eval(Character character)
        {
            return true;
        }

        public override void Build()
        {
        }

        public override string ToString()
        {
            return FormatToString(Identifier);
        }
    }
}