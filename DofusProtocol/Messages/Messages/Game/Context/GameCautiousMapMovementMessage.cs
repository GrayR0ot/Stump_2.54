using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameCautiousMapMovementMessage : GameMapMovementMessage
    {
        public new const uint Id = 6497;

        public GameCautiousMapMovementMessage(short[] keyMovements, short forcedDirection, double actorId)
        {
            KeyMovements = keyMovements;
            ForcedDirection = forcedDirection;
            ActorId = actorId;
        }

        public GameCautiousMapMovementMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}