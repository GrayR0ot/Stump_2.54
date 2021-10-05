using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ItemForPresetUpdateMessage : Message
    {
        public const uint Id = 6760;

        public ItemForPresetUpdateMessage(short presetId, ItemForPreset presetItem)
        {
            PresetId = presetId;
            PresetItem = presetItem;
        }

        public ItemForPresetUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public short PresetId { get; set; }
        public ItemForPreset PresetItem { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(PresetId);
            PresetItem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadShort();
            PresetItem = new ItemForPreset();
            PresetItem.Deserialize(reader);
        }
    }
}