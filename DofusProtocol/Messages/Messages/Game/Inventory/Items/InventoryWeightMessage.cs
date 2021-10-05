using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class InventoryWeightMessage : Message
    {
        public const uint Id = 3009;

        public InventoryWeightMessage(uint inventoryWeight, uint shopWeight, uint weightMax)
        {
            Weight = inventoryWeight;
            ShopWeight = shopWeight;
            WeightMax = weightMax;
        }

        public InventoryWeightMessage()
        {
        }

        public override uint MessageId => Id;

        public uint Weight { get; set; }
        public uint WeightMax { get; set; }
        public uint ShopWeight { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(Weight);
            writer.WriteVarUInt(ShopWeight);
            writer.WriteVarUInt(WeightMax);
        }

        public override void Deserialize(IDataReader reader)
        {
            Weight = reader.ReadVarUInt();
            ShopWeight = reader.ReadVarUInt();
            WeightMax = reader.ReadVarUInt();
        }
    }
}