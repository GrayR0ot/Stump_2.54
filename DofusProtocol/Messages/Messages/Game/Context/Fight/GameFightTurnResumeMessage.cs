using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightTurnResumeMessage : GameFightTurnStartMessage
    {
        public new const uint Id = 6307;

        public GameFightTurnResumeMessage(double objectId, uint waitTime, uint remainingTime)
        {
            ObjectId = objectId;
            WaitTime = waitTime;
            RemainingTime = remainingTime;
        }

        public GameFightTurnResumeMessage()
        {
        }

        public override uint MessageId => Id;

        public uint RemainingTime { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUInt(RemainingTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            RemainingTime = reader.ReadVarUInt();
        }
    }
}