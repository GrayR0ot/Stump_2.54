using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ContactLookRequestByIdMessage : ContactLookRequestMessage
    {
        public new const uint Id = 5935;

        public ContactLookRequestByIdMessage(byte requestId, sbyte contactType, ulong playerId)
        {
            RequestId = requestId;
            ContactType = contactType;
            PlayerId = playerId;
        }

        public ContactLookRequestByIdMessage()
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