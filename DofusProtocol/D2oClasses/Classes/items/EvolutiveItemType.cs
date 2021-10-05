using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("EvolutiveItemType", "com.ankamagames.dofus.datacenter.items")]
    [Serializable]
    public class EvolutiveItemType : IDataObject, IIndexedData
    {
        public const string MODULE = "EvolutiveItemTypes";
        public double experienceBoost;
        public List<int> experienceByLevel;
        public int id;
        public uint maxLevel;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint MaxLevel
        {
            get => maxLevel;
            set => maxLevel = value;
        }

        [D2OIgnore]
        public double ExperienceBoost
        {
            get => experienceBoost;
            set => experienceBoost = value;
        }

        [D2OIgnore]
        public List<int> ExperienceByLevel
        {
            get => experienceByLevel;
            set => experienceByLevel = value;
        }

        int IIndexedData.Id => id;
    }
}