using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildVersatileInfoListMessage : Message
    {
        public const uint Id = 6435;

        public GuildVersatileInfoListMessage(GuildVersatileInformations[] guilds)
        {
            Guilds = guilds;
        }

        public GuildVersatileInfoListMessage()
        {
        }

        public override uint MessageId => Id;

        public GuildVersatileInformations[] Guilds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Guilds.Count());
            for (var guildsIndex = 0; guildsIndex < Guilds.Count(); guildsIndex++)
            {
                var objectToSend = Guilds[guildsIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var guildsCount = reader.ReadUShort();
            Guilds = new GuildVersatileInformations[guildsCount];
            for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<GuildVersatileInformations>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Guilds[guildsIndex] = objectToAdd;
            }
        }
    }
}