using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildFightPlayersEnemiesListMessage : Message
    {
        public const uint Id = 5928;

        public GuildFightPlayersEnemiesListMessage(double fightId, CharacterMinimalPlusLookInformations[] playerInfo)
        {
            FightId = fightId;
            PlayerInfo = playerInfo;
        }

        public GuildFightPlayersEnemiesListMessage()
        {
        }

        public override uint MessageId => Id;

        public double FightId { get; set; }
        public CharacterMinimalPlusLookInformations[] PlayerInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(FightId);
            writer.WriteShort((short) PlayerInfo.Count());
            for (var playerInfoIndex = 0; playerInfoIndex < PlayerInfo.Count(); playerInfoIndex++)
            {
                var objectToSend = PlayerInfo[playerInfoIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadDouble();
            var playerInfoCount = reader.ReadUShort();
            PlayerInfo = new CharacterMinimalPlusLookInformations[playerInfoCount];
            for (var playerInfoIndex = 0; playerInfoIndex < playerInfoCount; playerInfoIndex++)
            {
                var objectToAdd = new CharacterMinimalPlusLookInformations();
                objectToAdd.Deserialize(reader);
                PlayerInfo[playerInfoIndex] = objectToAdd;
            }
        }
    }
}