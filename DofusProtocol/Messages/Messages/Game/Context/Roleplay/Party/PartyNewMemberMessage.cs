using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyNewMemberMessage : PartyUpdateMessage
    {
        public new const uint Id = 6306;

        public PartyNewMemberMessage(uint partyId, PartyMemberInformations memberInformations)
        {
            PartyId = partyId;
            MemberInformations = memberInformations;
        }

        public PartyNewMemberMessage()
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