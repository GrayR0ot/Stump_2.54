using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectMovementMessage : Message
    {
        public const uint Id = 3010;

        public ObjectMovementMessage(uint objectUID, short position)
        {
            ObjectUID = objectUID;
            Position = position;
        }

        public ObjectMovementMessage()
        {
        }

        public override uint MessageId => Id;

        public uint ObjectUID { get; set; }
        public short Position { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ObjectUID);
            writer.WriteShort(Position);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUInt();
            Position = reader.ReadShort();
        }
    }
}