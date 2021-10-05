using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ChangeThemeRequestMessage : Message
    {
        public const uint Id = 6639;

        public ChangeThemeRequestMessage(sbyte theme)
        {
            Theme = theme;
        }

        public ChangeThemeRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Theme { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Theme);
        }

        public override void Deserialize(IDataReader reader)
        {
            Theme = reader.ReadSByte();
        }
    }
}