using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DungeonPartyFinderAvailableDungeonsMessage : Message
    {
        public const uint Id = 6242;

        public DungeonPartyFinderAvailableDungeonsMessage(ushort[] dungeonIds)
        {
            DungeonIds = dungeonIds;
        }

        public DungeonPartyFinderAvailableDungeonsMessage()
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