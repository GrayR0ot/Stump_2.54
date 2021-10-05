using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeShopStockMovementRemovedMessage : Message
    {
        public const uint Id = 5907;

        public ExchangeShopStockMovementRemovedMessage(uint objectId)
        {
            ObjectId = objectId;
        }

        public ExchangeShopStockMovementRemovedMessage()
        {
        }

        public override uint MessageId => Id;

        public uint ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUInt();
        }
    }
}