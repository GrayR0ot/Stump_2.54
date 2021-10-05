using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayPlayerFightFriendlyRequestedMessage : Message
    {
        public const uint Id = 5937;

        public GameRolePlayPlayerFightFriendlyRequestedMessage(ushort fightId, ulong sourceId, ulong targetId)
        {
            FightId = fightId;
            SourceId = sourceId;
            TargetId = targetId;
        }

        public GameRolePlayPlayerFightFriendlyRequestedMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort FightId { get; set; }
        public ulong SourceId { get; set; }
        public ulong TargetId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(FightId);
            writer.WriteVarULong(SourceId);
            writer.WriteVarULong(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUShort();
            SourceId = reader.ReadVarULong();
            TargetId = reader.ReadVarULong();
        }
    }
}