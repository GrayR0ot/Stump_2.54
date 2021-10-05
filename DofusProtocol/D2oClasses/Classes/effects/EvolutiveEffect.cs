using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("EvolutiveEffect", "com.ankamagames.dofus.datacenter.effects")]
    [Serializable]
    public class EvolutiveEffect : IDataObject, IIndexedData
    {
        public const string MODULE = "EvolutiveEffects";
        public int actionId;
        public int id;
        public List<List<double>> progressionPerLevelRange;
        public int targetId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int ActionId
        {
            get => actionId;
            set => actionId = value;
        }

        [D2OIgnore]
        public int TargetId
        {
            get => targetId;
            set => targetId = value;
        }

        [D2OIgnore]
        public List<List<double>> ProgressionPerLevelRange
        {
            get => progressionPerLevelRange;
            set => progressionPerLevelRange = value;
        }

        int IIndexedData.Id => id;
    }
}