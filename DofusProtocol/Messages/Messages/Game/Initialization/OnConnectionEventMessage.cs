using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class OnConnectionEventMessage : Message
    {
        public const uint Id = 5726;

        public OnConnectionEventMessage(sbyte eventType)
        {
            EventType = eventType;
        }

        public OnConnectionEventMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte EventType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(EventType);
        }

        public override void Deserialize(IDataReader reader)
        {
            EventType = reader.ReadSByte();
        }
    }
}