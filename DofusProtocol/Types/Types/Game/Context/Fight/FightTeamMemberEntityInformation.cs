using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class FightTeamMemberEntityInformation : FightTeamMemberInformations
    {
        public new const short Id = 549;

        public FightTeamMemberEntityInformation(double objectId, sbyte entityModelId, ushort level, double masterId)
        {
            ObjectId = objectId;
            EntityModelId = entityModelId;
            Level = level;
            MasterId = masterId;
        }

        public FightTeamMemberEntityInformation()
        {
        }

        public override short TypeId => Id;

        public sbyte EntityModelId { get; set; }
        public ushort Level { get; set; }
        public double MasterId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(EntityModelId);
            writer.WriteVarUShort(Level);
            writer.WriteDouble(MasterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            EntityModelId = reader.ReadSByte();
            Level = reader.ReadVarUShort();
            MasterId = reader.ReadDouble();
        }
    }
}