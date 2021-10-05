using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeStartedBidBuyerMessage : Message
    {
        public const uint Id = 5904;

        public ExchangeStartedBidBuyerMessage(SellerBuyerDescriptor buyerDescriptor)
        {
            BuyerDescriptor = buyerDescriptor;
        }

        public ExchangeStartedBidBuyerMessage()
        {
        }

        public override uint MessageId => Id;

        public SellerBuyerDescriptor BuyerDescriptor { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            BuyerDescriptor.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            BuyerDescriptor = new SellerBuyerDescriptor();
            BuyerDescriptor.Deserialize(reader);
        }
    }
}