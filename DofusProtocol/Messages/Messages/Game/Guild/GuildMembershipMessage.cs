using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildMembershipMessage : GuildJoinedMessage
    {
        public new const uint Id = 5835;

        public GuildMembershipMessage(GuildInformations guildInfo, uint memberRights)
        {
            GuildInfo = guildInfo;
            MemberRights = memberRights;
        }

        public GuildMembershipMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}