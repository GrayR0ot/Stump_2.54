using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("TitleCategory", "com.ankamagames.dofus.datacenter.appearance")]
    [Serializable]
    public class TitleCategory : IDataObject, IIndexedData
    {
        public const string MODULE = "TitleCategories";
        public int id;

        [I18NField] public uint nameId;

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

        int IIndexedData.Id => id;
    }
}