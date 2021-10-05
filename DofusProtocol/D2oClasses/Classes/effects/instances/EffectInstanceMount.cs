using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("EffectInstanceMount", "com.ankamagames.dofus.datacenter.effects.instances")]
    [Serializable]
    public class EffectInstanceMount : EffectInstance
    {
        public List<uint> capacities;
        public List<EffectInstanceInteger> effects;
        public double expirationDate;
        public double id;
        public bool isFecondationReady;
        public bool isFeconded;
        public bool isRideable;
        public uint level;
        public uint model;
        public string name = "";
        public string owner = "";
        public int reproductionCount;
        public uint reproductionCountMax;
        public bool sex;

        [D2OIgnore]
        public double Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public double ExpirationDate
        {
            get => expirationDate;
            set => expirationDate = value;
        }

        [D2OIgnore]
        public uint Model
        {
            get => model;
            set => model = value;
        }

        [D2OIgnore]
        public string Name
        {
            get => name;
            set => name = value;
        }

        [D2OIgnore]
        public string Owner
        {
            get => owner;
            set => owner = value;
        }

        [D2OIgnore]
        public uint Level
        {
            get => level;
            set => level = value;
        }

        [D2OIgnore]
        public bool Sex
        {
            get => sex;
            set => sex = value;
        }

        [D2OIgnore]
        public bool IsRideable
        {
            get => isRideable;
            set => isRideable = value;
        }

        [D2OIgnore]
        public bool IsFeconded
        {
            get => isFeconded;
            set => isFeconded = value;
        }

        [D2OIgnore]
        public bool IsFecondationReady
        {
            get => isFecondationReady;
            set => isFecondationReady = value;
        }

        [D2OIgnore]
        public int ReproductionCount
        {
            get => reproductionCount;
            set => reproductionCount = value;
        }

        [D2OIgnore]
        public uint ReproductionCountMax
        {
            get => reproductionCountMax;
            set => reproductionCountMax = value;
        }

        [D2OIgnore]
        public List<EffectInstanceInteger> Effects
        {
            get => effects;
            set => effects = value;
        }

        [D2OIgnore]
        public List<uint> Capacities
        {
            get => capacities;
            set => capacities = value;
        }
    }
}