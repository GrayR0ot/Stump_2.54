using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("House", "com.ankamagames.dofus.datacenter.houses")]
    [Serializable]
    public class House : IDataObject, IIndexedData
    {
        public const string MODULE = "Houses";
        public uint defaultPrice;

        [I18NField] public int descriptionId;

        public int gfxId;

        [I18NField] public int nameId;

        public int typeId;

        [D2OIgnore]
        public int TypeId
        {
            get => typeId;
            set => typeId = value;
        }

        [D2OIgnore]
        public uint DefaultPrice
        {
            get => defaultPrice;
            set => defaultPrice = value;
        }

        [D2OIgnore]
        public int NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public int DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        [D2OIgnore]
        public int GfxId
        {
            get => gfxId;
            set => gfxId = value;
        }

        int IIndexedData.Id => nameId;
    }
}