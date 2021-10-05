using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TaxCollectorStateUpdateMessage : Message
    {
        public const uint Id = 6455;

        public TaxCollectorStateUpdateMessage(double uniqueId, sbyte state)
        {
            UniqueId = uniqueId;
            State = state;
        }

        public TaxCollectorStateUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public double UniqueId { get; set; }
        public sbyte State { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(UniqueId);
            writer.WriteSByte(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            UniqueId = reader.ReadDouble();
            State = reader.ReadSByte();
        }
    }
}