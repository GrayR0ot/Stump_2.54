using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightReadyMessage : Message
    {
        public const uint Id = 708;

        public GameFightReadyMessage(bool isReady)
        {
            IsReady = isReady;
        }

        public GameFightReadyMessage()
        {
        }

        public override uint MessageId => Id;

        public bool IsReady { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(IsReady);
        }

        public override void Deserialize(IDataReader reader)
        {
            IsReady = reader.ReadBoolean();
        }
    }
}