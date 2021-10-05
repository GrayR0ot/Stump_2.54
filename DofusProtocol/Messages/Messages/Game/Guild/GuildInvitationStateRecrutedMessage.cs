using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildInvitationStateRecrutedMessage : Message
    {
        public const uint Id = 5548;

        public GuildInvitationStateRecrutedMessage(sbyte invitationState)
        {
            InvitationState = invitationState;
        }

        public GuildInvitationStateRecrutedMessage()
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