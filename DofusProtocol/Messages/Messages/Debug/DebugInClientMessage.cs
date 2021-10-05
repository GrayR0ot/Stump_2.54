using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DebugInClientMessage : Message
    {
        public const uint Id = 6028;
        public sbyte level;
        public string message;

        public DebugInClientMessage(sbyte level, string message)
        {
            this.level = level;
            this.message = message;
        }

        public DebugInClientMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(level);
            writer.WriteUTF(message);
        }

        public override void Deserialize(IDataReader reader)
        {
            level = reader.ReadSByte();
            message = reader.ReadUTF();
        }
    }
}