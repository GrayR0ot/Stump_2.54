using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MountReleasedMessage : Message
    {
        public const uint Id = 6308;

        public MountReleasedMessage(int mountId)
        {
            MountId = mountId;
        }

        public MountReleasedMessage()
        {
        }

        public override uint MessageId => Id;

        public int MountId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(MountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MountId = reader.ReadVarInt();
        }
    }
}