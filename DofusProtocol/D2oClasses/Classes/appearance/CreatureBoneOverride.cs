using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("CreatureBoneOverride", "com.ankamagames.dofus.datacenter.appearance")]
    [Serializable]
    public class CreatureBoneOverride : IDataObject, IIndexedData
    {
        public const string MODULE = "CreatureBonesOverrides";
        public int boneId;
        public int creatureBoneId;

        [D2OIgnore]
        public int BoneId
        {
            get => boneId;
            set => boneId = value;
        }

        [D2OIgnore]
        public int CreatureBoneId
        {
            get => creatureBoneId;
            set => creatureBoneId = value;
        }

        int IIndexedData.Id => boneId;
    }
}