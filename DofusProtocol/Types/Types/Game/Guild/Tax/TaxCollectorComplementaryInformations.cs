using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class TaxCollectorComplementaryInformations
    {
        public const short Id = 448;

        public virtual short TypeId => Id;

        public virtual void Serialize(IDataWriter writer)
        {
        }

        public virtual void Deserialize(IDataReader reader)
        {
        }
    }
}