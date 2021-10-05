using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TitleSelectedMessage : Message
    {
        public const uint Id = 6366;

        public TitleSelectedMessage(ushort titleId)
        {
            TitleId = titleId;
        }

        public TitleSelectedMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort TitleId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(TitleId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TitleId = reader.ReadVarUShort();
        }
    }
}