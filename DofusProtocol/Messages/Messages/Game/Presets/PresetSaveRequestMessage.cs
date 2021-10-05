using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PresetSaveRequestMessage : Message
    {
        public const uint Id = 6761;

        public PresetSaveRequestMessage(short presetId, sbyte symbolId, bool updateData)
        {
            PresetId = presetId;
            SymbolId = symbolId;
            UpdateData = updateData;
        }

        public PresetSaveRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public short PresetId { get; set; }
        public sbyte SymbolId { get; set; }
        public bool UpdateData { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(PresetId);
            writer.WriteSByte(SymbolId);
            writer.WriteBoolean(UpdateData);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadShort();
            SymbolId = reader.ReadSByte();
            UpdateData = reader.ReadBoolean();
        }
    }
}