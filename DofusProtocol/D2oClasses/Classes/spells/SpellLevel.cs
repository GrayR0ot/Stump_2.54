using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SpellLevel", "com.ankamagames.dofus.datacenter.spells")]
    [Serializable]
    public class SpellLevel : IDataObject, IIndexedData
    {
        public const string MODULE = "SpellLevels";
        public List<string> additionalEffectsZones;
        public uint apCost;
        public bool castInDiagonal;
        public bool castInLine;
        public bool castTestLos;
        public List<EffectInstanceDice> criticalEffect;
        public uint criticalHitProbability;
        public List<EffectInstanceDice> effects;
        public int globalCooldown;
        public uint grade;
        public bool hidden;
        public bool hideEffects;
        public uint id;
        public uint initialCooldown;
        public uint maxCastPerTarget;
        public uint maxCastPerTurn;
        public int maxStack;
        public uint minCastInterval;
        public uint minPlayerLevel;
        public uint minRange;
        public bool needFreeCell;
        public bool needFreeTrapCell;
        public bool needTakenCell;
        public bool playAnimation;
        public uint range;
        public bool rangeCanBeBoosted;
        public uint spellBreed;
        public uint spellId;
        public List<int> statesAuthorized;
        public List<int> statesForbidden;
        public List<int> statesRequired;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint SpellId
        {
            get => spellId;
            set => spellId = value;
        }

        [D2OIgnore]
        public uint Grade
        {
            get => grade;
            set => grade = value;
        }

        [D2OIgnore]
        public uint SpellBreed
        {
            get => spellBreed;
            set => spellBreed = value;
        }

        [D2OIgnore]
        public uint ApCost
        {
            get => apCost;
            set => apCost = value;
        }

        [D2OIgnore]
        public uint MinRange
        {
            get => minRange;
            set => minRange = value;
        }

        [D2OIgnore]
        public uint Range
        {
            get => range;
            set => range = value;
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
        public uint CriticalHitProbability
        {
            get => criticalHitProbability;
            set => criticalHitProbability = value;
        }

        [D2OIgnore]
        public bool NeedFreeCell
        {
            get => needFreeCell;
            set => needFreeCell = value;
        }

        [D2OIgnore]
        public bool NeedTakenCell
        {
            get => needTakenCell;
            set => needTakenCell = value;
        }

        [D2OIgnore]
        public bool NeedFreeTrapCell
        {
            get => needFreeTrapCell;
            set => needFreeTrapCell = value;
        }

        [D2OIgnore]
        public bool RangeCanBeBoosted
        {
            get => rangeCanBeBoosted;
            set => rangeCanBeBoosted = value;
        }

        [D2OIgnore]
        public int MaxStack
        {
            get => maxStack;
            set => maxStack = value;
        }

        [D2OIgnore]
        public uint MaxCastPerTurn
        {
            get => maxCastPerTurn;
            set => maxCastPerTurn = value;
        }

        [D2OIgnore]
        public uint MaxCastPerTarget
        {
            get => maxCastPerTarget;
            set => maxCastPerTarget = value;
        }

        [D2OIgnore]
        public uint MinCastInterval
        {
            get => minCastInterval;
            set => minCastInterval = value;
        }

        [D2OIgnore]
        public uint InitialCooldown
        {
            get => initialCooldown;
            set => initialCooldown = value;
        }

        [D2OIgnore]
        public int GlobalCooldown
        {
            get => globalCooldown;
            set => globalCooldown = value;
        }

        [D2OIgnore]
        public uint MinPlayerLevel
        {
            get => minPlayerLevel;
            set => minPlayerLevel = value;
        }

        [D2OIgnore]
        public bool HideEffects
        {
            get => hideEffects;
            set => hideEffects = value;
        }

        [D2OIgnore]
        public bool Hidden
        {
            get => hidden;
            set => hidden = value;
        }

        [D2OIgnore]
        public bool PlayAnimation
        {
            get => playAnimation;
            set => playAnimation = value;
        }

        [D2OIgnore]
        public List<int> StatesRequired
        {
            get => statesRequired;
            set => statesRequired = value;
        }

        [D2OIgnore]
        public List<int> StatesAuthorized
        {
            get => statesAuthorized;
            set => statesAuthorized = value;
        }

        [D2OIgnore]
        public List<int> StatesForbidden
        {
            get => statesForbidden;
            set => statesForbidden = value;
        }

        [D2OIgnore]
        public List<EffectInstanceDice> Effects
        {
            get => effects;
            set => effects = value;
        }

        [D2OIgnore]
        public List<EffectInstanceDice> CriticalEffect
        {
            get => criticalEffect;
            set => criticalEffect = value;
        }

        [D2OIgnore]
        public List<string> AdditionalEffectsZones
        {
            get => additionalEffectsZones;
            set => additionalEffectsZones = value;
        }

        int IIndexedData.Id => (int) id;
    }
}