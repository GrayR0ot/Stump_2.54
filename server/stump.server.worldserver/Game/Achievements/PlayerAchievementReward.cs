using System;
using System.Collections.Generic;
using System.Linq;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Database.Achievements;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Achievements
{
    [Serializable]
    public class PlayerAchievementReward
    {
        [NonSerialized] private Character m_owner;
        private List<ushort> m_rewardAchievementIds;

        [NonSerialized] private List<AchievementTemplate> m_rewardAchievements;

        // FIELDS
        private ushort m_rewardLevel;

        // CONSTRUCTORS
        public PlayerAchievementReward(Character owner, byte rewardLevel, params ushort[] achievementIds)
        {
            m_rewardAchievements = new List<AchievementTemplate>();
            m_rewardAchievementIds = new List<ushort>();

            m_owner = owner;

            m_rewardLevel = rewardLevel;
            foreach (var item in achievementIds)
            {
                var achievement = Singleton<AchievementManager>.Instance.TryGetAchievement(item);
                if (achievement != null)
                {
                    m_rewardAchievements.Add(achievement);
                    m_rewardAchievementIds.Add((ushort) achievement.Id);
                }
            }
        }

        public PlayerAchievementReward(Character owner, params AchievementTemplate[] achievements)
        {
            m_rewardAchievements = new List<AchievementTemplate>();
            m_rewardAchievementIds = new List<ushort>();

            m_owner = owner;

            m_rewardLevel = owner.Level;

            foreach (var item in achievements) AddRewardableAchievement(item);
        }

        // PROPERTIES
        public Character Owner
        {
            get => m_owner;
            private set => m_owner = value;
        }

        public IReadOnlyList<AchievementTemplate> RewardAchievements => m_rewardAchievements.AsReadOnly();

        // METHODS
        public void Initialize(Character owner)
        {
            m_rewardAchievements = new List<AchievementTemplate>();

            m_owner = owner;
            foreach (var item in m_rewardAchievementIds)
            {
                var achievement = Singleton<AchievementManager>.Instance.TryGetAchievement(item);
                if (achievement != null) m_rewardAchievements.Add(achievement);
            }
        }

        public IEnumerable<AchievementAchievedRewardable> GetRewardableAchievements()
        {
            foreach (var item in m_rewardAchievements)
                yield return new AchievementAchievedRewardable((ushort) item.Id, (ulong) Owner.Id, m_rewardLevel);
        }

        public void AddRewardableAchievement(AchievementTemplate achievement)
        {
            m_rewardAchievements.Add(achievement);
            m_rewardAchievementIds.Add((ushort) achievement.Id);
        }

        public bool Contains(AchievementTemplate achievement)
        {
            return m_rewardAchievements.Contains(achievement);
        }

        public bool Remove(AchievementTemplate achievement)
        {
            if (m_rewardAchievementIds.Remove((ushort) achievement.Id)) return m_rewardAchievements.Remove(achievement);

            return false;
        }

        public bool Any()
        {
            return m_rewardAchievements.Any();
        }

        public static bool operator ==(PlayerAchievementReward achievement, byte level)
        {
            return achievement.m_rewardLevel == level;
        }

        public static bool operator !=(PlayerAchievementReward achievement, byte level)
        {
            return achievement.m_rewardLevel != level;
        }
    }
}