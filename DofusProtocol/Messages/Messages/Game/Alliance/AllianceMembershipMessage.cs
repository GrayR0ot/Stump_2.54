using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AllianceMembershipMessage : AllianceJoinedMessage
    {
        public new const uint Id = 6390;

        public AllianceMembershipMessage(AllianceInformations allianceInfo, bool enabled, uint leadingGuildId)
        {
            AllianceInfo = allianceInfo;
            Enabled = enabled;
            LeadingGuildId = leadingGuildId;
        }

        public AllianceMembershipMessage()
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