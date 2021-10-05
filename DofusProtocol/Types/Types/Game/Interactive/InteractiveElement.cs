﻿using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class InteractiveElement
    {
        public const short Id = 80;

        public InteractiveElement(int elementId, int elementTypeId, InteractiveElementSkill[] enabledSkills,
            InteractiveElementSkill[] disabledSkills, bool onCurrentMap)
        {
            ElementId = elementId;
            ElementTypeId = elementTypeId;
            EnabledSkills = enabledSkills;
            DisabledSkills = disabledSkills;
            OnCurrentMap = onCurrentMap;
        }

        public InteractiveElement()
        {
        }

        public virtual short TypeId => Id;

        public int ElementId { get; set; }
        public int ElementTypeId { get; set; }
        public InteractiveElementSkill[] EnabledSkills { get; set; }
        public InteractiveElementSkill[] DisabledSkills { get; set; }
        public bool OnCurrentMap { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ElementId);
            writer.WriteInt(ElementTypeId);
            writer.WriteShort((short) EnabledSkills.Count());
            for (var enabledSkillsIndex = 0; enabledSkillsIndex < EnabledSkills.Count(); enabledSkillsIndex++)
            {
                var objectToSend = EnabledSkills[enabledSkillsIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }

            writer.WriteShort((short) DisabledSkills.Count());
            for (var disabledSkillsIndex = 0; disabledSkillsIndex < DisabledSkills.Count(); disabledSkillsIndex++)
            {
                var objectToSend = DisabledSkills[disabledSkillsIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }

            writer.WriteBoolean(OnCurrentMap);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            ElementId = reader.ReadInt();
            ElementTypeId = reader.ReadInt();
            var enabledSkillsCount = reader.ReadUShort();
            EnabledSkills = new InteractiveElementSkill[enabledSkillsCount];
            for (var enabledSkillsIndex = 0; enabledSkillsIndex < enabledSkillsCount; enabledSkillsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElementSkill>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                EnabledSkills[enabledSkillsIndex] = objectToAdd;
            }

            var disabledSkillsCount = reader.ReadUShort();
            DisabledSkills = new InteractiveElementSkill[disabledSkillsCount];
            for (var disabledSkillsIndex = 0; disabledSkillsIndex < disabledSkillsCount; disabledSkillsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElementSkill>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                DisabledSkills[disabledSkillsIndex] = objectToAdd;
            }

            OnCurrentMap = reader.ReadBoolean();
        }
    }
}