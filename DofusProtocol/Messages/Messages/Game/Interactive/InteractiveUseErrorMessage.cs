﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class InteractiveUseErrorMessage : Message
    {
        public const uint Id = 6384;

        public InteractiveUseErrorMessage(uint elemId, uint skillInstanceUid)
        {
            ElemId = elemId;
            SkillInstanceUid = skillInstanceUid;
        }

        public InteractiveUseErrorMessage()
        {
        }

        public override uint MessageId => Id;

        public uint ElemId { get; set; }
        public uint SkillInstanceUid { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ElemId);
            writer.WriteVarUInt(SkillInstanceUid);
        }

        public override void Deserialize(IDataReader reader)
        {
            ElemId = reader.ReadVarUInt();
            SkillInstanceUid = reader.ReadVarUInt();
        }
    }
}