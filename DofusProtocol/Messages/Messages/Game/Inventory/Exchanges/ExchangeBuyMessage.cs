using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeBuyMessage : Message
    {
        public const uint Id = 5774;

        public ExchangeBuyMessage(uint objectToBuyId, uint quantity)
        {
            ObjectToBuyId = objectToBuyId;
            Quantity = quantity;
        }

        public ExchangeBuyMessage()
        {
        }

        public override uint MessageId => Id;

        public uint ObjectToBuyId { get; set; }
        public uint Quantity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ObjectToBuyId);
            writer.WriteVarUInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectToBuyId = reader.ReadVarUInt();
            Quantity = reader.ReadVarUInt();
        }
    }
}