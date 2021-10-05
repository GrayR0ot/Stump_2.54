using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ZaapDestinationsMessage : TeleportDestinationsMessage
    {
        public new const uint Id = 6830;

        public ZaapDestinationsMessage(sbyte type, TeleportDestination[] destinations, double spawnMapId)
        {
            Type = type;
            Destinations = destinations;
            SpawnMapId = spawnMapId;
        }

        public ZaapDestinationsMessage()
        {
        }

        public override uint MessageId => Id;

        public double SpawnMapId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(SpawnMapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SpawnMapId = reader.ReadDouble();
        }
    }
}