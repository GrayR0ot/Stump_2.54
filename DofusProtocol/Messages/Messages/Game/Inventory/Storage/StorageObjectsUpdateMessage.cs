using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class StorageObjectsUpdateMessage : Message
    {
        public const uint Id = 6036;

        public StorageObjectsUpdateMessage(ObjectItem[] objectList)
        {
            ObjectList = objectList;
        }

        public StorageObjectsUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItem[] ObjectList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ObjectList.Count());
            for (var objectListIndex = 0; objectListIndex < ObjectList.Count(); objectListIndex++)
            {
                var objectToSend = ObjectList[objectListIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectListCount = reader.ReadUShort();
            ObjectList = new ObjectItem[objectListCount];
            for (var objectListIndex = 0; objectListIndex < objectListCount; objectListIndex++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                ObjectList[objectListIndex] = objectToAdd;
            }
        }
    }
}