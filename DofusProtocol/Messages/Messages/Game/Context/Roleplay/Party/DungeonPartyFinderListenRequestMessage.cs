using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DungeonPartyFinderListenRequestMessage : Message
    {
        public const uint Id = 6246;

        public DungeonPartyFinderListenRequestMessage(ushort dungeonId)
        {
            DungeonId = dungeonId;
        }

        public DungeonPartyFinderListenRequestMessage()
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