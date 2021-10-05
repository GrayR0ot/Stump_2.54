using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class ObjectItemGenericQuantity : Item
    {
        public new const short Id = 483;

        public ObjectItemGenericQuantity(uint objectGID, uint quantity)
        {
            ObjectGID = objectGID;
            Quantity = quantity;
        }

        public ObjectItemGenericQuantity()
        {
        }

        public override short TypeId => Id;

        public uint ObjectGID { get; set; }
        public uint Quantity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUInt(ObjectGID);
            writer.WriteVarUInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectGID = reader.ReadVarUInt();
            Quantity = reader.ReadVarUInt();
        }
    }
}