using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SkinPosition", "com.ankamagames.dofus.datacenter.appearance")]
    [Serializable]
    public class SkinPosition : IDataObject, IIndexedData
    {
        private const string MODULE = "SkinPositions";
        public List<string> clip;
        public uint id;
        public List<uint> skin;
        public List<TransformData> transformation;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public List<TransformData> Transformation
        {
            get => transformation;
            set => transformation = value;
        }

        [D2OIgnore]
        public List<string> Clip
        {
            get => clip;
            set => clip = value;
        }

        [D2OIgnore]
        public List<uint> Skin
        {
            get => skin;
            set => skin = value;
        }

        int IIndexedData.Id => (int) id;
    }
}