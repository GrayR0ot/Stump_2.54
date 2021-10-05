using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PlayerStatusUpdateRequestMessage : Message
    {
        public const uint Id = 6387;

        public PlayerStatusUpdateRequestMessage(PlayerStatus status)
        {
            Status = status;
        }

        public PlayerStatusUpdateRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public PlayerStatus Status { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
            Status.Deserialize(reader);
        }
    }
}