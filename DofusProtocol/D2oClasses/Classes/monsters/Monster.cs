using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;
using WorldEditor.D2OClasses;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Monster", "com.ankamagames.dofus.datacenter.monsters")]
    [Serializable]
    public class Monster : IDataObject, IIndexedData
    {
        public const string MODULE = "Monsters";
        public int aggressiveAttackDelay;
        public string aggressiveImmunityCriterion;
        public int aggressiveLevelDiff;
        public int aggressiveZoneSize;
        public bool allIdolsDisabled;
        public List<AnimFunMonsterData> animFunList;
        public bool canBeCarried;
        public bool canBePushed;
        public bool canBeTackled;
        public bool canPlay;
        public bool canSwitchPos;
        public bool canTackle;
        public bool canUsePortal;
        public uint correspondingMiniBossId;
        public int creatureBoneId;
        public bool dareAvailable;
        public List<MonsterDrop> drops;
        public bool fastAnimsFun;
        public int favoriteSubareaId;
        public uint gfxId;
        public List<MonsterGrade> grades;
        public int id;
        public List<uint> incompatibleChallenges;
        public List<uint> incompatibleIdols;
        public bool isBoss;
        public bool isMiniBoss;
        public bool isQuestMonster;
        public string look;

        [I18NField] public uint nameId;

        public int race;
        public double speedAdjust;
        public List<uint> spells;
        public List<uint> subareas;
        public List<MonsterDrop> temporisDrops;
        public bool useBombSlot;
        public bool useRaceValues;
        public bool useSummonSlot;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public uint GfxId
        {
            get => gfxId;
            set => gfxId = value;
        }

        [D2OIgnore]
        public int Race
        {
            get => race;
            set => race = value;
        }

        [D2OIgnore]
        public List<MonsterGrade> Grades
        {
            get => grades;
            set => grades = value;
        }

        [D2OIgnore]
        public string Look
        {
            get => look;
            set => look = value;
        }

        [D2OIgnore]
        public bool UseSummonSlot
        {
            get => useSummonSlot;
            set => useSummonSlot = value;
        }

        [D2OIgnore]
        public bool UseBombSlot
        {
            get => useBombSlot;
            set => useBombSlot = value;
        }

        [D2OIgnore]
        public bool CanPlay
        {
            get => canPlay;
            set => canPlay = value;
        }

        [D2OIgnore]
        public bool CanTackle
        {
            get => canTackle;
            set => canTackle = value;
        }

        [D2OIgnore]
        public List<AnimFunMonsterData> AnimFunList
        {
            get => animFunList;
            set => animFunList = value;
        }

        [D2OIgnore]
        public bool IsBoss
        {
            get => isBoss;
            set => isBoss = value;
        }

        [D2OIgnore]
        public List<MonsterDrop> Drops
        {
            get => drops;
            set => drops = value;
        }

        [D2OIgnore]
        public List<MonsterDrop> TemporisDrops
        {
            get => temporisDrops;
            set => temporisDrops = value;
        }

        [D2OIgnore]
        public List<uint> Subareas
        {
            get => subareas;
            set => subareas = value;
        }

        [D2OIgnore]
        public List<uint> Spells
        {
            get => spells;
            set => spells = value;
        }

        [D2OIgnore]
        public int FavoriteSubareaId
        {
            get => favoriteSubareaId;
            set => favoriteSubareaId = value;
        }

        [D2OIgnore]
        public bool IsMiniBoss
        {
            get => isMiniBoss;
            set => isMiniBoss = value;
        }

        [D2OIgnore]
        public bool IsQuestMonster
        {
            get => isQuestMonster;
            set => isQuestMonster = value;
        }

        [D2OIgnore]
        public uint CorrespondingMiniBossId
        {
            get => correspondingMiniBossId;
            set => correspondingMiniBossId = value;
        }

        [D2OIgnore]
        public double SpeedAdjust
        {
            get => speedAdjust;
            set => speedAdjust = value;
        }

        [D2OIgnore]
        public int CreatureBoneId
        {
            get => creatureBoneId;
            set => creatureBoneId = value;
        }

        [D2OIgnore]
        public bool CanBePushed
        {
            get => canBePushed;
            set => canBePushed = value;
        }

        [D2OIgnore]
        public bool CanBeCarried
        {
            get => canBeCarried;
            set => canBeCarried = value;
        }

        [D2OIgnore]
        public bool CanUsePortal
        {
            get => canUsePortal;
            set => canUsePortal = value;
        }

        [D2OIgnore]
        public bool CanSwitchPos
        {
            get => canSwitchPos;
            set => canSwitchPos = value;
        }

        [D2OIgnore]
        public bool FastAnimsFun
        {
            get => fastAnimsFun;
            set => fastAnimsFun = value;
        }

        [D2OIgnore]
        public List<uint> IncompatibleIdols
        {
            get => incompatibleIdols;
            set => incompatibleIdols = value;
        }

        [D2OIgnore]
        public bool AllIdolsDisabled
        {
            get => allIdolsDisabled;
            set => allIdolsDisabled = value;
        }

        [D2OIgnore]
        public bool DareAvailable
        {
            get => dareAvailable;
            set => dareAvailable = value;
        }

        [D2OIgnore]
        public List<uint> IncompatibleChallenges
        {
            get => incompatibleChallenges;
            set => incompatibleChallenges = value;
        }

        [D2OIgnore]
        public bool UseRaceValues
        {
            get => useRaceValues;
            set => useRaceValues = value;
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