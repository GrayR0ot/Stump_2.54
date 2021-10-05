using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AllianceInvitationStateRecrutedMessage : Message
    {
        public const uint Id = 6392;

        public AllianceInvitationStateRecrutedMessage(sbyte invitationState)
        {
            InvitationState = invitationState;
        }

        public AllianceInvitationStateRecrutedMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte InvitationState { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(InvitationState);
        }

        public override void Deserialize(IDataReader reader)
        {
            InvitationState = reader.ReadSByte();
        }
    }
}