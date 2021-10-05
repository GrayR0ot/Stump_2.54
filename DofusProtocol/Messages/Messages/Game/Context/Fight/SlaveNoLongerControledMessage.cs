using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SlaveNoLongerControledMessage : Message
    {
        public const uint Id = 6807;

        public SlaveNoLongerControledMessage(double masterId, double slaveId)
        {
            MasterId = masterId;
            SlaveId = slaveId;
        }

        public SlaveNoLongerControledMessage()
        {
        }

        public override uint MessageId => Id;

        public double MasterId { get; set; }
        public double SlaveId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MasterId);
            writer.WriteDouble(SlaveId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MasterId = reader.ReadDouble();
            SlaveId = reader.ReadDouble();
        }
    }
}