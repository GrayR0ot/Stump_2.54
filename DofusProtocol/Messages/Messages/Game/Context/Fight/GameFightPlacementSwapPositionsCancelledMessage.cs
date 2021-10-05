﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightPlacementSwapPositionsCancelledMessage : Message
    {
        public const uint Id = 6546;

        public GameFightPlacementSwapPositionsCancelledMessage(int requestId, double cancellerId)
        {
            RequestId = requestId;
            CancellerId = cancellerId;
        }

        public GameFightPlacementSwapPositionsCancelledMessage()
        {
        }

        public override uint MessageId => Id;

        public int RequestId { get; set; }
        public double CancellerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(RequestId);
            writer.WriteDouble(CancellerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadInt();
            CancellerId = reader.ReadDouble();
        }
    }
}