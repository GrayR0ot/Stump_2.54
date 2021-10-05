using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyRefuseInvitationMessage : AbstractPartyMessage
    {
        public new const uint Id = 5582;

        public PartyRefuseInvitationMessage(uint partyId)
        {
            PartyId = partyId;
        }

        public PartyRefuseInvitationMessage()
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