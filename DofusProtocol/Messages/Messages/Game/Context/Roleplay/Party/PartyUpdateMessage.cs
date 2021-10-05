using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyUpdateMessage : AbstractPartyEventMessage
    {
        public new const uint Id = 5575;

        public PartyUpdateMessage(uint partyId, PartyMemberInformations memberInformations)
        {
            PartyId = partyId;
            MemberInformations = memberInformations;
        }

        public PartyUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public PartyMemberInformations MemberInformations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MemberInformations.TypeId);
            MemberInformations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MemberInformations = ProtocolTypeManager.GetInstance<PartyMemberInformations>(reader.ReadShort());
            MemberInformations.Deserialize(reader);
        }
    }
}