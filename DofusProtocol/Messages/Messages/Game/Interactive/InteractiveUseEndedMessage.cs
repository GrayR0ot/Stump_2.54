using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class InteractiveUseEndedMessage : Message
    {
        public const uint Id = 6112;

        public InteractiveUseEndedMessage(uint elemId, ushort skillId)
        {
            ElemId = elemId;
            SkillId = skillId;
        }

        public InteractiveUseEndedMessage()
        {
        }

        public override uint MessageId => Id;

        public uint ElemId { get; set; }
        public ushort SkillId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ElemId);
            writer.WriteVarUShort(SkillId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ElemId = reader.ReadVarUInt();
            SkillId = reader.ReadVarUShort();
        }
    }
}