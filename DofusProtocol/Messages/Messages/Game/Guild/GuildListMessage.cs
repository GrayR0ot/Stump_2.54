using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildListMessage : Message
    {
        public const uint Id = 6413;

        public GuildListMessage(GuildInformations[] guilds)
        {
            Guilds = guilds;
        }

        public GuildListMessage()
        {
        }

        public override uint MessageId => Id;

        public GuildInformations[] Guilds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Guilds.Count());
            for (var guildsIndex = 0; guildsIndex < Guilds.Count(); guildsIndex++)
            {
                var objectToSend = Guilds[guildsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var guildsCount = reader.ReadUShort();
            Guilds = new GuildInformations[guildsCount];
            for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
            {
                var objectToAdd = new GuildInformations();
                objectToAdd.Deserialize(reader);
                Guilds[guildsIndex] = objectToAdd;
            }
        }
    }
}