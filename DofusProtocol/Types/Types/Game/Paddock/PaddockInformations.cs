using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class PaddockInformations
    {
        public const short Id = 132;

        public PaddockInformations(ushort maxOutdoorMount, ushort maxItems)
        {
            MaxOutdoorMount = maxOutdoorMount;
            MaxItems = maxItems;
        }

        public PaddockInformations()
        {
        }

        public virtual short TypeId => Id;

        public ushort MaxOutdoorMount { get; set; }
        public ushort MaxItems { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(MaxOutdoorMount);
            writer.WriteVarUShort(MaxItems);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            MaxOutdoorMount = reader.ReadVarUShort();
            MaxItems = reader.ReadVarUShort();
        }
    }
}