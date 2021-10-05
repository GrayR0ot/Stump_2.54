﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyInvitationCancelledForGuestMessage : AbstractPartyMessage
    {
        public new const uint Id = 6256;

        public PartyInvitationCancelledForGuestMessage(uint partyId, ulong cancelerId)
        {
            PartyId = partyId;
            CancelerId = cancelerId;
        }

        public PartyInvitationCancelledForGuestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong CancelerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarULong(CancelerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CancelerId = reader.ReadVarULong();
        }
    }
}