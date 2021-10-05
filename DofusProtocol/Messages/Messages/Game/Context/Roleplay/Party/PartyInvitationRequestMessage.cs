using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyInvitationRequestMessage : Message
    {
        public const uint Id = 5585;

        public PartyInvitationRequestMessage(string name)
        {
            Name = name;
        }

        public PartyInvitationRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public string Name { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
        }
    }
}