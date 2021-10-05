﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeStartOkCraftWithInformationMessage : ExchangeStartOkCraftMessage
    {
        public new const uint Id = 5941;

        public ExchangeStartOkCraftWithInformationMessage(uint skillId)
        {
            SkillId = skillId;
        }

        public ExchangeStartOkCraftWithInformationMessage()
        {
        }

        public override uint MessageId => Id;

        public uint SkillId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUInt(SkillId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SkillId = reader.ReadVarUInt();
        }
    }
}