using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class JobMultiCraftAvailableSkillsMessage : JobAllowMultiCraftRequestMessage
    {
        public new const uint Id = 5747;

        public JobMultiCraftAvailableSkillsMessage(bool enabled, ulong playerId, ushort[] skills)
        {
            Enabled = enabled;
            PlayerId = playerId;
            Skills = skills;
        }

        public JobMultiCraftAvailableSkillsMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong PlayerId { get; set; }
        public ushort[] Skills { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarULong(PlayerId);
            writer.WriteShort((short) Skills.Count());
            for (var skillsIndex = 0; skillsIndex < Skills.Count(); skillsIndex++)
                writer.WriteVarUShort(Skills[skillsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarULong();
            var skillsCount = reader.ReadUShort();
            Skills = new ushort[skillsCount];
            for (var skillsIndex = 0; skillsIndex < skillsCount; skillsIndex++)
                Skills[skillsIndex] = reader.ReadVarUShort();
        }
    }
}