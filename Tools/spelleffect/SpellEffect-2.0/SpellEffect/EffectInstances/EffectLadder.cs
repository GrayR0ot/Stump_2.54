using System;

namespace SpellEffect.EffectInstances
{
    [Serializable]
    public class EffectLadder : EffectCreature
    {
        protected short m_monsterCount;

        public short MonsterCount
        {
            get { return m_monsterCount; }
            set
            {
                m_monsterCount = value; IsDirty = true;
            }
        }

        public EffectLadder()
        {

        }

        public EffectLadder(EffectLadder copy)
            : this(copy.Id, copy.MonsterFamily, copy.MonsterCount, copy)
        {

        }

        public EffectLadder(short id, short monsterfamily, short monstercount, EffectBase effect)
            : base(id, monsterfamily, effect)
        {
            m_monsterCount = monstercount;
        }

        public override int ProtocoleId
        {
            get { return 81; }
        }

        public override byte SerializationIdenfitier
        {
            get
            {
                return 7;
            }
        }

        public override object[] GetValues()
        {
            return new object[] { m_monsterCount, m_monsterfamily };
        }

        public override EffectBase GenerateEffect(EffectGenerationContext context, EffectGenerationType type = EffectGenerationType.Normal)
        {
            return new EffectLadder(this);
        }
        protected override void InternalSerialize(ref System.IO.BinaryWriter writer)
        {
            base.InternalSerialize(ref writer);

            writer.Write(m_monsterCount);
        }

        protected override void InternalDeserialize(ref System.IO.BinaryReader reader)
        {
            base.InternalDeserialize(ref reader);

            m_monsterCount = reader.ReadInt16();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is EffectLadder))
                return false;
            return base.Equals(obj) && m_monsterCount == (obj as EffectLadder).m_monsterCount;
        }

        public static bool operator ==(EffectLadder a, EffectLadder b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (((object)a == null) || ((object)b == null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EffectLadder a, EffectLadder b)
        {
            return !(a == b);
        }

        public bool Equals(EffectLadder other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.m_monsterCount == m_monsterCount;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ m_monsterCount.GetHashCode();
            }
        }
    }
}