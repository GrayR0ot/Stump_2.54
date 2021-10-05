using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class EmotePlayAbstractMessage : Message
    {
        public const uint Id = 5690;

        public EmotePlayAbstractMessage(byte emoteId, double emoteStartTime)
        {
            EmoteId = emoteId;
            EmoteStartTime = emoteStartTime;
        }

        public EmotePlayAbstractMessage()
        {
        }

        public override uint MessageId => Id;

        public byte EmoteId { get; set; }
        public double EmoteStartTime { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(EmoteId);
            writer.WriteDouble(EmoteStartTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            EmoteId = reader.ReadByte();
            EmoteStartTime = reader.ReadDouble();
        }
    }
}