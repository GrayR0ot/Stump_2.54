using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TeleportBuddiesMessage : Message
    {
        public const uint Id = 6289;

        public TeleportBuddiesMessage(ushort dungeonId)
        {
            DungeonId = dungeonId;
        }

        public TeleportBuddiesMessage()
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