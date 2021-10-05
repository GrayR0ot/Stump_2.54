using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyMemberEjectedMessage : PartyMemberRemoveMessage
    {
        public new const uint Id = 6252;

        public PartyMemberEjectedMessage(uint partyId, ulong leavingPlayerId, ulong kickerId)
        {
            PartyId = partyId;
            LeavingPlayerId = leavingPlayerId;
            KickerId = kickerId;
        }

        public PartyMemberEjectedMessage()
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