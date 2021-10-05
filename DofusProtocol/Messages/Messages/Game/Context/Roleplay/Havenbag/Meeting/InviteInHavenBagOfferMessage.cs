using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class InviteInHavenBagOfferMessage : Message
    {
        public const uint Id = 6643;

        public InviteInHavenBagOfferMessage(CharacterMinimalInformations hostInformations, int timeLeftBeforeCancel)
        {
            HostInformations = hostInformations;
            TimeLeftBeforeCancel = timeLeftBeforeCancel;
        }

        public InviteInHavenBagOfferMessage()
        {
        }

        public override uint MessageId => Id;

        public CharacterMinimalInformations HostInformations { get; set; }
        public int TimeLeftBeforeCancel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            HostInformations.Serialize(writer);
            writer.WriteVarInt(TimeLeftBeforeCancel);
        }

        public override void Deserialize(IDataReader reader)
        {
            HostInformations = new CharacterMinimalInformations();
            HostInformations.Deserialize(reader);
            TimeLeftBeforeCancel = reader.ReadVarInt();
        }
    }
}