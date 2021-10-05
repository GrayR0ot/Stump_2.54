using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("QuestStepRewards", "com.ankamagames.dofus.datacenter.quest")]
    [Serializable]
    public class QuestStepRewards : IDataObject, IIndexedData
    {
        public const string MODULE = "QuestStepRewards";
        public List<uint> emotesReward;
        public double experienceRatio;
        public uint id;
        public List<List<uint>> itemsReward;
        public List<uint> jobsReward;
        public double kamasRatio;
        public bool kamasScaleWithPlayerLevel;
        public int levelMax;
        public int levelMin;
        public List<uint> spellsReward;
        public uint stepId;
        public List<uint> titlesReward;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint StepId
        {
            get => stepId;
            set => stepId = value;
        }

        [D2OIgnore]
        public int LevelMin
        {
            get => levelMin;
            set => levelMin = value;
        }

        [D2OIgnore]
        public int LevelMax
        {
            get => levelMax;
            set => levelMax = value;
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
        public List<List<uint>> ItemsReward
        {
            get => itemsReward;
            set => itemsReward = value;
        }

        [D2OIgnore]
        public List<uint> EmotesReward
        {
            get => emotesReward;
            set => emotesReward = value;
        }

        [D2OIgnore]
        public List<uint> JobsReward
        {
            get => jobsReward;
            set => jobsReward = value;
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

        int IIndexedData.Id => (int) id;
    }
}