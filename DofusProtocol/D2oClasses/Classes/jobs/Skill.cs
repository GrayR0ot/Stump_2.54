using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Skill", "com.ankamagames.dofus.datacenter.jobs")]
    [Serializable]
    public class Skill : IDataObject, IIndexedData
    {
        public const string MODULE = "Skills";
        public bool availableInHouse;
        public bool clientDisplay;
        public List<int> craftableItemIds;
        public int cursor;
        public int elementActionId;
        public int gatheredRessourceItem;
        public int id;
        public int interactiveId;
        public bool isForgemagus;
        public uint levelMin;
        public List<int> modifiableItemTypeIds;

        [I18NField] public uint nameId;

        public int parentJobId;
        public int range;
        public string useAnimation;
        public bool useRangeInClient;

        [D2OIgnore]
        public int Id
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
        public int ParentJobId
        {
            get => parentJobId;
            set => parentJobId = value;
        }

        [D2OIgnore]
        public bool IsForgemagus
        {
            get => isForgemagus;
            set => isForgemagus = value;
        }

        [D2OIgnore]
        public List<int> ModifiableItemTypeIds
        {
            get => modifiableItemTypeIds;
            set => modifiableItemTypeIds = value;
        }

        [D2OIgnore]
        public int GatheredRessourceItem
        {
            get => gatheredRessourceItem;
            set => gatheredRessourceItem = value;
        }

        [D2OIgnore]
        public List<int> CraftableItemIds
        {
            get => craftableItemIds;
            set => craftableItemIds = value;
        }

        [D2OIgnore]
        public int InteractiveId
        {
            get => interactiveId;
            set => interactiveId = value;
        }

        [D2OIgnore]
        public int Range
        {
            get => range;
            set => range = value;
        }

        [D2OIgnore]
        public bool UseRangeInClient
        {
            get => useRangeInClient;
            set => useRangeInClient = value;
        }

        [D2OIgnore]
        public string UseAnimation
        {
            get => useAnimation;
            set => useAnimation = value;
        }

        [D2OIgnore]
        public int Cursor
        {
            get => cursor;
            set => cursor = value;
        }

        [D2OIgnore]
        public int ElementActionId
        {
            get => elementActionId;
            set => elementActionId = value;
        }

        [D2OIgnore]
        public bool AvailableInHouse
        {
            get => availableInHouse;
            set => availableInHouse = value;
        }

        [D2OIgnore]
        public uint LevelMin
        {
            get => levelMin;
            set => levelMin = value;
        }

        [D2OIgnore]
        public bool ClientDisplay
        {
            get => clientDisplay;
            set => clientDisplay = value;
        }

        int IIndexedData.Id => id;
    }
}