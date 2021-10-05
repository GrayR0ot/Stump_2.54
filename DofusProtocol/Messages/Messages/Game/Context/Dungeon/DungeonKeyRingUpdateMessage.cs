using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DungeonKeyRingUpdateMessage : Message
    {
        public const uint Id = 6296;

        public DungeonKeyRingUpdateMessage(ushort dungeonId, bool available)
        {
            DungeonId = dungeonId;
            Available = available;
        }

        public DungeonKeyRingUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort DungeonId { get; set; }
        public bool Available { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(DungeonId);
            writer.WriteBoolean(Available);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUShort();
            Available = reader.ReadBoolean();
        }
    }
}