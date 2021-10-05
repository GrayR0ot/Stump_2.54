using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectsQuantityMessage : Message
    {
        public const uint Id = 6206;

        public ObjectsQuantityMessage(ObjectItemQuantity[] objectsUIDAndQty)
        {
            ObjectsUIDAndQty = objectsUIDAndQty;
        }

        public ObjectsQuantityMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItemQuantity[] ObjectsUIDAndQty { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ObjectsUIDAndQty.Count());
            for (var objectsUIDAndQtyIndex = 0;
                objectsUIDAndQtyIndex < ObjectsUIDAndQty.Count();
                objectsUIDAndQtyIndex++)
            {
                var objectToSend = ObjectsUIDAndQty[objectsUIDAndQtyIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectsUIDAndQtyCount = reader.ReadUShort();
            ObjectsUIDAndQty = new ObjectItemQuantity[objectsUIDAndQtyCount];
            for (var objectsUIDAndQtyIndex = 0; objectsUIDAndQtyIndex < objectsUIDAndQtyCount; objectsUIDAndQtyIndex++)
            {
                var objectToAdd = new ObjectItemQuantity();
                objectToAdd.Deserialize(reader);
                ObjectsUIDAndQty[objectsUIDAndQtyIndex] = objectToAdd;
            }
        }
    }
}