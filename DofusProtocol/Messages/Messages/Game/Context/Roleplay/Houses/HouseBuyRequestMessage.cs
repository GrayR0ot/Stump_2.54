using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HouseBuyRequestMessage : Message
    {
        public const uint Id = 5738;

        public HouseBuyRequestMessage(ulong proposedPrice)
        {
            ProposedPrice = proposedPrice;
        }

        public HouseBuyRequestMessage()
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