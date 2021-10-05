using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightStartingMessage : Message
    {
        public const uint Id = 700;

        public GameFightStartingMessage(sbyte fightType, ushort fightId, double attackerId, double defenderId)
        {
            FightType = fightType;
            FightId = fightId;
            AttackerId = attackerId;
            DefenderId = defenderId;
        }

        public GameFightStartingMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte FightType { get; set; }
        public ushort FightId { get; set; }
        public double AttackerId { get; set; }
        public double DefenderId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(FightType);
            writer.WriteVarUShort(FightId);
            writer.WriteDouble(AttackerId);
            writer.WriteDouble(DefenderId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightType = reader.ReadSByte();
            FightId = reader.ReadVarUShort();
            AttackerId = reader.ReadDouble();
            DefenderId = reader.ReadDouble();
        }
    }
}