using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Tips", "com.ankamagames.dofus.datacenter.misc")]
    [Serializable]
    public class Tips : IDataObject, IIndexedData
    {
        public const string MODULE = "Tips";

        [I18NField] public uint descId;

        public int id;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint DescId
        {
            get => descId;
            set => descId = value;
        }

        int IIndexedData.Id => id;
    }
}