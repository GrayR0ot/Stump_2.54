using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightTurnReadyMessage : Message
    {
        public const uint Id = 716;

        public GameFightTurnReadyMessage(bool isReady)
        {
            IsReady = isReady;
        }

        public GameFightTurnReadyMessage()
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