using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PresetUseRequestMessage : Message
    {
        public const uint Id = 6759;

        public PresetUseRequestMessage(short presetId)
        {
            PresetId = presetId;
        }

        public PresetUseRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public short PresetId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(PresetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadShort();
        }
    }
}