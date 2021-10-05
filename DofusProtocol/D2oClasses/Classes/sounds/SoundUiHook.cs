using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SoundUiHook", "com.ankamagames.dofus.datacenter.sounds")]
    [Serializable]
    public class SoundUiHook : IDataObject, IIndexedData
    {
        public uint id;
        public string MODULE = "SoundUiHook";
        public string name;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public string Name
        {
            get => name;
            set => name = value;
        }

        int IIndexedData.Id => (int) id;
    }
}