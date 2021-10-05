using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PrismFightRemovedMessage : Message
    {
        public const uint Id = 6453;

        public PrismFightRemovedMessage(ushort subAreaId)
        {
            SubAreaId = subAreaId;
        }

        public PrismFightRemovedMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort SubAreaId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(SubAreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUShort();
        }
    }
}