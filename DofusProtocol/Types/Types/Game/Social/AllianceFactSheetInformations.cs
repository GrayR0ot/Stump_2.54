using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class AllianceFactSheetInformations : AllianceInformations
    {
        public new const short Id = 421;

        public AllianceFactSheetInformations(uint allianceId, string allianceTag, string allianceName,
            GuildEmblem allianceEmblem, int creationDate)
        {
            AllianceId = allianceId;
            AllianceTag = allianceTag;
            AllianceName = allianceName;
            AllianceEmblem = allianceEmblem;
            CreationDate = creationDate;
        }

        public AllianceFactSheetInformations()
        {
        }

        public override short TypeId => Id;

        public int CreationDate { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(CreationDate);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CreationDate = reader.ReadInt();
        }
    }
}