using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class DareReward
    {
        public const short Id = 505;

        public DareReward(sbyte type, ushort monsterId, ulong kamas, double dareId)
        {
            Type = type;
            MonsterId = monsterId;
            Kamas = kamas;
            DareId = dareId;
        }

        public DareReward()
        {
        }

        public virtual short TypeId => Id;

        public sbyte Type { get; set; }
        public ushort MonsterId { get; set; }
        public ulong Kamas { get; set; }
        public double DareId { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
            writer.WriteVarUShort(MonsterId);
            writer.WriteVarULong(Kamas);
            writer.WriteDouble(DareId);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
            MonsterId = reader.ReadVarUShort();
            Kamas = reader.ReadVarULong();
            DareId = reader.ReadDouble();
        }
    }
}