using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class UpdateMapPlayersAgressableStatusMessage : Message
    {
        public const uint Id = 6454;

        public UpdateMapPlayersAgressableStatusMessage(ulong[] playerIds, byte[] enable)
        {
            PlayerIds = playerIds;
            Enable = enable;
        }

        public UpdateMapPlayersAgressableStatusMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong[] PlayerIds { get; set; }
        public byte[] Enable { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) PlayerIds.Count());
            for (var playerIdsIndex = 0; playerIdsIndex < PlayerIds.Count(); playerIdsIndex++)
                writer.WriteVarULong(PlayerIds[playerIdsIndex]);
            writer.WriteShort((short) Enable.Count());
            for (var enableIndex = 0; enableIndex < Enable.Count(); enableIndex++)
                writer.WriteByte(Enable[enableIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var playerIdsCount = reader.ReadUShort();
            PlayerIds = new ulong[playerIdsCount];
            for (var playerIdsIndex = 0; playerIdsIndex < playerIdsCount; playerIdsIndex++)
                PlayerIds[playerIdsIndex] = reader.ReadVarULong();
            var enableCount = reader.ReadUShort();
            Enable = new byte[enableCount];
            for (var enableIndex = 0; enableIndex < enableCount; enableIndex++) Enable[enableIndex] = reader.ReadByte();
        }
    }
}