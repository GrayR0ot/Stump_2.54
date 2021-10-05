using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeBidHouseGenericItemRemovedMessage : Message
    {
        public const uint Id = 5948;

        public ExchangeBidHouseGenericItemRemovedMessage(ushort objGenericId)
        {
            ObjGenericId = objGenericId;
        }

        public ExchangeBidHouseGenericItemRemovedMessage()
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