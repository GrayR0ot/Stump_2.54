using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyInvitationDetailsRequestMessage : AbstractPartyMessage
    {
        public new const uint Id = 6264;

        public PartyInvitationDetailsRequestMessage(uint partyId)
        {
            PartyId = partyId;
        }

        public PartyInvitationDetailsRequestMessage()
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