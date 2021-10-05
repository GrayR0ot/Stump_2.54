using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class SkillActionDescriptionCraft : SkillActionDescription
    {
        public new const short Id = 100;

        public SkillActionDescriptionCraft(ushort skillId, sbyte probability)
        {
            SkillId = skillId;
            Probability = probability;
        }

        public SkillActionDescriptionCraft()
        {
        }

        public override short TypeId => Id;

        public sbyte Probability { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Probability);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Probability = reader.ReadSByte();
        }
    }
}