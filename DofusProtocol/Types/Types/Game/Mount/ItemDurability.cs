using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class ItemDurability
    {
        public const short Id = 168;

        public ItemDurability(short durability, short durabilityMax)
        {
            Durability = durability;
            DurabilityMax = durabilityMax;
        }

        public ItemDurability()
        {
        }

        public virtual short TypeId => Id;

        public short Durability { get; set; }
        public short DurabilityMax { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort(Durability);
            writer.WriteShort(DurabilityMax);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            Durability = reader.ReadShort();
            DurabilityMax = reader.ReadShort();
        }
    }
}