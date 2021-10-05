using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameMapMovementRequestMessage : Message
    {
        public const uint Id = 950;

        public GameMapMovementRequestMessage(short[] keyMovements, double mapId)
        {
            KeyMovements = keyMovements;
            MapId = mapId;
        }

        public GameMapMovementRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public short[] KeyMovements { get; set; }
        public double MapId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) KeyMovements.Count());
            for (var keyMovementsIndex = 0; keyMovementsIndex < KeyMovements.Count(); keyMovementsIndex++)
                writer.WriteShort(KeyMovements[keyMovementsIndex]);
            writer.WriteDouble(MapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            var keyMovementsCount = reader.ReadUShort();
            KeyMovements = new short[keyMovementsCount];
            for (var keyMovementsIndex = 0; keyMovementsIndex < keyMovementsCount; keyMovementsIndex++)
                KeyMovements[keyMovementsIndex] = reader.ReadShort();
            MapId = reader.ReadDouble();
        }
    }
}