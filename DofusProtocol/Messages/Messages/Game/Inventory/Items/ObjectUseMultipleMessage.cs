using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectUseMultipleMessage : ObjectUseMessage
    {
        public new const uint Id = 6234;

        public ObjectUseMultipleMessage(uint objectUID, uint quantity)
        {
            ObjectUID = objectUID;
            Quantity = quantity;
        }

        public ObjectUseMultipleMessage()
        {
        }

        public override uint MessageId => Id;

        public uint Quantity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Quantity = reader.ReadVarUInt();
        }
    }
}