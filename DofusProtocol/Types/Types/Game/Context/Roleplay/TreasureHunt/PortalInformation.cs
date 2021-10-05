using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class PortalInformation
    {
        public const short Id = 466;

        public PortalInformation(int portalId, short areaId)
        {
            PortalId = portalId;
            AreaId = areaId;
        }

        public PortalInformation()
        {
        }

        public virtual short TypeId => Id;

        public int PortalId { get; set; }
        public short AreaId { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(PortalId);
            writer.WriteShort(AreaId);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            PortalId = reader.ReadInt();
            AreaId = reader.ReadShort();
        }
    }
}