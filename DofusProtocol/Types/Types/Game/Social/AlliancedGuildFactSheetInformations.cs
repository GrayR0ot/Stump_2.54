using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class AlliancedGuildFactSheetInformations : GuildInformations
    {
        public new const short Id = 422;

        public AlliancedGuildFactSheetInformations(uint guildId, string guildName, byte guildLevel,
            GuildEmblem guildEmblem, BasicNamedAllianceInformations allianceInfos)
        {
            this.guildId = (int) guildId;
            this.guildName = guildName;
            this.guildLevel = (sbyte) guildLevel;
            GuildEmblem = guildEmblem;
            AllianceInfos = allianceInfos;
        }

        public AlliancedGuildFactSheetInformations()
        {
        }

        public override short TypeId => Id;

        public BasicNamedAllianceInformations AllianceInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AllianceInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceInfos = new BasicNamedAllianceInformations();
            AllianceInfos.Deserialize(reader);
        }
    }
}