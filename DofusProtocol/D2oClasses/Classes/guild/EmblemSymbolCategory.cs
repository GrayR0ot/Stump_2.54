using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("EmblemSymbolCategory", "com.ankamagames.dofus.datacenter.guild")]
    [Serializable]
    public class EmblemSymbolCategory : IDataObject, IIndexedData
    {
        public const string MODULE = "EmblemSymbolCategories";
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