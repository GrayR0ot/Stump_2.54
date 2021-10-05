using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyLoyaltyStatusMessage : AbstractPartyMessage
    {
        public new const uint Id = 6270;

        public PartyLoyaltyStatusMessage(uint partyId, bool loyal)
        {
            PartyId = partyId;
            Loyal = loyal;
        }

        public PartyLoyaltyStatusMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Loyal { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Loyal);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Loyal = reader.ReadBoolean();
        }
    }
}