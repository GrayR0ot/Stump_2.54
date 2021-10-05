using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class IdolsPreset : Preset
    {
        public new const short Id = 491;

        public IdolsPreset(short objectId, short iconId, ushort[] idolIds)
        {
            ObjectId = objectId;
            IconId = iconId;
            IdolIds = idolIds;
        }

        public IdolsPreset()
        {
        }

        public override short TypeId => Id;

        public short IconId { get; set; }
        public ushort[] IdolIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(IconId);
            writer.WriteShort((short) IdolIds.Count());
            for (var idolIdsIndex = 0; idolIdsIndex < IdolIds.Count(); idolIdsIndex++)
                writer.WriteVarUShort(IdolIds[idolIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            IconId = reader.ReadShort();
            var idolIdsCount = reader.ReadUShort();
            IdolIds = new ushort[idolIdsCount];
            for (var idolIdsIndex = 0; idolIdsIndex < idolIdsCount; idolIdsIndex++)
                IdolIds[idolIdsIndex] = reader.ReadVarUShort();
        }
    }
}