﻿using System;
using System.IO;
using Stump.DofusProtocol.Enums;

namespace SpellEffect.EffectInstances
{
    [Serializable]
    public class EffectDuration : EffectBase
    {
        protected short m_days;
        protected short m_hours;
        protected short m_minutes;

        public EffectDuration()
        {
        }

        public EffectDuration(EffectDuration copy)
            : this(copy.Id, copy.m_days, copy.m_hours, copy.m_minutes, copy)
        {
        }

        public EffectDuration(EffectsEnum effect, TimeSpan duration)
            : this((short) effect, (short) duration.Days, (short) duration.Hours, (short) duration.Minutes,
                new EffectBase())
        {
        }

        public EffectDuration(short id, short days, short hours, short minutes, EffectBase effect)
            : base(id, effect)
        {
            m_days = days;
            m_hours = hours;
            m_minutes = minutes;
        }

        public override int ProtocoleId => 75;

        public override byte SerializationIdenfitier => 5;

        public void Update(TimeSpan duration)
        {
            m_days = (short) duration.Days;
            m_hours = (short) duration.Hours;
            m_minutes = (short) duration.Minutes;
        }

        public override object[] GetValues()
        {
            return new object[] {m_days, m_hours, m_minutes};
        }

        public override EffectBase GenerateEffect(EffectGenerationContext context,
            EffectGenerationType type = EffectGenerationType.Normal)
        {
            return new EffectDuration(this);
        }

        protected override void InternalSerialize(ref BinaryWriter writer)
        {
            base.InternalSerialize(ref writer);

            writer.Write(m_days);
            writer.Write(m_hours);
            writer.Write(m_minutes);
        }

        protected override void InternalDeserialize(ref BinaryReader reader)
        {
            base.InternalDeserialize(ref reader);

            m_days = reader.ReadInt16();
            m_hours = reader.ReadInt16();
            m_minutes = reader.ReadInt16();
        }

        public TimeSpan GetTimeSpan()
        {
            return new TimeSpan(m_days, m_hours, m_minutes, 0);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is EffectDuration))
                return false;
            return base.Equals(obj) && GetTimeSpan().Equals((obj as EffectDuration).GetTimeSpan());
        }

        public static bool operator ==(EffectDuration a, EffectDuration b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if ((object) a == null || (object) b == null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EffectDuration a, EffectDuration b)
        {
            return !(a == b);
        }

        public bool Equals(EffectDuration other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.m_days == m_days && other.m_hours == m_hours &&
                   other.m_minutes == m_minutes;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = base.GetHashCode();
                result = (result * 397) ^ m_days.GetHashCode();
                result = (result * 397) ^ m_hours.GetHashCode();
                result = (result * 397) ^ m_minutes.GetHashCode();
                return result;
            }
        }
    }
}