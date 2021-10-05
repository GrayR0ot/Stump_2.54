using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyAcceptInvitationMessage : AbstractPartyMessage
    {
        public new const uint Id = 5580;

        public PartyAcceptInvitationMessage(uint partyId)
        {
            PartyId = partyId;
        }

        public PartyAcceptInvitationMessage()
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