using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectGroundRemovedMessage : Message
    {
        public const uint Id = 3014;

        public ObjectGroundRemovedMessage(ushort cell)
        {
            Cell = cell;
        }

        public ObjectGroundRemovedMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort Cell { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(Cell);
        }

        public override void Deserialize(IDataReader reader)
        {
            Cell = reader.ReadVarUShort();
        }
    }
}