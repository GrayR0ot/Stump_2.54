using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AchievementReward", "com.ankamagames.dofus.datacenter.quest")]
    [Serializable]
    public class AchievementReward : IDataObject, IIndexedData
    {
        public const string MODULE = "AchievementRewards";
        public uint achievementId;
        public string criteria;
        public List<uint> emotesReward;
        public double experienceRatio;
        public uint id;
        public List<uint> itemsQuantityReward;
        public List<uint> itemsReward;
        public double kamasRatio;
        public bool kamasScaleWithPlayerLevel;
        public List<uint> ornamentsReward;
        public List<uint> spellsReward;
        public List<uint> titlesReward;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint AchievementId
        {
            get => achievementId;
            set => achievementId = value;
        }

        [D2OIgnore]
        public string Criteria
        {
            get => criteria;
            set => criteria = value;
        }

        [D2OIgnore]
        public double KamasRatio
        {
            get => kamasRatio;
            set => kamasRatio = value;
        }

        [D2OIgnore]
        public double ExperienceRatio
        {
            get => experienceRatio;
            set => experienceRatio = value;
        }

        [D2OIgnore]
        public bool KamasScaleWithPlayerLevel
        {
            get => kamasScaleWithPlayerLevel;
            set => kamasScaleWithPlayerLevel = value;
        }

        [D2OIgnore]
        public List<uint> ItemsReward
        {
            get => itemsReward;
            set => itemsReward = value;
        }

        [D2OIgnore]
        public List<uint> ItemsQuantityReward
        {
            get => itemsQuantityReward;
            set => itemsQuantityReward = value;
        }

        [D2OIgnore]
        public List<uint> EmotesReward
        {
            get => emotesReward;
            set => emotesReward = value;
        }

        [D2OIgnore]
        public List<uint> SpellsReward
        {
            get => spellsReward;
            set => spellsReward = value;
        }

        [D2OIgnore]
        public List<uint> TitlesReward
        {
            get => titlesReward;
            set => titlesReward = value;
        }

        [D2OIgnore]
        public List<uint> OrnamentsReward
        {
            get => ornamentsReward;
            set => ornamentsReward = value;
        }

        int IIndexedData.Id => (int) id;
    }
}