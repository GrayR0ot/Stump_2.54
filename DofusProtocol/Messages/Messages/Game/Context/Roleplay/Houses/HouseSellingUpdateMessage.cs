using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HouseSellingUpdateMessage : Message
    {
        public const uint Id = 6727;

        public HouseSellingUpdateMessage(uint houseId, int instanceId, bool secondHand, ulong realPrice,
            string buyerName)
        {
            HouseId = houseId;
            InstanceId = instanceId;
            SecondHand = secondHand;
            RealPrice = realPrice;
            BuyerName = buyerName;
        }

        public HouseSellingUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public bool SecondHand { get; set; }
        public ulong RealPrice { get; set; }
        public string BuyerName { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
            writer.WriteVarULong(RealPrice);
            writer.WriteUTF(BuyerName);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUInt();
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
            RealPrice = reader.ReadVarULong();
            BuyerName = reader.ReadUTF();
        }
    }
}