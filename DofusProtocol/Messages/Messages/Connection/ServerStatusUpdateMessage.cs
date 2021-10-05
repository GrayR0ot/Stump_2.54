using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ServerStatusUpdateMessage : Message
    {
        public const uint Id = 50;

        public ServerStatusUpdateMessage(GameServerInformations server)
        {
            Server = server;
        }

        public ServerStatusUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public GameServerInformations Server { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Server.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Server = new GameServerInformations();
            Server.Deserialize(reader);
        }
    }
}