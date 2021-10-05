using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameDataPaddockObjectRemoveMessage : Message
    {
        public const uint Id = 5993;

        public GameDataPaddockObjectRemoveMessage(ushort cellId)
        {
            CellId = cellId;
        }

        public GameDataPaddockObjectRemoveMessage()
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