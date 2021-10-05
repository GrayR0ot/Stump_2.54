using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PaddockToSellListMessage : Message
    {
        public const uint Id = 6138;

        public PaddockToSellListMessage(ushort pageIndex, ushort totalPage, PaddockInformationsForSell[] paddockList)
        {
            PageIndex = pageIndex;
            TotalPage = totalPage;
            PaddockList = paddockList;
        }

        public PaddockToSellListMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort PageIndex { get; set; }
        public ushort TotalPage { get; set; }
        public PaddockInformationsForSell[] PaddockList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(PageIndex);
            writer.WriteVarUShort(TotalPage);
            writer.WriteShort((short) PaddockList.Count());
            for (var paddockListIndex = 0; paddockListIndex < PaddockList.Count(); paddockListIndex++)
            {
                var objectToSend = PaddockList[paddockListIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            PageIndex = reader.ReadVarUShort();
            TotalPage = reader.ReadVarUShort();
            var paddockListCount = reader.ReadUShort();
            PaddockList = new PaddockInformationsForSell[paddockListCount];
            for (var paddockListIndex = 0; paddockListIndex < paddockListCount; paddockListIndex++)
            {
                var objectToAdd = new PaddockInformationsForSell();
                objectToAdd.Deserialize(reader);
                PaddockList[paddockListIndex] = objectToAdd;
            }
        }
    }
}