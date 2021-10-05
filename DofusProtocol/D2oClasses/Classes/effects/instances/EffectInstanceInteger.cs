using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("EffectInstanceInteger", "com.ankamagames.dofus.datacenter.effects.instances")]
    [Serializable]
    public class EffectInstanceInteger : EffectInstance
    {
        public int value;

        [D2OIgnore]
        public int Value
        {
            get => value;
            set => this.value = value;
        }
    }
}