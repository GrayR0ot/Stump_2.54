using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayArenaRegisterMessage : Message
    {
        public const uint Id = 6280;

        public GameRolePlayArenaRegisterMessage(int battleMode)
        {
            BattleMode = battleMode;
        }

        public GameRolePlayArenaRegisterMessage()
        {
        }

        public override uint MessageId => Id;

        public int BattleMode { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(BattleMode);
        }

        public override void Deserialize(IDataReader reader)
        {
            BattleMode = reader.ReadInt();
        }
    }
}