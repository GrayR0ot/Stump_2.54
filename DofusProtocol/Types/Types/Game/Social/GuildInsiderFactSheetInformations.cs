using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GuildInsiderFactSheetInformations : GuildFactSheetInformations
    {
        public new const short Id = 423;

        public GuildInsiderFactSheetInformations(uint guildId, string guildName, byte guildLevel,
            GuildEmblem guildEmblem, ulong leaderId, ushort nbMembers, string leaderName, ushort nbConnectedMembers,
            sbyte nbTaxCollectors, int lastActivity)
        {
            this.guildId = (int) guildId;
            this.guildName = guildName;
            this.guildLevel = (sbyte) guildLevel;
            GuildEmblem = guildEmblem;
            LeaderId = leaderId;
            NbMembers = nbMembers;
            LeaderName = leaderName;
            NbConnectedMembers = nbConnectedMembers;
            NbTaxCollectors = nbTaxCollectors;
            LastActivity = lastActivity;
        }

        public GuildInsiderFactSheetInformations()
        {
        }

        public override short TypeId => Id;

        public string LeaderName { get; set; }
        public ushort NbConnectedMembers { get; set; }
        public sbyte NbTaxCollectors { get; set; }
        public int LastActivity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(LeaderName);
            writer.WriteVarUShort(NbConnectedMembers);
            writer.WriteSByte(NbTaxCollectors);
            writer.WriteInt(LastActivity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LeaderName = reader.ReadUTF();
            NbConnectedMembers = reader.ReadVarUShort();
            NbTaxCollectors = reader.ReadSByte();
            LastActivity = reader.ReadInt();
        }
    }
}