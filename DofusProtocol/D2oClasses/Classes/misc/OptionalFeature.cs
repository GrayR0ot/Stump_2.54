using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("OptionalFeature", "com.ankamagames.dofus.datacenter.misc")]
    [Serializable]
    public class OptionalFeature : IDataObject, IIndexedData
    {
        public const string MODULE = "OptionalFeatures";
        public int id;
        public string keyword;

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

        int IIndexedData.Id => id;
    }
}