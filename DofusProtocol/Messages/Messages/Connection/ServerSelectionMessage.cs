using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ServerSelectionMessage : Message
    {
        public const uint Id = 40;

        public ServerSelectionMessage(ushort serverId)
        {
            ServerId = serverId;
        }

        public ServerSelectionMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort ServerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(ServerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ServerId = reader.ReadVarUShort();
        }
    }
}