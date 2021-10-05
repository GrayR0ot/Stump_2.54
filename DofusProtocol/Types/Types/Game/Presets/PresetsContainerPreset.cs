using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class PresetsContainerPreset : Preset
    {
        public new const short Id = 520;

        public PresetsContainerPreset(short objectId, Preset[] presets)
        {
            ObjectId = objectId;
            Presets = presets;
        }

        public PresetsContainerPreset()
        {
        }

        public override short TypeId => Id;

        public Preset[] Presets { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Presets.Count());
            for (var presetsIndex = 0; presetsIndex < Presets.Count(); presetsIndex++)
            {
                var objectToSend = Presets[presetsIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var presetsCount = reader.ReadUShort();
            Presets = new Preset[presetsCount];
            for (var presetsIndex = 0; presetsIndex < presetsCount; presetsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<Preset>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Presets[presetsIndex] = objectToAdd;
            }
        }
    }
}