using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeStartedBidSellerMessage : Message
    {
        public const uint Id = 5905;

        public ExchangeStartedBidSellerMessage(SellerBuyerDescriptor sellerDescriptor,
            ObjectItemToSellInBid[] objectsInfos)
        {
            SellerDescriptor = sellerDescriptor;
            ObjectsInfos = objectsInfos;
        }

        public ExchangeStartedBidSellerMessage()
        {
        }

        public override uint MessageId => Id;

        public SellerBuyerDescriptor SellerDescriptor { get; set; }
        public ObjectItemToSellInBid[] ObjectsInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            SellerDescriptor.Serialize(writer);
            writer.WriteShort((short) ObjectsInfos.Count());
            for (var objectsInfosIndex = 0; objectsInfosIndex < ObjectsInfos.Count(); objectsInfosIndex++)
            {
                var objectToSend = ObjectsInfos[objectsInfosIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            SellerDescriptor = new SellerBuyerDescriptor();
            SellerDescriptor.Deserialize(reader);
            var objectsInfosCount = reader.ReadUShort();
            ObjectsInfos = new ObjectItemToSellInBid[objectsInfosCount];
            for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
            {
                var objectToAdd = new ObjectItemToSellInBid();
                objectToAdd.Deserialize(reader);
                ObjectsInfos[objectsInfosIndex] = objectToAdd;
            }
        }
    }
}