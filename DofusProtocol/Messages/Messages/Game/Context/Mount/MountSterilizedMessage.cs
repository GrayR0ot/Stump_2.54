using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MountSterilizedMessage : Message
    {
        public const uint Id = 5977;

        public MountSterilizedMessage(int mountId)
        {
            MountId = mountId;
        }

        public MountSterilizedMessage()
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