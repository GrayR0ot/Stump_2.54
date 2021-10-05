using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class RefreshCharacterStatsMessage : Message
    {
        public const uint Id = 6699;

        public RefreshCharacterStatsMessage(double fighterId, GameFightMinimalStats stats)
        {
            FighterId = fighterId;
            Stats = stats;
        }

        public RefreshCharacterStatsMessage()
        {
        }

        public override uint MessageId => Id;

        public double FighterId { get; set; }
        public GameFightMinimalStats Stats { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(FighterId);
            Stats.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FighterId = reader.ReadDouble();
            Stats = new GameFightMinimalStats();
            Stats.Deserialize(reader);
        }
    }
}