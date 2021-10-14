using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{

    public class InventoryWeightMessage : Message
    {

        public const uint Id = 3009;
        public override uint MessageId
        {
            get { return Id; }
        }

        public uint inventoryWeight;
        public uint shopWeight;
        public uint weightMax;
        

        public InventoryWeightMessage()
        {
        }

        public InventoryWeightMessage(uint inventoryWeight, uint shopWeight, uint weightMax)
        {
            this.inventoryWeight = inventoryWeight;
            this.shopWeight = shopWeight;
            this.weightMax = weightMax;
        }
        

        public override void Serialize(IDataWriter writer)
        {

            writer.WriteVarInt((int)inventoryWeight);
            writer.WriteVarInt((int)shopWeight);
            writer.WriteVarInt((int)weightMax);
            

        }

        public override void Deserialize(IDataReader reader)
        {

            inventoryWeight = reader.ReadVarUInt();
            shopWeight = reader.ReadVarUInt();
            weightMax = reader.ReadVarUInt();
            

        }


    }


}