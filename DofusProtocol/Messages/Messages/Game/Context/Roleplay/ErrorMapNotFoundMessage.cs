using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ErrorMapNotFoundMessage : Message
    {
        public const uint Id = 6197;

        public ErrorMapNotFoundMessage(double mapId)
        {
            MapId = mapId;
        }

        public ErrorMapNotFoundMessage()
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