using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class InteractiveElementWithAgeBonus : InteractiveElement
    {
        public new const short Id = 398;

        public InteractiveElementWithAgeBonus(int elementId, int elementTypeId, InteractiveElementSkill[] enabledSkills,
            InteractiveElementSkill[] disabledSkills, bool onCurrentMap, short ageBonus)
        {
            ElementId = elementId;
            ElementTypeId = elementTypeId;
            EnabledSkills = enabledSkills;
            DisabledSkills = disabledSkills;
            OnCurrentMap = onCurrentMap;
            AgeBonus = ageBonus;
        }

        public InteractiveElementWithAgeBonus()
        {
        }

        public override short TypeId => Id;

        public short AgeBonus { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(AgeBonus);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AgeBonus = reader.ReadShort();
        }
    }
}