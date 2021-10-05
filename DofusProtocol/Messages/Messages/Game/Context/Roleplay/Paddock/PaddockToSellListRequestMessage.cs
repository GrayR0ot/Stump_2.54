using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PaddockToSellListRequestMessage : Message
    {
        public const uint Id = 6141;

        public PaddockToSellListRequestMessage(ushort pageIndex)
        {
            PageIndex = pageIndex;
        }

        public PaddockToSellListRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort PageIndex { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(PageIndex);
        }

        public override void Deserialize(IDataReader reader)
        {
            PageIndex = reader.ReadVarUShort();
        }
    }
}