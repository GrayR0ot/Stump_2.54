using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("MountBone", "com.ankamagames.dofus.datacenter.mounts")]
    [Serializable]
    public class MountBone : IDataObject, IIndexedData
    {
        public uint id;
        private string MODULE = "MountBones";

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        int IIndexedData.Id => (int) id;
    }
}