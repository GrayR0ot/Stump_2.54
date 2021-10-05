using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class IdolPartyRefreshMessage : Message
    {
        public const uint Id = 6583;

        public IdolPartyRefreshMessage(PartyIdol partyIdol)
        {
            PartyIdol = partyIdol;
        }

        public IdolPartyRefreshMessage()
        {
        }

        public override uint MessageId => Id;

        public PartyIdol PartyIdol { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            PartyIdol.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PartyIdol = new PartyIdol();
            PartyIdol.Deserialize(reader);
        }
    }
}