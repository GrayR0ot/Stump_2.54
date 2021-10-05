using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("MountFamily", "com.ankamagames.dofus.datacenter.mounts")]
    [Serializable]
    public class MountFamily : IDataObject, IIndexedData
    {
        public string headUri;
        public uint id;
        private string MODULE = "MountFamily";

        [I18NField] public uint nameId;

        [D2OIgnore]
        public uint Id
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
        public string HeadUri
        {
            get => headUri;
            set => headUri = value;
        }

        int IIndexedData.Id => (int) id;
    }
}