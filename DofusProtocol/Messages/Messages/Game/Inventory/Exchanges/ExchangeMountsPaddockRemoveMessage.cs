using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeMountsPaddockRemoveMessage : Message
    {
        public const uint Id = 6559;

        public ExchangeMountsPaddockRemoveMessage(int[] mountsId)
        {
            MountsId = mountsId;
        }

        public ExchangeMountsPaddockRemoveMessage()
        {
        }

        public override uint MessageId => Id;

        public int[] MountsId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) MountsId.Count());
            for (var mountsIdIndex = 0; mountsIdIndex < MountsId.Count(); mountsIdIndex++)
                writer.WriteVarInt(MountsId[mountsIdIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var mountsIdCount = reader.ReadUShort();
            MountsId = new int[mountsIdCount];
            for (var mountsIdIndex = 0; mountsIdIndex < mountsIdCount; mountsIdIndex++)
                MountsId[mountsIdIndex] = reader.ReadVarInt();
        }
    }
}