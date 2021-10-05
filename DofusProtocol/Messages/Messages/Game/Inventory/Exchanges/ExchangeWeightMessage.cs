using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeWeightMessage : Message
    {
        public const uint Id = 5793;

        public ExchangeWeightMessage(uint currentWeight, uint maxWeight)
        {
            CurrentWeight = currentWeight;
            MaxWeight = maxWeight;
        }

        public ExchangeWeightMessage()
        {
        }

        public override uint MessageId => Id;

        public uint CurrentWeight { get; set; }
        public uint MaxWeight { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(CurrentWeight);
            writer.WriteVarUInt(MaxWeight);
        }

        public override void Deserialize(IDataReader reader)
        {
            CurrentWeight = reader.ReadVarUInt();
            MaxWeight = reader.ReadVarUInt();
        }
    }
}