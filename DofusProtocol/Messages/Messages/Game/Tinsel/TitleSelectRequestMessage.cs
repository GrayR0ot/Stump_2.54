using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TitleSelectRequestMessage : Message
    {
        public const uint Id = 6365;

        public TitleSelectRequestMessage(ushort titleId)
        {
            TitleId = titleId;
        }

        public TitleSelectRequestMessage()
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