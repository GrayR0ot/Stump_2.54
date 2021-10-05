using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AccessoryPreviewRequestMessage : Message
    {
        public const uint Id = 6518;

        public AccessoryPreviewRequestMessage(ushort[] genericId)
        {
            GenericId = genericId;
        }

        public AccessoryPreviewRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort[] GenericId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) GenericId.Count());
            for (var genericIdIndex = 0; genericIdIndex < GenericId.Count(); genericIdIndex++)
                writer.WriteVarUShort(GenericId[genericIdIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var genericIdCount = reader.ReadUShort();
            GenericId = new ushort[genericIdCount];
            for (var genericIdIndex = 0; genericIdIndex < genericIdCount; genericIdIndex++)
                GenericId[genericIdIndex] = reader.ReadVarUShort();
        }
    }
}