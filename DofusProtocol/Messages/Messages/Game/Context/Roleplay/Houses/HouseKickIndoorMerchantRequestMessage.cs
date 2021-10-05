using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HouseKickIndoorMerchantRequestMessage : Message
    {
        public const uint Id = 5661;

        public HouseKickIndoorMerchantRequestMessage(ushort cellId)
        {
            CellId = cellId;
        }

        public HouseKickIndoorMerchantRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort CellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUShort();
        }
    }
}