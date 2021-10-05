using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PaddockMoveItemRequestMessage : Message
    {
        public const uint Id = 6052;

        public PaddockMoveItemRequestMessage(ushort oldCellId, ushort newCellId)
        {
            OldCellId = oldCellId;
            NewCellId = newCellId;
        }

        public PaddockMoveItemRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort OldCellId { get; set; }
        public ushort NewCellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(OldCellId);
            writer.WriteVarUShort(NewCellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            OldCellId = reader.ReadVarUShort();
            NewCellId = reader.ReadVarUShort();
        }
    }
}