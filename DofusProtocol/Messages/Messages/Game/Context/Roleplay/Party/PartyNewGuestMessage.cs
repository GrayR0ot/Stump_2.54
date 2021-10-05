using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyNewGuestMessage : AbstractPartyEventMessage
    {
        public new const uint Id = 6260;

        public PartyNewGuestMessage(uint partyId, PartyGuestInformations guest)
        {
            PartyId = partyId;
            Guest = guest;
        }

        public PartyNewGuestMessage()
        {
        }

        public override uint MessageId => Id;

        public PartyGuestInformations Guest { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Guest.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Guest = new PartyGuestInformations();
            Guest.Deserialize(reader);
        }
    }
}