using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharacterPresetSaveRequestMessage : PresetSaveRequestMessage
    {
        public new const uint Id = 6756;

        public CharacterPresetSaveRequestMessage(short presetId, sbyte symbolId, bool updateData, string name)
        {
            PresetId = presetId;
            SymbolId = symbolId;
            UpdateData = updateData;
            Name = name;
        }

        public CharacterPresetSaveRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public string Name { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
        }
    }
}