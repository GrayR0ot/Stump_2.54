using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("RideFood", "com.ankamagames.dofus.datacenter.mounts")]
    [Serializable]
    public class RideFood : IDataObject
    {
        public uint familyId;
        public uint gid;
        public string MODULE = "RideFood";
        public uint typeId;

        [D2OIgnore]
        public uint Gid
        {
            get => gid;
            set => gid = value;
        }

        [D2OIgnore]
        public uint TypeId
        {
            get => typeId;
            set => typeId = value;
        }

        [D2OIgnore]
        public uint FamilyId
        {
            get => familyId;
            set => familyId = value;
        }
    }
}