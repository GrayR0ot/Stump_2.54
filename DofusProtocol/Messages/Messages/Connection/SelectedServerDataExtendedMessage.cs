using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SelectedServerDataExtendedMessage : SelectedServerDataMessage
    {
        public new const uint Id = 6469;

        public SelectedServerDataExtendedMessage(ushort serverId, string address, int[] ports,
            bool canCreateNewCharacter, sbyte[] ticket, GameServerInformations[] servers)
        {
            ServerId = serverId;
            Address = address;
            Ports = ports;
            CanCreateNewCharacter = canCreateNewCharacter;
            Ticket = ticket;
            Servers = servers;
        }

        public SelectedServerDataExtendedMessage()
        {
        }

        public override uint MessageId => Id;

        public GameServerInformations[] Servers { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Servers.Count());
            for (var serversIndex = 0; serversIndex < Servers.Count(); serversIndex++)
            {
                var objectToSend = Servers[serversIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var serversCount = reader.ReadUShort();
            Servers = new GameServerInformations[serversCount];
            for (var serversIndex = 0; serversIndex < serversCount; serversIndex++)
            {
                var objectToAdd = new GameServerInformations();
                objectToAdd.Deserialize(reader);
                Servers[serversIndex] = objectToAdd;
            }
        }
    }
}