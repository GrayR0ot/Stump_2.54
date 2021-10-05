using System;
using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Conditions.Criterions
{
    public class SmileyPackCriterion : Criterion
    {
        public const string Identifier = "Os";

        public int SmileyPack { get; set; }

        public override bool Eval(Character character)
        {
            return Operator == ComparaisonOperatorEnum.EQUALS
                ? character.HasSmileyPack((SmileyPacksEnum) SmileyPack)
                : !character.HasSmileyPack((SmileyPacksEnum) SmileyPack);
        }

        public override void Build()
        {
            int smileyPack;

            if (!int.TryParse(Literal, out smileyPack))
                throw new Exception(string.Format("Cannot build SmileyPackCriterion, {0} is not a valid smiley pack id",
                    Literal));

            SmileyPack = smileyPack;
        }

        public override string ToString()
        {
            return FormatToString(Identifier);
        }
    }
}