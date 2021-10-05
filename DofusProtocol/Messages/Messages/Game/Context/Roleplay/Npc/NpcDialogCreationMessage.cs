using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class NpcDialogCreationMessage : Message
    {
        public const uint Id = 5618;

        public NpcDialogCreationMessage(double mapId, int npcId)
        {
            MapId = mapId;
            NpcId = npcId;
        }

        public NpcDialogCreationMessage()
        {
        }

        public override uint MessageId => Id;

        public double MapId { get; set; }
        public int NpcId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MapId);
            writer.WriteInt(NpcId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadDouble();
            NpcId = reader.ReadInt();
        }
    }
}