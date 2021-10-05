using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("MonsterMiniBoss", "com.ankamagames.dofus.datacenter.monsters")]
    [Serializable]
    public class MonsterMiniBoss : IDataObject, IIndexedData
    {
        public const string MODULE = "MonsterMiniBoss";
        public int id;
        public int monsterReplacingId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int MonsterReplacingId
        {
            get => monsterReplacingId;
            set => monsterReplacingId = value;
        }

        int IIndexedData.Id => id;
    }
}