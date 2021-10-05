using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class BasicAllianceInformations : AbstractSocialGroupInfos
    {
        public new const short Id = 419;

        public BasicAllianceInformations(uint allianceId, string allianceTag)
        {
            AllianceId = allianceId;
            AllianceTag = allianceTag;
        }

        public BasicAllianceInformations()
        {
        }

        public override short TypeId => Id;

        public uint AllianceId { get; set; }
        public string AllianceTag { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUInt(AllianceId);
            writer.WriteUTF(AllianceTag);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceId = reader.ReadVarUInt();
            AllianceTag = reader.ReadUTF();
        }
    }
}