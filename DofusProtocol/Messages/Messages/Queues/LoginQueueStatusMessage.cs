using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class LoginQueueStatusMessage : Message
    {
        public const uint Id = 10;

        public LoginQueueStatusMessage(ushort position, ushort total)
        {
            Position = position;
            Total = total;
        }

        public LoginQueueStatusMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort Position { get; set; }
        public ushort Total { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Position);
            writer.WriteUShort(Total);
        }

        public override void Deserialize(IDataReader reader)
        {
            Position = reader.ReadUShort();
            Total = reader.ReadUShort();
        }
    }
}