using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PrismFightJoinLeaveRequestMessage : Message
    {
        public const uint Id = 5843;

        public PrismFightJoinLeaveRequestMessage(ushort subAreaId, bool join)
        {
            SubAreaId = subAreaId;
            Join = join;
        }

        public PrismFightJoinLeaveRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort SubAreaId { get; set; }
        public bool Join { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(SubAreaId);
            writer.WriteBoolean(Join);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUShort();
            Join = reader.ReadBoolean();
        }
    }
}