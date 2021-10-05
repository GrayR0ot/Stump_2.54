using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("MonsterDropCoefficient", "com.ankamagames.dofus.datacenter.monsters")]
    [Serializable]
    public class MonsterDropCoefficient : IDataObject, IIndexedData
    {
        public string criteria;
        public double dropCoefficient;
        public uint monsterGrade;
        public uint monsterId;

        [D2OIgnore]
        public uint MonsterId
        {
            get => monsterId;
            set => monsterId = value;
        }

        [D2OIgnore]
        public uint MonsterGrade
        {
            get => monsterGrade;
            set => monsterGrade = value;
        }

        [D2OIgnore]
        public double DropCoefficient
        {
            get => dropCoefficient;
            set => dropCoefficient = value;
        }

        [D2OIgnore]
        public string Criteria
        {
            get => criteria;
            set => criteria = value;
        }

        int IIndexedData.Id => (int) monsterId;
    }
}