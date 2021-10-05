using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightPauseMessage : Message
    {
        public const uint Id = 6754;

        public GameFightPauseMessage(bool isPaused)
        {
            IsPaused = isPaused;
        }

        public GameFightPauseMessage()
        {
        }

        public override uint MessageId => Id;

        public bool IsPaused { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(IsPaused);
        }

        public override void Deserialize(IDataReader reader)
        {
            IsPaused = reader.ReadBoolean();
        }
    }
}