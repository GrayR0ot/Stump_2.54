using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("EffectInstanceMinMax", "com.ankamagames.dofus.datacenter.effects.instances")]
    [Serializable]
    public class EffectInstanceMinMax : EffectInstance
    {
        public uint max;
        public uint min;

        [D2OIgnore]
        public uint Min
        {
            get => min;
            set => min = value;
        }

        [D2OIgnore]
        public uint Max
        {
            get => max;
            set => max = value;
        }
    }
}