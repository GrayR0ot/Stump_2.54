using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeBidHouseGenericItemAddedMessage : Message
    {
        public const uint Id = 5947;

        public ExchangeBidHouseGenericItemAddedMessage(ushort objGenericId)
        {
            ObjGenericId = objGenericId;
        }

        public ExchangeBidHouseGenericItemAddedMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort ObjGenericId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(ObjGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjGenericId = reader.ReadVarUShort();
        }
    }
}