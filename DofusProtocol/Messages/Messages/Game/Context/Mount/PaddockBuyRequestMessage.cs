using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PaddockBuyRequestMessage : Message
    {
        public const uint Id = 5951;

        public PaddockBuyRequestMessage(ulong proposedPrice)
        {
            ProposedPrice = proposedPrice;
        }

        public PaddockBuyRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong ProposedPrice { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(ProposedPrice);
        }

        public override void Deserialize(IDataReader reader)
        {
            ProposedPrice = reader.ReadVarULong();
        }
    }
}