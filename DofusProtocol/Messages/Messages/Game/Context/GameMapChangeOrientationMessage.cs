using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameMapChangeOrientationMessage : Message
    {
        public const uint Id = 946;

        public GameMapChangeOrientationMessage(ActorOrientation orientation)
        {
            Orientation = orientation;
        }

        public GameMapChangeOrientationMessage()
        {
        }

        public override uint MessageId => Id;

        public ActorOrientation Orientation { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Orientation.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Orientation = new ActorOrientation();
            Orientation.Deserialize(reader);
        }
    }
}