using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeStartedMountStockMessage : Message
    {
        public const uint Id = 5984;

        public ExchangeStartedMountStockMessage(ObjectItem[] objectsInfos)
        {
            ObjectsInfos = objectsInfos;
        }

        public ExchangeStartedMountStockMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItem[] ObjectsInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ObjectsInfos.Count());
            for (var objectsInfosIndex = 0; objectsInfosIndex < ObjectsInfos.Count(); objectsInfosIndex++)
            {
                var objectToSend = ObjectsInfos[objectsInfosIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectsInfosCount = reader.ReadUShort();
            ObjectsInfos = new ObjectItem[objectsInfosCount];
            for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                ObjectsInfos[objectsInfosIndex] = objectToAdd;
            }
        }
    }
}