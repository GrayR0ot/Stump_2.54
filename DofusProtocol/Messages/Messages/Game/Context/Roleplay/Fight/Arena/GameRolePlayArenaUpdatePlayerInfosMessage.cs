using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayArenaUpdatePlayerInfosMessage : Message
    {
        public const uint Id = 6301;

        public GameRolePlayArenaUpdatePlayerInfosMessage(ArenaRankInfos solo)
        {
            Solo = solo;
        }

        public GameRolePlayArenaUpdatePlayerInfosMessage()
        {
        }

        public override uint MessageId => Id;

        public ArenaRankInfos Solo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Solo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Solo = new ArenaRankInfos();
            Solo.Deserialize(reader);
        }
    }
}