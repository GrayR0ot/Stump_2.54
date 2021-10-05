using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildJoinedMessage : Message
    {
        public const uint Id = 5564;

        public GuildJoinedMessage(GuildInformations guildInfo, uint memberRights)
        {
            GuildInfo = guildInfo;
            MemberRights = memberRights;
        }

        public GuildJoinedMessage()
        {
        }

        public override uint MessageId => Id;

        public GuildInformations GuildInfo { get; set; }
        public uint MemberRights { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            GuildInfo.Serialize(writer);
            writer.WriteVarUInt(MemberRights);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
            MemberRights = reader.ReadVarUInt();
        }
    }
}