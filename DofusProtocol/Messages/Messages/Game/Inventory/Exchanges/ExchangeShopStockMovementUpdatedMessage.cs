using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeShopStockMovementUpdatedMessage : Message
    {
        public const uint Id = 5909;

        public ExchangeShopStockMovementUpdatedMessage(ObjectItemToSell objectInfo)
        {
            ObjectInfo = objectInfo;
        }

        public ExchangeShopStockMovementUpdatedMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItemToSell ObjectInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            ObjectInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectInfo = new ObjectItemToSell();
            ObjectInfo.Deserialize(reader);
        }
    }
}