using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Appearance", "com.ankamagames.dofus.datacenter.appearance")]
    [Serializable]
    public class Appearance : IDataObject, IIndexedData
    {
        public const string MODULE = "Appearances";
        public string data;
        public uint id;
        public uint type;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint Type
        {
            get => type;
            set => type = value;
        }

        [D2OIgnore]
        public string Data
        {
            get => data;
            set => data = value;
        }

        int IIndexedData.Id => (int) id;
    }
}