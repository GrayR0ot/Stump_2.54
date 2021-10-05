using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectDeleteMessage : Message
    {
        public const uint Id = 3022;

        public ObjectDeleteMessage(uint objectUID, uint quantity)
        {
            ObjectUID = objectUID;
            Quantity = quantity;
        }

        public ObjectDeleteMessage()
        {
        }

        public override uint MessageId => Id;

        public uint ObjectUID { get; set; }
        public uint Quantity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ObjectUID);
            writer.WriteVarUInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUInt();
            Quantity = reader.ReadVarUInt();
        }
    }
}