using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildLevelUpMessage : Message
    {
        public const uint Id = 6062;

        public GuildLevelUpMessage(byte newLevel)
        {
            NewLevel = newLevel;
        }

        public GuildLevelUpMessage()
        {
        }

        public override uint MessageId => Id;

        public byte NewLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(NewLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            NewLevel = reader.ReadByte();
        }
    }
}