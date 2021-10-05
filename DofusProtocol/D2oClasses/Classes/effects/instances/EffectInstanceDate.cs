using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("EffectInstanceDate", "com.ankamagames.dofus.datacenter.effects.instances")]
    [Serializable]
    public class EffectInstanceDate : EffectInstance
    {
        public uint day;
        public uint hour;
        public uint minute;
        public uint month;
        public uint year;

        [D2OIgnore]
        public uint Year
        {
            get => year;
            set => year = value;
        }

        [D2OIgnore]
        public uint Month
        {
            get => month;
            set => month = value;
        }

        [D2OIgnore]
        public uint Day
        {
            get => day;
            set => day = value;
        }

        [D2OIgnore]
        public uint Hour
        {
            get => hour;
            set => hour = value;
        }

        [D2OIgnore]
        public uint Minute
        {
            get => minute;
            set => minute = value;
        }
    }
}