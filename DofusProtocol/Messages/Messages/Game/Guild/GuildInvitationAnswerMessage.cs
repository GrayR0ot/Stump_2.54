using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildInvitationAnswerMessage : Message
    {
        public const uint Id = 5556;

        public GuildInvitationAnswerMessage(bool accept)
        {
            Accept = accept;
        }

        public GuildInvitationAnswerMessage()
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