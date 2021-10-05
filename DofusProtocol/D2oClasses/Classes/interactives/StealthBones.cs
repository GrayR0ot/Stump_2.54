using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("StealthBones", "com.ankamagames.dofus.datacenter.interactives")]
    [Serializable]
    public class StealthBones : IDataObject, IIndexedData
    {
        public const string MODULE = "StealthBones";
        public uint id;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        int IIndexedData.Id => (int) id;
    }
}