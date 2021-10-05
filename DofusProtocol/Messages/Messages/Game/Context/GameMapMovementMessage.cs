using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameMapMovementMessage : Message
    {
        public const uint Id = 951;

        public GameMapMovementMessage(short[] keyMovements, short forcedDirection, double actorId)
        {
            KeyMovements = keyMovements;
            ForcedDirection = forcedDirection;
            ActorId = actorId;
        }

        public GameMapMovementMessage()
        {
        }

        public override uint MessageId => Id;

        public short[] KeyMovements { get; set; }
        public short ForcedDirection { get; set; }
        public double ActorId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) KeyMovements.Count());
            for (var keyMovementsIndex = 0; keyMovementsIndex < KeyMovements.Count(); keyMovementsIndex++)
                writer.WriteShort(KeyMovements[keyMovementsIndex]);
            writer.WriteShort(ForcedDirection);
            writer.WriteDouble(ActorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            var keyMovementsCount = reader.ReadUShort();
            KeyMovements = new short[keyMovementsCount];
            for (var keyMovementsIndex = 0; keyMovementsIndex < keyMovementsCount; keyMovementsIndex++)
                KeyMovements[keyMovementsIndex] = reader.ReadShort();
            ForcedDirection = reader.ReadShort();
            ActorId = reader.ReadDouble();
        }
    }
}