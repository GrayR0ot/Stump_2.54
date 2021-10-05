using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HouseToSellListMessage : Message
    {
        public const uint Id = 6140;

        public HouseToSellListMessage(ushort pageIndex, ushort totalPage, HouseInformationsForSell[] houseList)
        {
            PageIndex = pageIndex;
            TotalPage = totalPage;
            HouseList = houseList;
        }

        public HouseToSellListMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort PageIndex { get; set; }
        public ushort TotalPage { get; set; }
        public HouseInformationsForSell[] HouseList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(PageIndex);
            writer.WriteVarUShort(TotalPage);
            writer.WriteShort((short) HouseList.Count());
            for (var houseListIndex = 0; houseListIndex < HouseList.Count(); houseListIndex++)
            {
                var objectToSend = HouseList[houseListIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            PageIndex = reader.ReadVarUShort();
            TotalPage = reader.ReadVarUShort();
            var houseListCount = reader.ReadUShort();
            HouseList = new HouseInformationsForSell[houseListCount];
            for (var houseListIndex = 0; houseListIndex < houseListCount; houseListIndex++)
            {
                var objectToAdd = new HouseInformationsForSell();
                objectToAdd.Deserialize(reader);
                HouseList[houseListIndex] = objectToAdd;
            }
        }
    }
}