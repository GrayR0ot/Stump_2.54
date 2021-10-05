using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("VeteranReward", "com.ankamagames.dofus.datacenter.items")]
    [Serializable]
    public class VeteranReward : IDataObject, IIndexedData
    {
        public const string MODULE = "VeteranRewards";
        public int id;
        public uint itemGID;
        public uint itemQuantity;
        public uint requiredSubDays;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint RequiredSubDays
        {
            get => requiredSubDays;
            set => requiredSubDays = value;
        }

        [D2OIgnore]
        public uint ItemGID
        {
            get => itemGID;
            set => itemGID = value;
        }

        [D2OIgnore]
        public uint ItemQuantity
        {
            get => itemQuantity;
            set => itemQuantity = value;
        }

        int IIndexedData.Id => id;
    }
}