using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class URLOpenMessage : Message
    {
        public const uint Id = 6266;

        public URLOpenMessage(sbyte urlId)
        {
            UrlId = urlId;
        }

        public URLOpenMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte UrlId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(UrlId);
        }

        public override void Deserialize(IDataReader reader)
        {
            UrlId = reader.ReadSByte();
        }
    }
}