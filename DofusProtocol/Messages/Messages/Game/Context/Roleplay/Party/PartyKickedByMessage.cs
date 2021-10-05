using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyKickedByMessage : AbstractPartyMessage
    {
        public new const uint Id = 5590;

        public PartyKickedByMessage(uint partyId, ulong kickerId)
        {
            PartyId = partyId;
            KickerId = kickerId;
        }

        public PartyKickedByMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong KickerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarULong(KickerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            KickerId = reader.ReadVarULong();
        }
    }
}