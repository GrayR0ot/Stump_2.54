using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("LivingObjectSkinJntMood", "com.ankamagames.dofus.datacenter.livingObjects")]
    [Serializable]
    public class LivingObjectSkinJntMood : IDataObject, IIndexedData
    {
        public const string MODULE = "LivingObjectSkinJntMood";
        public List<List<int>> moods;
        public int skinId;

        [D2OIgnore]
        public int SkinId
        {
            get => skinId;
            set => skinId = value;
        }

        [D2OIgnore]
        public List<List<int>> Moods
        {
            get => moods;
            set => moods = value;
        }

        int IIndexedData.Id => skinId;
    }
}