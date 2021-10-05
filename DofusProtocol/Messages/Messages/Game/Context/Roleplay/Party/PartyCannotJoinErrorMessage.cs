﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyCannotJoinErrorMessage : AbstractPartyMessage
    {
        public new const uint Id = 5583;

        public PartyCannotJoinErrorMessage(uint partyId, sbyte reason)
        {
            PartyId = partyId;
            Reason = reason;
        }

        public PartyCannotJoinErrorMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Reason = reader.ReadSByte();
        }
    }
}