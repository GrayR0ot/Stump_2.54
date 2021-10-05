using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyInvitationArenaRequestMessage : PartyInvitationRequestMessage
    {
        public new const uint Id = 6283;

        public PartyInvitationArenaRequestMessage(string name)
        {
            Name = name;
        }

        public PartyInvitationArenaRequestMessage()
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