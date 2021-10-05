using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PaddockBuyResultMessage : Message
    {
        public const uint Id = 6516;

        public PaddockBuyResultMessage(double paddockId, bool bought, ulong realPrice)
        {
            PaddockId = paddockId;
            Bought = bought;
            RealPrice = realPrice;
        }

        public PaddockBuyResultMessage()
        {
        }

        public override uint MessageId => Id;

        public double PaddockId { get; set; }
        public bool Bought { get; set; }
        public ulong RealPrice { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(PaddockId);
            writer.WriteBoolean(Bought);
            writer.WriteVarULong(RealPrice);
        }

        public override void Deserialize(IDataReader reader)
        {
            PaddockId = reader.ReadDouble();
            Bought = reader.ReadBoolean();
            RealPrice = reader.ReadVarULong();
        }
    }
}