using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class ArenaRankInfos
    {
        public const short Id = 499;
        public ushort fightcount;
        public ArenaLeagueRanking leagueRanking;
        public short numFightNeededForLadder;
        public ArenaRanking ranking;
        public ushort victoryCount;

        public ArenaRankInfos(ArenaRanking ranking, ArenaLeagueRanking leagueRanking, ushort victoryCount,
            ushort fightcount, short numFightNeededForLadder)
        {
            this.ranking = ranking;
            this.leagueRanking = leagueRanking;
            this.victoryCount = victoryCount;
            this.fightcount = fightcount;
            this.numFightNeededForLadder = numFightNeededForLadder;
        }

        public ArenaRankInfos()
        {
        }

        public virtual short TypeId => Id;

        public virtual void Serialize(IDataWriter writer)
        {
            if (ranking == null)
            {
                writer.WriteByte(0);
            }
            else
            {
                writer.WriteByte(1);
                ranking.Serialize(writer);
            }

            if (leagueRanking == null)
            {
                writer.WriteByte(0);
            }
            else
            {
                writer.WriteByte(1);
                leagueRanking.Serialize(writer);
            }

            writer.WriteVarUShort(victoryCount);
            writer.WriteVarUShort(fightcount);
            writer.WriteShort(numFightNeededForLadder);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            var isRankingAvailable = reader.ReadByte();
            if (isRankingAvailable == 1)
            {
                ranking = new ArenaRanking();
                ranking.Deserialize(reader);
            }

            var isLeagueRankingAvailable = reader.ReadByte();
            if (isLeagueRankingAvailable == 1)
            {
                leagueRanking = new ArenaLeagueRanking();
                leagueRanking.Deserialize(reader);
            }

            victoryCount = reader.ReadVarUShort();
            fightcount = reader.ReadVarUShort();
            numFightNeededForLadder = reader.ReadShort();
        }
    }
}