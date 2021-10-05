using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildFactsRequestMessage : Message
    {
        public const uint Id = 6404;

        public GuildFactsRequestMessage(uint guildId)
        {
            GuildId = guildId;
        }

        public GuildFactsRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public uint GuildId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(GuildId);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildId = reader.ReadVarUInt();
        }
    }
}