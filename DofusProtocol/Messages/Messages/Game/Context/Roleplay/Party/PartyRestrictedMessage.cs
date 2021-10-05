using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyRestrictedMessage : AbstractPartyMessage
    {
        public new const uint Id = 6175;

        public PartyRestrictedMessage(uint partyId, bool restricted)
        {
            PartyId = partyId;
            Restricted = restricted;
        }

        public PartyRestrictedMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Restricted { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Restricted);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Restricted = reader.ReadBoolean();
        }
    }
}