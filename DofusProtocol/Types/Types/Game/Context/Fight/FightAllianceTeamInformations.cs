using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class FightAllianceTeamInformations : FightTeamInformations
    {
        public new const short Id = 439;

        public FightAllianceTeamInformations(sbyte teamId, double leaderId, sbyte teamSide, sbyte teamTypeId,
            sbyte nbWaves, FightTeamMemberInformations[] teamMembers, sbyte relation)
        {
            TeamId = teamId;
            LeaderId = leaderId;
            TeamSide = teamSide;
            TeamTypeId = teamTypeId;
            NbWaves = nbWaves;
            TeamMembers = teamMembers;
            Relation = relation;
        }

        public FightAllianceTeamInformations()
        {
        }

        public override short TypeId => Id;

        public sbyte Relation { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Relation);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Relation = reader.ReadSByte();
        }
    }
}