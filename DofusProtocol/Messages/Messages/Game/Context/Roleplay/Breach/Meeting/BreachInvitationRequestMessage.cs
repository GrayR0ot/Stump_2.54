using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachInvitationRequestMessage : Message
    {
        public const uint Id = 6794;

        public BreachInvitationRequestMessage(ulong guest)
        {
            Guest = guest;
        }

        public BreachInvitationRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong Guest { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(Guest);
        }

        public override void Deserialize(IDataReader reader)
        {
            Guest = reader.ReadVarULong();
        }
    }
}