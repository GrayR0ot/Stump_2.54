using System;
using Stump.Core.Reflection;
using Stump.Server.WorldServer.Database.Achievements;
using Stump.Server.WorldServer.Game.Conditions;

namespace Stump.Server.WorldServer.Game.Achievements.Criterions.Data
{
    public class AchievementCriterionData : CriterionData
    {
        // FIELDS
        private readonly uint m_achievementId;

        // CONSTRUCTORS
        public AchievementCriterionData(ComparaisonOperatorEnum @operator, params string[] parameters)
            : base(@operator, parameters)
        {
            if (uint.TryParse(base[0], out m_achievementId))
                Achievement = Singleton<AchievementManager>.Instance.TryGetAchievement(m_achievementId);
            else
                throw new Exception();
        }

        // PROPERTIES
        public AchievementTemplate Achievement { get; }

        // METHODS
    }
}