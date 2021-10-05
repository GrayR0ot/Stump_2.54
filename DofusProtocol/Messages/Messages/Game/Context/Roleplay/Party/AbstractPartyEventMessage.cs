using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AbstractPartyEventMessage : AbstractPartyMessage
    {
        public new const uint Id = 6273;

        public AbstractPartyEventMessage(uint partyId)
        {
            PartyId = partyId;
        }

        public AbstractPartyEventMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}