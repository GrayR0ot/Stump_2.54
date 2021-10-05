using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DocumentReadingBeginMessage : Message
    {
        public const uint Id = 5675;

        public DocumentReadingBeginMessage(ushort documentId)
        {
            DocumentId = documentId;
        }

        public DocumentReadingBeginMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort DocumentId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(DocumentId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DocumentId = reader.ReadVarUShort();
        }
    }
}