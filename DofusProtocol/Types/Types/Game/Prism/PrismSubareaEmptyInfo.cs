using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class PrismSubareaEmptyInfo
    {
        public const short Id = 438;

        public PrismSubareaEmptyInfo(ushort subAreaId, uint allianceId)
        {
            SubAreaId = subAreaId;
            AllianceId = allianceId;
        }

        public PrismSubareaEmptyInfo()
        {
        }

        public virtual short TypeId => Id;

        public ushort SubAreaId { get; set; }
        public uint AllianceId { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(SubAreaId);
            writer.WriteVarUInt(AllianceId);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUShort();
            AllianceId = reader.ReadVarUInt();
        }
    }
}