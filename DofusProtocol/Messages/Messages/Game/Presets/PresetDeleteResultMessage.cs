using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PresetDeleteResultMessage : Message
    {
        public const uint Id = 6748;

        public PresetDeleteResultMessage(short presetId, sbyte code)
        {
            PresetId = presetId;
            Code = code;
        }

        public PresetDeleteResultMessage()
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