using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ComicReadingBeginMessage : Message
    {
        public const uint Id = 6536;

        public ComicReadingBeginMessage(ushort comicId)
        {
            ComicId = comicId;
        }

        public ComicReadingBeginMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort ComicId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(ComicId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ComicId = reader.ReadVarUShort();
        }
    }
}