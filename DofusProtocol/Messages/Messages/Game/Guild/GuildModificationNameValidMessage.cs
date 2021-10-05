using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildModificationNameValidMessage : Message
    {
        public const uint Id = 6327;

        public GuildModificationNameValidMessage(string guildName)
        {
            GuildName = guildName;
        }

        public GuildModificationNameValidMessage()
        {
        }

        public override uint MessageId => Id;

        public string GuildName { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(GuildName);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildName = reader.ReadUTF();
        }
    }
}