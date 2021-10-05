using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SkinMapping", "com.ankamagames.dofus.datacenter.appearance")]
    [Serializable]
    public class SkinMapping : IDataObject, IIndexedData
    {
        public const string MODULE = "SkinMappings";
        public int id;
        public int lowDefId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int LowDefId
        {
            get => lowDefId;
            set => lowDefId = value;
        }

        int IIndexedData.Id => id;
    }
}