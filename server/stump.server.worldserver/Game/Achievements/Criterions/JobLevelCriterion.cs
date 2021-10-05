using System;
using System.Linq;
using Stump.Server.WorldServer.Database.Achievements;
using Stump.Server.WorldServer.Game.Achievements.Criterions.Data;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Conditions;

namespace Stump.Server.WorldServer.Game.Achievements.Criterions
{
    public class JobLevelCriterion : AbstractCriterion<JobLevelCriterion, DefaultCriterionData>
    {
        // FIELDS
        public const string Identifier = "PJ";

        // CONSTRUCTORS
        public JobLevelCriterion(AchievementObjectiveRecord objective)
            : base(objective)
        {
        }

        // PROPERTIES
        public int JobLevel => base[0][0];

        public int Count => base[0][1];

        public override bool IsIncrementable => true;

        // METHODS
        public override DefaultCriterionData Parse(ComparaisonOperatorEnum @operator, params string[] parameters)
        {
            return new DefaultCriterionData(@operator, parameters);
        }

        public override bool Eval(Character character)
        {
            var lvl = character.Jobs.OrderByDescending(x => x.Level).FirstOrDefault().Level;
            var count = character.Jobs.Where(x => x.Level > JobLevel).Count();
            return JobLevel < lvl && count > Count;
        }

        public override bool Lower(AbstractCriterion left)
        {
            return JobLevel < ((JobLevelCriterion) left).JobLevel && Count < ((JobLevelCriterion) left).Count;
        }

        public override bool Greater(AbstractCriterion left)
        {
            return JobLevel > ((JobLevelCriterion) left).JobLevel && Count > ((JobLevelCriterion) left).Count;
        }

        public override ushort GetPlayerValue(PlayerAchievement player)
        {
            return (ushort) Math.Min(base.MaxValue, player.GetRunningCriterion(this));
        }
    }
}