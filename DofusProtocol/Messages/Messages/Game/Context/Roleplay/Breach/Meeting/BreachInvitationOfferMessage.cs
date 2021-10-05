using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachInvitationOfferMessage : Message
    {
        public const uint Id = 6805;

        public BreachInvitationOfferMessage(CharacterMinimalInformations host, uint timeLeftBeforeCancel)
        {
            Host = host;
            TimeLeftBeforeCancel = timeLeftBeforeCancel;
        }

        public BreachInvitationOfferMessage()
        {
        }

        public override uint MessageId => Id;

        public CharacterMinimalInformations Host { get; set; }
        public uint TimeLeftBeforeCancel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Host.Serialize(writer);
            writer.WriteVarUInt(TimeLeftBeforeCancel);
        }

        public override void Deserialize(IDataReader reader)
        {
            Host = new CharacterMinimalInformations();
            Host.Deserialize(reader);
            TimeLeftBeforeCancel = reader.ReadVarUInt();
        }
    }
}