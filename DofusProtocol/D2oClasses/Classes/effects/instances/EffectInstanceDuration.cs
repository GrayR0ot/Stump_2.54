using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("EffectInstanceDuration", "com.ankamagames.dofus.datacenter.effects.instances")]
    [Serializable]
    public class EffectInstanceDuration : EffectInstance
    {
        public uint days;
        public uint hours;
        public uint minutes;

        [D2OIgnore]
        public uint Days
        {
            get => days;
            set => days = value;
        }

        [D2OIgnore]
        public uint Hours
        {
            get => hours;
            set => hours = value;
        }

        [D2OIgnore]
        public uint Minutes
        {
            get => minutes;
            set => minutes = value;
        }
    }
}