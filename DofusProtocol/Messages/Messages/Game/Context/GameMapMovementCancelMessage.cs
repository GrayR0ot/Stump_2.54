using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameMapMovementCancelMessage : Message
    {
        public const uint Id = 953;

        public GameMapMovementCancelMessage(ushort cellId)
        {
            CellId = cellId;
        }

        public GameMapMovementCancelMessage()
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