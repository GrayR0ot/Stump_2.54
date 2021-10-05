using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildModificationEmblemValidMessage : Message
    {
        public const uint Id = 6328;

        public GuildModificationEmblemValidMessage(GuildEmblem guildEmblem)
        {
            GuildEmblem = guildEmblem;
        }

        public GuildModificationEmblemValidMessage()
        {
        }

        public override uint MessageId => Id;

        public GuildEmblem GuildEmblem { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            GuildEmblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildEmblem = new GuildEmblem();
            GuildEmblem.Deserialize(reader);
        }
    }
}