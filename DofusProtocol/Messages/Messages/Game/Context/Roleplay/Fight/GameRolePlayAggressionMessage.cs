using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayAggressionMessage : Message
    {
        public const uint Id = 6073;

        public GameRolePlayAggressionMessage(ulong attackerId, ulong defenderId)
        {
            AttackerId = attackerId;
            DefenderId = defenderId;
        }

        public GameRolePlayAggressionMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong AttackerId { get; set; }
        public ulong DefenderId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(AttackerId);
            writer.WriteVarULong(DefenderId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AttackerId = reader.ReadVarULong();
            DefenderId = reader.ReadVarULong();
        }
    }
}