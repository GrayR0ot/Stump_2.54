using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SoundBones", "com.ankamagames.dofus.datacenter.sounds")]
    [Serializable]
    public class SoundBones : IDataObject, IIndexedData
    {
        public uint id;
        public List<string> keys;
        public string MODULE = "SoundBones";
        public List<List<SoundAnimation>> values;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public List<string> Keys
        {
            get => keys;
            set => keys = value;
        }

        [D2OIgnore]
        public List<List<SoundAnimation>> Values
        {
            get => values;
            set => values = value;
        }

        int IIndexedData.Id => (int) id;
    }
}