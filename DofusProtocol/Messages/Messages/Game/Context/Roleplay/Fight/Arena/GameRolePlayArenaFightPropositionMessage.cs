using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayArenaFightPropositionMessage : Message
    {
        public const uint Id = 6276;

        public GameRolePlayArenaFightPropositionMessage(ushort fightId, double[] alliesId, ushort duration)
        {
            FightId = fightId;
            AlliesId = alliesId;
            Duration = duration;
        }

        public GameRolePlayArenaFightPropositionMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort FightId { get; set; }
        public double[] AlliesId { get; set; }
        public ushort Duration { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(FightId);
            writer.WriteShort((short) AlliesId.Count());
            for (var alliesIdIndex = 0; alliesIdIndex < AlliesId.Count(); alliesIdIndex++)
                writer.WriteDouble(AlliesId[alliesIdIndex]);
            writer.WriteVarUShort(Duration);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUShort();
            var alliesIdCount = reader.ReadUShort();
            AlliesId = new double[alliesIdCount];
            for (var alliesIdIndex = 0; alliesIdIndex < alliesIdCount; alliesIdIndex++)
                AlliesId[alliesIdIndex] = reader.ReadDouble();
            Duration = reader.ReadVarUShort();
        }
    }
}