using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AllianceInvitationAnswerMessage : Message
    {
        public const uint Id = 6401;

        public AllianceInvitationAnswerMessage(bool accept)
        {
            Accept = accept;
        }

        public AllianceInvitationAnswerMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Accept { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            Accept = reader.ReadBoolean();
        }
    }
}