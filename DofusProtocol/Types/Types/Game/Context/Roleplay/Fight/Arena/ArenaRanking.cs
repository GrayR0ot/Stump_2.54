using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class ArenaRanking
    {
        public const short Id = 554;

        public ArenaRanking(ushort rank, ushort bestRank)
        {
            Rank = rank;
            BestRank = bestRank;
        }

        public ArenaRanking()
        {
        }

        public virtual short TypeId => Id;

        public ushort Rank { get; set; }
        public ushort BestRank { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(Rank);
            writer.WriteVarUShort(BestRank);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            Rank = reader.ReadVarUShort();
            BestRank = reader.ReadVarUShort();
        }
    }
}