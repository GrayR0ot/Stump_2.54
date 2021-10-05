using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildBulletinSetErrorMessage : SocialNoticeSetErrorMessage
    {
        public new const uint Id = 6691;

        public GuildBulletinSetErrorMessage(sbyte reason)
        {
            Reason = reason;
        }

        public GuildBulletinSetErrorMessage()
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