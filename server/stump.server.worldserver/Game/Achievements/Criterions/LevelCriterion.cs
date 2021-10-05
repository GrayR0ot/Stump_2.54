using System;
using Stump.Server.WorldServer.Database.Achievements;
using Stump.Server.WorldServer.Game.Achievements.Criterions.Data;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Conditions;

namespace Stump.Server.WorldServer.Game.Achievements.Criterions
{
    public class LevelCriterion : AbstractCriterion<LevelCriterion, DefaultCriterionData>
    {
        // FIELDS
        public const string Identifier = "PL";

        // CONSTRUCTORS
        public LevelCriterion(AchievementObjectiveRecord objective)
            : base(objective)
        {
        }

        // PROPERTIES
        public int Level => base[0][0];

        public override bool IsIncrementable => true;

        // METHODS
        public override DefaultCriterionData Parse(ComparaisonOperatorEnum @operator, params string[] parameters)
        {
            return new DefaultCriterionData(@operator, parameters);
        }

        public override bool Eval(Character character)
        {
            return Level < character.Level;
        }

        public override bool Lower(AbstractCriterion left)
        {
            return Level < ((LevelCriterion) left).Level;
        }

        public override bool Greater(AbstractCriterion left)
        {
            return Level > ((LevelCriterion) left).Level;
        }

        public override ushort GetPlayerValue(PlayerAchievement player)
        {
            return (ushort) Math.Min(base.MaxValue, player.GetRunningCriterion(this));
        }
    }
}