using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeShopStockMultiMovementUpdatedMessage : Message
    {
        public const uint Id = 6038;

        public ExchangeShopStockMultiMovementUpdatedMessage(ObjectItemToSell[] objectInfoList)
        {
            ObjectInfoList = objectInfoList;
        }

        public ExchangeShopStockMultiMovementUpdatedMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItemToSell[] ObjectInfoList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ObjectInfoList.Count());
            for (var objectInfoListIndex = 0; objectInfoListIndex < ObjectInfoList.Count(); objectInfoListIndex++)
            {
                var objectToSend = ObjectInfoList[objectInfoListIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectInfoListCount = reader.ReadUShort();
            ObjectInfoList = new ObjectItemToSell[objectInfoListCount];
            for (var objectInfoListIndex = 0; objectInfoListIndex < objectInfoListCount; objectInfoListIndex++)
            {
                var objectToAdd = new ObjectItemToSell();
                objectToAdd.Deserialize(reader);
                ObjectInfoList[objectInfoListIndex] = objectToAdd;
            }
        }
    }
}