using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PaddockRemoveItemRequestMessage : Message
    {
        public const uint Id = 5958;

        public PaddockRemoveItemRequestMessage(ushort cellId)
        {
            CellId = cellId;
        }

        public PaddockRemoveItemRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort CellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUShort();
        }
    }
}