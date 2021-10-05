using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayMonsterNotAngryAtPlayerMessage : Message
    {
        public const uint Id = 6742;

        public GameRolePlayMonsterNotAngryAtPlayerMessage(ulong playerId, double monsterGroupId)
        {
            PlayerId = playerId;
            MonsterGroupId = monsterGroupId;
        }

        public GameRolePlayMonsterNotAngryAtPlayerMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong PlayerId { get; set; }
        public double MonsterGroupId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(PlayerId);
            writer.WriteDouble(MonsterGroupId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarULong();
            MonsterGroupId = reader.ReadDouble();
        }
    }
}