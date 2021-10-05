using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class FinishMoveSetRequestMessage : Message
    {
        public const uint Id = 6703;

        public FinishMoveSetRequestMessage(int finishMoveId, bool finishMoveState)
        {
            FinishMoveId = finishMoveId;
            FinishMoveState = finishMoveState;
        }

        public FinishMoveSetRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public int FinishMoveId { get; set; }
        public bool FinishMoveState { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FinishMoveId);
            writer.WriteBoolean(FinishMoveState);
        }

        public override void Deserialize(IDataReader reader)
        {
            FinishMoveId = reader.ReadInt();
            FinishMoveState = reader.ReadBoolean();
        }
    }
}