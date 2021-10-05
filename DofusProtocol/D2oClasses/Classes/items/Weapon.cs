using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Weapon", "com.ankamagames.dofus.datacenter.items")]
    [Serializable]
    public class Weapon : Item
    {
        public int apCost;
        public bool castInDiagonal;
        public bool castInLine;
        public bool castTestLos;
        public int criticalFailureProbability;
        public int criticalHitBonus;
        public int criticalHitProbability;
        public uint maxCastPerTurn;
        public int minRange;
        public int range;

        [D2OIgnore]
        public int ApCost
        {
            get => apCost;
            set => apCost = value;
        }

        [D2OIgnore]
        public int MinRange
        {
            get => minRange;
            set => minRange = value;
        }

        [D2OIgnore]
        public int Range
        {
            get => range;
            set => range = value;
        }

        [D2OIgnore]
        public uint MaxCastPerTurn
        {
            get => maxCastPerTurn;
            set => maxCastPerTurn = value;
        }

        [D2OIgnore]
        public bool CastInLine
        {
            get => castInLine;
            set => castInLine = value;
        }

        [D2OIgnore]
        public bool CastInDiagonal
        {
            get => castInDiagonal;
            set => castInDiagonal = value;
        }

        [D2OIgnore]
        public bool CastTestLos
        {
            get => castTestLos;
            set => castTestLos = value;
        }

        [D2OIgnore]
        public int CriticalHitProbability
        {
            get => criticalHitProbability;
            set => criticalHitProbability = value;
        }

        [D2OIgnore]
        public int CriticalHitBonus
        {
            get => criticalHitBonus;
            set => criticalHitBonus = value;
        }

        [D2OIgnore]
        public int CriticalFailureProbability
        {
            get => criticalFailureProbability;
            set => criticalFailureProbability = value;
        }
    }
}