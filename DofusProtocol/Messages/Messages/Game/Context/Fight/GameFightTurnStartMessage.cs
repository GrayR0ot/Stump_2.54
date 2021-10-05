using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightTurnStartMessage : Message
    {
        public const uint Id = 714;

        public GameFightTurnStartMessage(double objectId, uint waitTime)
        {
            ObjectId = objectId;
            WaitTime = waitTime;
        }

        public GameFightTurnStartMessage()
        {
        }

        public override uint MessageId => Id;

        public double ObjectId { get; set; }
        public uint WaitTime { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ObjectId);
            writer.WriteVarUInt(WaitTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadDouble();
            WaitTime = reader.ReadVarUInt();
        }
    }
}