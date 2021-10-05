using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PrismSetSabotagedRefusedMessage : Message
    {
        public const uint Id = 6466;

        public PrismSetSabotagedRefusedMessage(ushort subAreaId, sbyte reason)
        {
            SubAreaId = subAreaId;
            Reason = reason;
        }

        public PrismSetSabotagedRefusedMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort SubAreaId { get; set; }
        public sbyte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(SubAreaId);
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUShort();
            Reason = reader.ReadSByte();
        }
    }
}