using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PrismInfoJoinLeaveRequestMessage : Message
    {
        public const uint Id = 5844;

        public PrismInfoJoinLeaveRequestMessage(bool join)
        {
            Join = join;
        }

        public PrismInfoJoinLeaveRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Join { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Join);
        }

        public override void Deserialize(IDataReader reader)
        {
            Join = reader.ReadBoolean();
        }
    }
}