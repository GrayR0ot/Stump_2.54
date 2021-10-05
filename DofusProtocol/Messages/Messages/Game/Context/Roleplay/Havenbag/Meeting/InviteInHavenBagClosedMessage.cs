using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class InviteInHavenBagClosedMessage : Message
    {
        public const uint Id = 6645;

        public InviteInHavenBagClosedMessage(CharacterMinimalInformations hostInformations)
        {
            HostInformations = hostInformations;
        }

        public InviteInHavenBagClosedMessage()
        {
        }

        public override uint MessageId => Id;

        public CharacterMinimalInformations HostInformations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            HostInformations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            HostInformations = new CharacterMinimalInformations();
            HostInformations.Deserialize(reader);
        }
    }
}