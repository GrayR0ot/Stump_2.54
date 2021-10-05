using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class EntitiesPreset : Preset
    {
        public new const short Id = 545;

        public EntitiesPreset(short objectId, short iconId, ushort[] entityIds)
        {
            ObjectId = objectId;
            IconId = iconId;
            EntityIds = entityIds;
        }

        public EntitiesPreset()
        {
        }

        public override short TypeId => Id;

        public short IconId { get; set; }
        public ushort[] EntityIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(IconId);
            writer.WriteShort((short) EntityIds.Count());
            for (var entityIdsIndex = 0; entityIdsIndex < EntityIds.Count(); entityIdsIndex++)
                writer.WriteVarUShort(EntityIds[entityIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            IconId = reader.ReadShort();
            var entityIdsCount = reader.ReadUShort();
            EntityIds = new ushort[entityIdsCount];
            for (var entityIdsIndex = 0; entityIdsIndex < entityIdsCount; entityIdsIndex++)
                EntityIds[entityIdsIndex] = reader.ReadVarUShort();
        }
    }
}