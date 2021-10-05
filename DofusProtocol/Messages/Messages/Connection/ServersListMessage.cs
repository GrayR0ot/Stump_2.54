using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ServersListMessage : Message
    {
        public const uint Id = 30;

        public ServersListMessage(GameServerInformations[] servers, ushort alreadyConnectedToServerId,
            bool canCreateNewCharacter)
        {
            Servers = servers;
            AlreadyConnectedToServerId = alreadyConnectedToServerId;
            CanCreateNewCharacter = canCreateNewCharacter;
        }

        public ServersListMessage()
        {
        }

        public override uint MessageId => Id;

        public GameServerInformations[] Servers { get; set; }
        public ushort AlreadyConnectedToServerId { get; set; }
        public bool CanCreateNewCharacter { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Servers.Count());
            for (var serversIndex = 0; serversIndex < Servers.Count(); serversIndex++)
            {
                var objectToSend = Servers[serversIndex];
                objectToSend.Serialize(writer);
            }

            writer.WriteVarUShort(AlreadyConnectedToServerId);
            writer.WriteBoolean(CanCreateNewCharacter);
        }

        public override void Deserialize(IDataReader reader)
        {
            var serversCount = reader.ReadUShort();
            Servers = new GameServerInformations[serversCount];
            for (var serversIndex = 0; serversIndex < serversCount; serversIndex++)
            {
                var objectToAdd = new GameServerInformations();
                objectToAdd.Deserialize(reader);
                Servers[serversIndex] = objectToAdd;
            }

            AlreadyConnectedToServerId = reader.ReadVarUShort();
            CanCreateNewCharacter = reader.ReadBoolean();
        }
    }
}