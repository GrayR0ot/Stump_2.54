using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PresetUseResultWithMissingIdsMessage : PresetUseResultMessage
    {
        public new const uint Id = 6757;

        public PresetUseResultWithMissingIdsMessage(short presetId, sbyte code, ushort[] missingIds)
        {
            PresetId = presetId;
            Code = code;
            MissingIds = missingIds;
        }

        public PresetUseResultWithMissingIdsMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort[] MissingIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) MissingIds.Count());
            for (var missingIdsIndex = 0; missingIdsIndex < MissingIds.Count(); missingIdsIndex++)
                writer.WriteVarUShort(MissingIds[missingIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var missingIdsCount = reader.ReadUShort();
            MissingIds = new ushort[missingIdsCount];
            for (var missingIdsIndex = 0; missingIdsIndex < missingIdsCount; missingIdsIndex++)
                MissingIds[missingIdsIndex] = reader.ReadVarUShort();
        }
    }
}