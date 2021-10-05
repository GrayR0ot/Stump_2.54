using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeShopStockStartedMessage : Message
    {
        public const uint Id = 5910;

        public ExchangeShopStockStartedMessage(ObjectItemToSell[] objectsInfos)
        {
            ObjectsInfos = objectsInfos;
        }

        public ExchangeShopStockStartedMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItemToSell[] ObjectsInfos { get; set; }

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
            ObjectsInfos = new ObjectItemToSell[objectsInfosCount];
            for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
            {
                var objectToAdd = new ObjectItemToSell();
                objectToAdd.Deserialize(reader);
                ObjectsInfos[objectsInfosIndex] = objectToAdd;
            }
        }
    }
}