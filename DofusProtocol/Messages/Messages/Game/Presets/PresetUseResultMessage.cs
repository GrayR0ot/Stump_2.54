﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PresetUseResultMessage : Message
    {
        public const uint Id = 6747;

        public PresetUseResultMessage(short presetId, sbyte code)
        {
            PresetId = presetId;
            Code = code;
        }

        public PresetUseResultMessage()
        {
        }

        public override uint MessageId => Id;

        public short PresetId { get; set; }
        public sbyte Code { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(PresetId);
            writer.WriteSByte(Code);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadShort();
            Code = reader.ReadSByte();
        }
    }
}