using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("CharacteristicCategory", "com.ankamagames.dofus.datacenter.characteristics")]
    [Serializable]
    public class CharacteristicCategory : IDataObject, IIndexedData
    {
        public const string MODULE = "CharacteristicCategories";
        public List<uint> characteristicIds;
        public int id;

        [I18NField] public uint nameId;

        public int order;

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
        public int Order
        {
            get => order;
            set => order = value;
        }

        [D2OIgnore]
        public List<uint> CharacteristicIds
        {
            get => characteristicIds;
            set => characteristicIds = value;
        }

        int IIndexedData.Id => id;
    }
}