using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class InviteInHavenBagMessage : Message
    {
        public const uint Id = 6642;

        public InviteInHavenBagMessage(CharacterMinimalInformations guestInformations, bool accept)
        {
            GuestInformations = guestInformations;
            Accept = accept;
        }

        public InviteInHavenBagMessage()
        {
        }

        public override uint MessageId => Id;

        public CharacterMinimalInformations GuestInformations { get; set; }
        public bool Accept { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            GuestInformations.Serialize(writer);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuestInformations = new CharacterMinimalInformations();
            GuestInformations.Deserialize(reader);
            Accept = reader.ReadBoolean();
        }
    }
}