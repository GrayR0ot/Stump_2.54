using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ConsoleMessage : Message
    {
        public const uint Id = 75;

        public ConsoleMessage(sbyte type, string content)
        {
            Type = type;
            Content = content;
        }

        public ConsoleMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Type { get; set; }
        public string Content { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
            writer.WriteUTF(Content);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
            Content = reader.ReadUTF();
        }
    }
}