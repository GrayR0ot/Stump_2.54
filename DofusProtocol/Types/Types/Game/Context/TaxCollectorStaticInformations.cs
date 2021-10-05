using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class TaxCollectorStaticInformations
    {
        public const short Id = 147;

        public TaxCollectorStaticInformations(ushort firstNameId, ushort lastNameId, GuildInformations guildIdentity)
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            GuildIdentity = guildIdentity;
        }

        public TaxCollectorStaticInformations()
        {
        }

        public virtual short TypeId => Id;

        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }
        public GuildInformations GuildIdentity { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(FirstNameId);
            writer.WriteVarUShort(LastNameId);
            GuildIdentity.Serialize(writer);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            FirstNameId = reader.ReadVarUShort();
            LastNameId = reader.ReadVarUShort();
            GuildIdentity = new GuildInformations();
            GuildIdentity.Deserialize(reader);
        }
    }
}