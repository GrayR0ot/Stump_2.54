using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AnomalyStateMessage : Message
    {
        public const uint Id = 6831;

        public AnomalyStateMessage(bool open, ulong closingTime)
        {
            Open = open;
            ClosingTime = closingTime;
        }

        public AnomalyStateMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Open { get; set; }
        public ulong ClosingTime { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Open);
            writer.WriteVarULong(ClosingTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            Open = reader.ReadBoolean();
            ClosingTime = reader.ReadVarULong();
        }
    }
}