using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TeleportDestinationsMessage : Message
    {
        public const uint Id = 6829;

        public TeleportDestinationsMessage(sbyte type, TeleportDestination[] destinations)
        {
            Type = type;
            Destinations = destinations;
        }

        public TeleportDestinationsMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Type { get; set; }
        public TeleportDestination[] Destinations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
            writer.WriteShort((short) Destinations.Count());
            for (var destinationsIndex = 0; destinationsIndex < Destinations.Count(); destinationsIndex++)
            {
                var objectToSend = Destinations[destinationsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
            var destinationsCount = reader.ReadUShort();
            Destinations = new TeleportDestination[destinationsCount];
            for (var destinationsIndex = 0; destinationsIndex < destinationsCount; destinationsIndex++)
            {
                var objectToAdd = new TeleportDestination();
                objectToAdd.Deserialize(reader);
                Destinations[destinationsIndex] = objectToAdd;
            }
        }
    }
}