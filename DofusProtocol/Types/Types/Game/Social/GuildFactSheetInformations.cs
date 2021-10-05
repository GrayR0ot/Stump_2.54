using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GuildFactSheetInformations : GuildInformations
    {
        public new const short Id = 424;

        public GuildFactSheetInformations(uint guildId, string guildName, byte guildLevel, GuildEmblem guildEmblem,
            ulong leaderId, ushort nbMembers)
        {
            this.guildId = (int) guildId;
            this.guildName = guildName;
            this.guildLevel = (sbyte) guildLevel;
            GuildEmblem = guildEmblem;
            LeaderId = leaderId;
            NbMembers = nbMembers;
        }

        public GuildFactSheetInformations()
        {
        }

        public override short TypeId => Id;

        public ulong LeaderId { get; set; }
        public ushort NbMembers { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarULong(LeaderId);
            writer.WriteVarUShort(NbMembers);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LeaderId = reader.ReadVarULong();
            NbMembers = reader.ReadVarUShort();
        }
    }
}