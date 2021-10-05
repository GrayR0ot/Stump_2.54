using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AcquaintanceServerListMessage : Message
    {
        public const uint Id = 6142;

        public AcquaintanceServerListMessage(ushort[] servers)
        {
            Servers = servers;
        }

        public AcquaintanceServerListMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort[] Servers { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Servers.Count());
            for (var serversIndex = 0; serversIndex < Servers.Count(); serversIndex++)
                writer.WriteVarUShort(Servers[serversIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var serversCount = reader.ReadUShort();
            Servers = new ushort[serversCount];
            for (var serversIndex = 0; serversIndex < serversCount; serversIndex++)
                Servers[serversIndex] = reader.ReadVarUShort();
        }
    }
}