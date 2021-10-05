using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightPlacementSwapPositionsCancelMessage : Message
    {
        public const uint Id = 6543;

        public GameFightPlacementSwapPositionsCancelMessage(int requestId)
        {
            RequestId = requestId;
        }

        public GameFightPlacementSwapPositionsCancelMessage()
        {
        }

        public override uint MessageId => Id;

        public int RequestId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(RequestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadInt();
        }
    }
}