﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyDeletedMessage : AbstractPartyMessage
    {
        public new const uint Id = 6261;

        public PartyDeletedMessage(uint partyId)
        {
            PartyId = partyId;
        }

        public PartyDeletedMessage()
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