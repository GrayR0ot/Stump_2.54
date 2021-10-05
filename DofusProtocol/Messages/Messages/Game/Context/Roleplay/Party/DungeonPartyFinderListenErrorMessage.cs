using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DungeonPartyFinderListenErrorMessage : Message
    {
        public const uint Id = 6248;

        public DungeonPartyFinderListenErrorMessage(ushort dungeonId)
        {
            DungeonId = dungeonId;
        }

        public DungeonPartyFinderListenErrorMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort DungeonId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(DungeonId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUShort();
        }
    }
}