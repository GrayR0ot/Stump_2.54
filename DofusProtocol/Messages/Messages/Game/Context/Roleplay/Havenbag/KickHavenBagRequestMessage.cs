using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class KickHavenBagRequestMessage : Message
    {
        public const uint Id = 6652;

        public KickHavenBagRequestMessage(ulong guestId)
        {
            GuestId = guestId;
        }

        public KickHavenBagRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong GuestId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(GuestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuestId = reader.ReadVarULong();
        }
    }
}