using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("MonsterRace", "com.ankamagames.dofus.datacenter.monsters")]
    [Serializable]
    public class MonsterRace : IDataObject, IIndexedData
    {
        public const string MODULE = "MonsterRaces";
        public int aggressiveAttackDelay;
        public string aggressiveImmunityCriterion;
        public int aggressiveLevelDiff;
        public int aggressiveZoneSize;
        public int id;
        public List<uint> monsters;

        [I18NField] public uint nameId;

        public int superRaceId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int SuperRaceId
        {
            get => superRaceId;
            set => superRaceId = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public List<uint> Monsters
        {
            get => monsters;
            set => monsters = value;
        }

        [D2OIgnore]
        public int AggressiveZoneSize
        {
            get => aggressiveZoneSize;
            set => aggressiveZoneSize = value;
        }

        [D2OIgnore]
        public int AggressiveLevelDiff
        {
            get => aggressiveLevelDiff;
            set => aggressiveLevelDiff = value;
        }

        [D2OIgnore]
        public string AggressiveImmunityCriterion
        {
            get => aggressiveImmunityCriterion;
            set => aggressiveImmunityCriterion = value;
        }

        [D2OIgnore]
        public int AggressiveAttackDelay
        {
            get => aggressiveAttackDelay;
            set => aggressiveAttackDelay = value;
        }

        int IIndexedData.Id => id;
    }
}