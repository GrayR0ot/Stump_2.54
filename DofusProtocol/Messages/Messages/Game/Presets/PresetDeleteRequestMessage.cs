using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PresetDeleteRequestMessage : Message
    {
        public const uint Id = 6755;

        public PresetDeleteRequestMessage(short presetId)
        {
            PresetId = presetId;
        }

        public PresetDeleteRequestMessage()
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