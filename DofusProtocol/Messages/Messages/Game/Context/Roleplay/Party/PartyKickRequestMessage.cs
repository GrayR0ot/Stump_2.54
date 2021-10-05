using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyKickRequestMessage : AbstractPartyMessage
    {
        public new const uint Id = 5592;

        public PartyKickRequestMessage(uint partyId, ulong playerId)
        {
            PartyId = partyId;
            PlayerId = playerId;
        }

        public PartyKickRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong PlayerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarULong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarULong();
        }
    }
}