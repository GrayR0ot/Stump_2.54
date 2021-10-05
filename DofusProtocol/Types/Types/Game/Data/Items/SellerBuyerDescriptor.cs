using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class SellerBuyerDescriptor
    {
        public const short Id = 121;

        public SellerBuyerDescriptor(uint[] quantities, uint[] types, float taxPercentage,
            float taxModificationPercentage, byte maxItemLevel, int maxItemPerAccount, int npcContextualId,
            ushort unsoldDelay)
        {
            Quantities = quantities;
            Types = types;
            TaxPercentage = taxPercentage;
            TaxModificationPercentage = taxModificationPercentage;
            MaxItemLevel = maxItemLevel;
            MaxItemPerAccount = maxItemPerAccount;
            NpcContextualId = npcContextualId;
            UnsoldDelay = unsoldDelay;
        }

        public SellerBuyerDescriptor()
        {
        }

        public virtual short TypeId => Id;

        public uint[] Quantities { get; set; }
        public uint[] Types { get; set; }
        public float TaxPercentage { get; set; }
        public float TaxModificationPercentage { get; set; }
        public byte MaxItemLevel { get; set; }
        public int MaxItemPerAccount { get; set; }
        public int NpcContextualId { get; set; }
        public ushort UnsoldDelay { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Quantities.Count());
            for (var quantitiesIndex = 0; quantitiesIndex < Quantities.Count(); quantitiesIndex++)
                writer.WriteVarUInt(Quantities[quantitiesIndex]);
            writer.WriteShort((short) Types.Count());
            for (var typesIndex = 0; typesIndex < Types.Count(); typesIndex++) writer.WriteVarUInt(Types[typesIndex]);
            writer.WriteFloat(TaxPercentage);
            writer.WriteFloat(TaxModificationPercentage);
            writer.WriteByte(MaxItemLevel);
            writer.WriteVarInt(MaxItemPerAccount);
            writer.WriteInt(NpcContextualId);
            writer.WriteVarUShort(UnsoldDelay);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            var quantitiesCount = reader.ReadUShort();
            Quantities = new uint[quantitiesCount];
            for (var quantitiesIndex = 0; quantitiesIndex < quantitiesCount; quantitiesIndex++)
                Quantities[quantitiesIndex] = reader.ReadVarUInt();
            var typesCount = reader.ReadUShort();
            Types = new uint[typesCount];
            for (var typesIndex = 0; typesIndex < typesCount; typesIndex++) Types[typesIndex] = reader.ReadVarUInt();
            TaxPercentage = reader.ReadFloat();
            TaxModificationPercentage = reader.ReadFloat();
            MaxItemLevel = reader.ReadByte();
            MaxItemPerAccount = reader.ReadVarInt();
            NpcContextualId = reader.ReadInt();
            UnsoldDelay = reader.ReadVarUShort();
        }
    }
}