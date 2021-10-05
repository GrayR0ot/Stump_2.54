using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Characteristic", "com.ankamagames.dofus.datacenter.characteristics")]
    [Serializable]
    public class Characteristic : IDataObject, IIndexedData
    {
        public const string MODULE = "Characteristics";
        public string asset;
        public int categoryId;
        public int id;
        public string keyword;

        [I18NField] public uint nameId;

        public int order;
        public bool upgradable;
        public bool visible;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public string Keyword
        {
            get => keyword;
            set => keyword = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public string Asset
        {
            get => asset;
            set => asset = value;
        }

        [D2OIgnore]
        public int CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        [D2OIgnore]
        public bool Visible
        {
            get => visible;
            set => visible = value;
        }

        [D2OIgnore]
        public int Order
        {
            get => order;
            set => order = value;
        }

        [D2OIgnore]
        public bool Upgradable
        {
            get => upgradable;
            set => upgradable = value;
        }

        int IIndexedData.Id => id;
    }
}