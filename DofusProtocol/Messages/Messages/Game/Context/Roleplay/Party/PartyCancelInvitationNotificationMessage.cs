using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyCancelInvitationNotificationMessage : AbstractPartyEventMessage
    {
        public new const uint Id = 6251;

        public PartyCancelInvitationNotificationMessage(uint partyId, ulong cancelerId, ulong guestId)
        {
            PartyId = partyId;
            CancelerId = cancelerId;
            GuestId = guestId;
        }

        public PartyCancelInvitationNotificationMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong CancelerId { get; set; }
        public ulong GuestId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarULong(CancelerId);
            writer.WriteVarULong(GuestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CancelerId = reader.ReadVarULong();
            GuestId = reader.ReadVarULong();
        }
    }
}