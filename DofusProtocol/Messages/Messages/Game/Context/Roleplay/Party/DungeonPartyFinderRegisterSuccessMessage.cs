using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DungeonPartyFinderRegisterSuccessMessage : Message
    {
        public const uint Id = 6241;

        public DungeonPartyFinderRegisterSuccessMessage(ushort[] dungeonIds)
        {
            DungeonIds = dungeonIds;
        }

        public DungeonPartyFinderRegisterSuccessMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort[] DungeonIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) DungeonIds.Count());
            for (var dungeonIdsIndex = 0; dungeonIdsIndex < DungeonIds.Count(); dungeonIdsIndex++)
                writer.WriteVarUShort(DungeonIds[dungeonIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var dungeonIdsCount = reader.ReadUShort();
            DungeonIds = new ushort[dungeonIdsCount];
            for (var dungeonIdsIndex = 0; dungeonIdsIndex < dungeonIdsCount; dungeonIdsIndex++)
                DungeonIds[dungeonIdsIndex] = reader.ReadVarUShort();
        }
    }
}