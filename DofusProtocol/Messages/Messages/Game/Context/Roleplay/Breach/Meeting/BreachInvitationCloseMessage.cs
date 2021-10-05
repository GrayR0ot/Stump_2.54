using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachInvitationCloseMessage : Message
    {
        public const uint Id = 6790;

        public BreachInvitationCloseMessage(CharacterMinimalInformations host)
        {
            Host = host;
        }

        public BreachInvitationCloseMessage()
        {
        }

        public override uint MessageId => Id;

        public CharacterMinimalInformations Host { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Host.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Host = new CharacterMinimalInformations();
            Host.Deserialize(reader);
        }
    }
}