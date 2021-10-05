using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ZaapRespawnUpdatedMessage : Message
    {
        public const uint Id = 6571;

        public ZaapRespawnUpdatedMessage(double mapId)
        {
            MapId = mapId;
        }

        public ZaapRespawnUpdatedMessage()
        {
        }

        public override uint MessageId => Id;

        public double MapId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadDouble();
        }
    }
}