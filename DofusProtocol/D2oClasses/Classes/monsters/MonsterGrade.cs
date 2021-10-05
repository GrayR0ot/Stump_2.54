using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("MonsterGrade", "com.ankamagames.dofus.datacenter.monsters")]
    [Serializable]
    public class MonsterGrade : IDataObject, IIndexedData
    {
        public int actionPoints;
        public int agility;
        public int airResistance;
        public int chance;
        public int damageReflect;
        public int earthResistance;
        public int fireResistance;
        public uint grade;
        public int gradeXp;
        public uint hiddenLevel;
        public int intelligence;
        public uint level;
        public int lifePoints;
        public int monsterId;
        public int movementPoints;
        public int neutralResistance;
        public int paDodge;
        public int pmDodge;
        public int strength;
        public int vitality;
        public int waterResistance;
        public int wisdom;

        [D2OIgnore]
        public uint Grade
        {
            get => grade;
            set => grade = value;
        }

        [D2OIgnore]
        public int MonsterId
        {
            get => monsterId;
            set => monsterId = value;
        }

        [D2OIgnore]
        public uint Level
        {
            get => level;
            set => level = value;
        }

        [D2OIgnore]
        public int Vitality
        {
            get => vitality;
            set => vitality = value;
        }

        [D2OIgnore]
        public int PaDodge
        {
            get => paDodge;
            set => paDodge = value;
        }

        [D2OIgnore]
        public int PmDodge
        {
            get => pmDodge;
            set => pmDodge = value;
        }

        [D2OIgnore]
        public int Wisdom
        {
            get => wisdom;
            set => wisdom = value;
        }

        [D2OIgnore]
        public int EarthResistance
        {
            get => earthResistance;
            set => earthResistance = value;
        }

        [D2OIgnore]
        public int AirResistance
        {
            get => airResistance;
            set => airResistance = value;
        }

        [D2OIgnore]
        public int FireResistance
        {
            get => fireResistance;
            set => fireResistance = value;
        }

        [D2OIgnore]
        public int WaterResistance
        {
            get => waterResistance;
            set => waterResistance = value;
        }

        [D2OIgnore]
        public int NeutralResistance
        {
            get => neutralResistance;
            set => neutralResistance = value;
        }

        [D2OIgnore]
        public int GradeXp
        {
            get => gradeXp;
            set => gradeXp = value;
        }

        [D2OIgnore]
        public int LifePoints
        {
            get => lifePoints;
            set => lifePoints = value;
        }

        [D2OIgnore]
        public int ActionPoints
        {
            get => actionPoints;
            set => actionPoints = value;
        }

        [D2OIgnore]
        public int MovementPoints
        {
            get => movementPoints;
            set => movementPoints = value;
        }

        [D2OIgnore]
        public int DamageReflect
        {
            get => damageReflect;
            set => damageReflect = value;
        }

        [D2OIgnore]
        public uint HiddenLevel
        {
            get => hiddenLevel;
            set => hiddenLevel = value;
        }

        [D2OIgnore]
        public int Strength
        {
            get => strength;
            set => strength = value;
        }

        [D2OIgnore]
        public int Intelligence
        {
            get => intelligence;
            set => intelligence = value;
        }

        [D2OIgnore]
        public int Chance
        {
            get => chance;
            set => chance = value;
        }

        [D2OIgnore]
        public int Agility
        {
            get => agility;
            set => agility = value;
        }

        int IIndexedData.Id => monsterId;
    }
}