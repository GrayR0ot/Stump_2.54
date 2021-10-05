// Generated on 03/27/2020 01:22:45

using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses.Classes.misc
{
    [D2OClass("BreachBoss", "com.ankamagames.dofus.datacenter.misc")]
    [Serializable]
    public class BreachBoss : IDataObject, IIndexedData
    {
        public const string MODULE = "BreachBosses";
        public string accessCriterion;
        public string apparitionCriterion;
        public int category;
        public int id;
        public List<int> incompatibleBosses;
        public int maxRewardQuantity;
        public int monsterId;
        public uint rewardId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int MonsterId
        {
            get => monsterId;
            set => monsterId = value;
        }

        [D2OIgnore]
        public int Category
        {
            get => category;
            set => category = value;
        }

        [D2OIgnore]
        public string ApparitionCriterion
        {
            get => apparitionCriterion;
            set => apparitionCriterion = value;
        }

        [D2OIgnore]
        public string AccessCriterion
        {
            get => accessCriterion;
            set => accessCriterion = value;
        }

        [D2OIgnore]
        public int MaxRewardQuantity
        {
            get => maxRewardQuantity;
            set => maxRewardQuantity = value;
        }

        [D2OIgnore]
        public List<int> IncompatibleBosses
        {
            get => incompatibleBosses;
            set => incompatibleBosses = value;
        }

        [D2OIgnore]
        public uint RewardId
        {
            get => rewardId;
            set => rewardId = value;
        }

        int IIndexedData.Id => id;
    }
}