using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PresetSavedMessage : Message
    {
        public const uint Id = 6763;

        public PresetSavedMessage(short presetId, Preset preset)
        {
            PresetId = presetId;
            Preset = preset;
        }

        public PresetSavedMessage()
        {
        }

        public override uint MessageId => Id;

        public short PresetId { get; set; }
        public Preset Preset { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(PresetId);
            writer.WriteShort(Preset.TypeId);
            Preset.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadShort();
            Preset = ProtocolTypeManager.GetInstance<Preset>(reader.ReadShort());
            Preset.Deserialize(reader);
        }
    }
}