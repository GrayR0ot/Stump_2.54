using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Quest", "com.ankamagames.dofus.datacenter.quest")]
    [Serializable]
    public class Quest : IDataObject, IIndexedData
    {
        public const string MODULE = "Quests";
        public uint categoryId;
        public bool followable;
        public uint id;
        public bool isDungeonQuest;
        public bool isPartyQuest;
        public uint levelMax;
        public uint levelMin;

        [I18NField] public uint nameId;

        public uint repeatLimit;
        public uint repeatType;
        public string startCriterion;
        public List<uint> stepIds;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public List<uint> StepIds
        {
            get => stepIds;
            set => stepIds = value;
        }

        [D2OIgnore]
        public uint CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        [D2OIgnore]
        public uint RepeatType
        {
            get => repeatType;
            set => repeatType = value;
        }

        [D2OIgnore]
        public uint RepeatLimit
        {
            get => repeatLimit;
            set => repeatLimit = value;
        }

        [D2OIgnore]
        public bool IsDungeonQuest
        {
            get => isDungeonQuest;
            set => isDungeonQuest = value;
        }

        [D2OIgnore]
        public uint LevelMin
        {
            get => levelMin;
            set => levelMin = value;
        }

        [D2OIgnore]
        public uint LevelMax
        {
            get => levelMax;
            set => levelMax = value;
        }

        [D2OIgnore]
        public bool IsPartyQuest
        {
            get => isPartyQuest;
            set => isPartyQuest = value;
        }

        [D2OIgnore]
        public string StartCriterion
        {
            get => startCriterion;
            set => startCriterion = value;
        }

        [D2OIgnore]
        public bool Followable
        {
            get => followable;
            set => followable = value;
        }

        int IIndexedData.Id => (int) id;
    }
}