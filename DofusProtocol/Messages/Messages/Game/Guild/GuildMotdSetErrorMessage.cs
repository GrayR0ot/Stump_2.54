using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildMotdSetErrorMessage : SocialNoticeSetErrorMessage
    {
        public new const uint Id = 6591;

        public GuildMotdSetErrorMessage(sbyte reason)
        {
            Reason = reason;
        }

        public GuildMotdSetErrorMessage()
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