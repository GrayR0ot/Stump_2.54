using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TaxCollectorMovementRemoveMessage : Message
    {
        public const uint Id = 5915;

        public TaxCollectorMovementRemoveMessage(double collectorId)
        {
            CollectorId = collectorId;
        }

        public TaxCollectorMovementRemoveMessage()
        {
        }

        public override uint MessageId => Id;

        public double CollectorId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(CollectorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CollectorId = reader.ReadDouble();
        }
    }
}