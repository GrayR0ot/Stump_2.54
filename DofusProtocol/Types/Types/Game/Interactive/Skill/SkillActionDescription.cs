using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class SkillActionDescription
    {
        public const short Id = 102;

        public SkillActionDescription(ushort skillId)
        {
            SkillId = skillId;
        }

        public SkillActionDescription()
        {
        }

        public virtual short TypeId => Id;

        public ushort SkillId { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(SkillId);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            SkillId = reader.ReadVarUShort();
        }
    }
}