using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class DareVersatileInformations
    {
        public const short Id = 504;

        public DareVersatileInformations(double dareId, int countEntrants, int countWinners)
        {
            DareId = dareId;
            CountEntrants = countEntrants;
            CountWinners = countWinners;
        }

        public DareVersatileInformations()
        {
        }

        public virtual short TypeId => Id;

        public double DareId { get; set; }
        public int CountEntrants { get; set; }
        public int CountWinners { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
            writer.WriteInt(CountEntrants);
            writer.WriteInt(CountWinners);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
            CountEntrants = reader.ReadInt();
            CountWinners = reader.ReadInt();
        }
    }
}