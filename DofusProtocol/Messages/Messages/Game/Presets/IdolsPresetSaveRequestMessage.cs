using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class IdolsPresetSaveRequestMessage : PresetSaveRequestMessage
    {
        public new const uint Id = 6758;

        public IdolsPresetSaveRequestMessage(short presetId, sbyte symbolId, bool updateData)
        {
            PresetId = presetId;
            SymbolId = symbolId;
            UpdateData = updateData;
        }

        public IdolsPresetSaveRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}