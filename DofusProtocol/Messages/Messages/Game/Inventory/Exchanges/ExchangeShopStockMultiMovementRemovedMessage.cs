using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeShopStockMultiMovementRemovedMessage : Message
    {
        public const uint Id = 6037;

        public ExchangeShopStockMultiMovementRemovedMessage(uint[] objectIdList)
        {
            ObjectIdList = objectIdList;
        }

        public ExchangeShopStockMultiMovementRemovedMessage()
        {
        }

        public override uint MessageId => Id;

        public uint[] ObjectIdList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ObjectIdList.Count());
            for (var objectIdListIndex = 0; objectIdListIndex < ObjectIdList.Count(); objectIdListIndex++)
                writer.WriteVarUInt(ObjectIdList[objectIdListIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectIdListCount = reader.ReadUShort();
            ObjectIdList = new uint[objectIdListCount];
            for (var objectIdListIndex = 0; objectIdListIndex < objectIdListCount; objectIdListIndex++)
                ObjectIdList[objectIdListIndex] = reader.ReadVarUInt();
        }
    }
}