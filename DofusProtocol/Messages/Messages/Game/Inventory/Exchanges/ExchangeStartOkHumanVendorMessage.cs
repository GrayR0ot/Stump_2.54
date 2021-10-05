using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeStartOkHumanVendorMessage : Message
    {
        public const uint Id = 5767;

        public ExchangeStartOkHumanVendorMessage(double sellerId, ObjectItemToSellInHumanVendorShop[] objectsInfos)
        {
            SellerId = sellerId;
            ObjectsInfos = objectsInfos;
        }

        public ExchangeStartOkHumanVendorMessage()
        {
        }

        public override uint MessageId => Id;

        public double SellerId { get; set; }
        public ObjectItemToSellInHumanVendorShop[] ObjectsInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(SellerId);
            writer.WriteShort((short) ObjectsInfos.Count());
            for (var objectsInfosIndex = 0; objectsInfosIndex < ObjectsInfos.Count(); objectsInfosIndex++)
            {
                var objectToSend = ObjectsInfos[objectsInfosIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            SellerId = reader.ReadDouble();
            var objectsInfosCount = reader.ReadUShort();
            ObjectsInfos = new ObjectItemToSellInHumanVendorShop[objectsInfosCount];
            for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
            {
                var objectToAdd = new ObjectItemToSellInHumanVendorShop();
                objectToAdd.Deserialize(reader);
                ObjectsInfos[objectsInfosIndex] = objectToAdd;
            }
        }
    }
}