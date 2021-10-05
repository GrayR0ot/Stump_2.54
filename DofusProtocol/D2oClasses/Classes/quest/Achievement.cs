using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Achievement", "com.ankamagames.dofus.datacenter.quest")]
    [Serializable]
    public class Achievement : IDataObject, IIndexedData
    {
        public const string MODULE = "Achievements";
        public bool accountLinked;
        public uint categoryId;

        [I18NField] public uint descriptionId;

        public int iconId;
        public uint id;
        public uint level;

        [I18NField] public uint nameId;

        public List<int> objectiveIds;
        public uint order;
        public uint points;
        public List<int> rewardIds;

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
        public uint CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        [D2OIgnore]
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        [D2OIgnore]
        public int IconId
        {
            get => iconId;
            set => iconId = value;
        }

        [D2OIgnore]
        public uint Points
        {
            get => points;
            set => points = value;
        }

        [D2OIgnore]
        public uint Level
        {
            get => level;
            set => level = value;
        }

        [D2OIgnore]
        public uint Order
        {
            get => order;
            set => order = value;
        }

        [D2OIgnore]
        public bool AccountLinked
        {
            get => accountLinked;
            set => accountLinked = value;
        }

        [D2OIgnore]
        public List<int> ObjectiveIds
        {
            get => objectiveIds;
            set => objectiveIds = value;
        }

        [D2OIgnore]
        public List<int> RewardIds
        {
            get => rewardIds;
            set => rewardIds = value;
        }

        int IIndexedData.Id => (int) id;
    }
}