using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("QuestStep", "com.ankamagames.dofus.datacenter.quest")]
    [Serializable]
    public class QuestStep : IDataObject, IIndexedData
    {
        public const string MODULE = "QuestSteps";

        [I18NField] public uint descriptionId;

        public int dialogId;
        public double duration;
        public uint id;

        [I18NField] public uint nameId;

        public List<uint> objectiveIds;
        public uint optimalLevel;
        public uint questId;
        public List<uint> rewardsIds;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint QuestId
        {
            get => questId;
            set => questId = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        [D2OIgnore]
        public int DialogId
        {
            get => dialogId;
            set => dialogId = value;
        }

        [D2OIgnore]
        public uint OptimalLevel
        {
            get => optimalLevel;
            set => optimalLevel = value;
        }

        [D2OIgnore]
        public double Duration
        {
            get => duration;
            set => duration = value;
        }

        [D2OIgnore]
        public List<uint> ObjectiveIds
        {
            get => objectiveIds;
            set => objectiveIds = value;
        }

        [D2OIgnore]
        public List<uint> RewardsIds
        {
            get => rewardsIds;
            set => rewardsIds = value;
        }

        int IIndexedData.Id => (int) id;
    }
}