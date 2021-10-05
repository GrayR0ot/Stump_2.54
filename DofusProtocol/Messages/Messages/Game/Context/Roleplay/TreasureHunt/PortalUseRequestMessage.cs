using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PortalUseRequestMessage : Message
    {
        public const uint Id = 6492;

        public PortalUseRequestMessage(uint portalId)
        {
            PortalId = portalId;
        }

        public PortalUseRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public uint PortalId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(PortalId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PortalId = reader.ReadVarUInt();
        }
    }
}