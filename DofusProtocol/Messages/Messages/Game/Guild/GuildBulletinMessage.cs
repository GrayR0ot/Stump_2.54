using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildBulletinMessage : BulletinMessage
    {
        public new const uint Id = 6689;

        public GuildBulletinMessage(string content, int timestamp, ulong memberId, string memberName,
            int lastNotifiedTimestamp)
        {
            Content = content;
            Timestamp = timestamp;
            MemberId = memberId;
            MemberName = memberName;
            LastNotifiedTimestamp = lastNotifiedTimestamp;
        }

        public GuildBulletinMessage()
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