using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class FinishMoveInformations
    {
        public const short Id = 506;

        public FinishMoveInformations(int finishMoveId, bool finishMoveState)
        {
            FinishMoveId = finishMoveId;
            FinishMoveState = finishMoveState;
        }

        public FinishMoveInformations()
        {
        }

        public virtual short TypeId => Id;

        public int FinishMoveId { get; set; }
        public bool FinishMoveState { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FinishMoveId);
            writer.WriteBoolean(FinishMoveState);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            FinishMoveId = reader.ReadInt();
            FinishMoveState = reader.ReadBoolean();
        }
    }
}