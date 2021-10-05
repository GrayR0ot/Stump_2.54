using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SocialNoticeSetErrorMessage : Message
    {
        public const uint Id = 6684;

        public SocialNoticeSetErrorMessage(sbyte reason)
        {
            Reason = reason;
        }

        public SocialNoticeSetErrorMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadSByte();
        }
    }
}