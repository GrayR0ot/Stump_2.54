using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class InteractiveElementSkill
    {
        public const short Id = 219;

        public InteractiveElementSkill(uint skillId, int skillInstanceUid)
        {
            SkillId = skillId;
            SkillInstanceUid = skillInstanceUid;
        }

        public InteractiveElementSkill()
        {
        }

        public virtual short TypeId => Id;

        public uint SkillId { get; set; }
        public int SkillInstanceUid { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(SkillId);
            writer.WriteInt(SkillInstanceUid);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            SkillId = reader.ReadVarUInt();
            SkillInstanceUid = reader.ReadInt();
        }
    }
}