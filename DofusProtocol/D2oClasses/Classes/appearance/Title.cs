using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Title", "com.ankamagames.dofus.datacenter.appearance")]
    [Serializable]
    public class Title : IDataObject, IIndexedData
    {
        public const string MODULE = "Titles";
        public int categoryId;
        public int id;

        [I18NField] public uint nameFemaleId;

        [I18NField] public uint nameMaleId;

        public bool visible;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint NameMaleId
        {
            get => nameMaleId;
            set => nameMaleId = value;
        }

        [D2OIgnore]
        public uint NameFemaleId
        {
            get => nameFemaleId;
            set => nameFemaleId = value;
        }

        [D2OIgnore]
        public bool Visible
        {
            get => visible;
            set => visible = value;
        }

        [D2OIgnore]
        public int CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        int IIndexedData.Id => id;
    }
}