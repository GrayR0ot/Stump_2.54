using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class FightTeamInformations : AbstractFightTeamInformations
    {
        public new const short Id = 33;

        public FightTeamInformations(sbyte teamId, double leaderId, sbyte teamSide, sbyte teamTypeId, sbyte nbWaves,
            FightTeamMemberInformations[] teamMembers)
        {
            TeamId = teamId;
            LeaderId = leaderId;
            TeamSide = teamSide;
            TeamTypeId = teamTypeId;
            NbWaves = nbWaves;
            TeamMembers = teamMembers;
        }

        public FightTeamInformations()
        {
        }

        public override short TypeId => Id;

        public FightTeamMemberInformations[] TeamMembers { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) TeamMembers.Count());
            for (var teamMembersIndex = 0; teamMembersIndex < TeamMembers.Count(); teamMembersIndex++)
            {
                var objectToSend = TeamMembers[teamMembersIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var teamMembersCount = reader.ReadUShort();
            TeamMembers = new FightTeamMemberInformations[teamMembersCount];
            for (var teamMembersIndex = 0; teamMembersIndex < teamMembersCount; teamMembersIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<FightTeamMemberInformations>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                TeamMembers[teamMembersIndex] = objectToAdd;
            }
        }
    }
}