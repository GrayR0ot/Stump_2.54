using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class CharacterBuildPreset : PresetsContainerPreset
    {
        public new const short Id = 534;

        public CharacterBuildPreset(short objectId, Preset[] presets, short iconId, string name)
        {
            ObjectId = objectId;
            Presets = presets;
            IconId = iconId;
            Name = name;
        }

        public CharacterBuildPreset()
        {
        }

        public override short TypeId => Id;

        public short IconId { get; set; }
        public string Name { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(IconId);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            IconId = reader.ReadShort();
            Name = reader.ReadUTF();
        }
    }
}