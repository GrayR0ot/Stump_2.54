using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class TaxCollectorStaticExtendedInformations : TaxCollectorStaticInformations
    {
        public new const short Id = 440;

        public TaxCollectorStaticExtendedInformations(ushort firstNameId, ushort lastNameId,
            GuildInformations guildIdentity, AllianceInformations allianceIdentity)
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            GuildIdentity = guildIdentity;
            AllianceIdentity = allianceIdentity;
        }

        public TaxCollectorStaticExtendedInformations()
        {
        }

        public override short TypeId => Id;

        public AllianceInformations AllianceIdentity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AllianceIdentity.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceIdentity = new AllianceInformations();
            AllianceIdentity.Deserialize(reader);
        }
    }
}