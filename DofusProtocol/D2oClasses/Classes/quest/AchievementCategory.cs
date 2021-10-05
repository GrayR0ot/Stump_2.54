using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AchievementCategory", "com.ankamagames.dofus.datacenter.quest")]
    [Serializable]
    public class AchievementCategory : IDataObject, IIndexedData
    {
        public const string MODULE = "AchievementCategories";
        public List<uint> achievementIds;
        public string color;
        public string icon;
        public uint id;

        [I18NField] public uint nameId;

        public uint order;
        public uint parentId;
        public string visibilityCriterion;

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
        public uint ParentId
        {
            get => parentId;
            set => parentId = value;
        }

        [D2OIgnore]
        public string Icon
        {
            get => icon;
            set => icon = value;
        }

        [D2OIgnore]
        public uint Order
        {
            get => order;
            set => order = value;
        }

        [D2OIgnore]
        public string Color
        {
            get => color;
            set => color = value;
        }

        [D2OIgnore]
        public List<uint> AchievementIds
        {
            get => achievementIds;
            set => achievementIds = value;
        }

        [D2OIgnore]
        public string VisibilityCriterion
        {
            get => visibilityCriterion;
            set => visibilityCriterion = value;
        }

        int IIndexedData.Id => (int) id;
    }
}