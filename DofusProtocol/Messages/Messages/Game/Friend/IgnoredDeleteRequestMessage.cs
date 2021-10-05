using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class IgnoredDeleteRequestMessage : Message
    {
        public const uint Id = 5680;

        public IgnoredDeleteRequestMessage(int accountId, bool session)
        {
            AccountId = accountId;
            Session = session;
        }

        public IgnoredDeleteRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public int AccountId { get; set; }
        public bool Session { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteBoolean(Session);
        }

        public override void Deserialize(IDataReader reader)
        {
            AccountId = reader.ReadInt();
            Session = reader.ReadBoolean();
        }
    }
}