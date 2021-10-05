using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class AdditionalTaxCollectorInformations
    {
        public const short Id = 165;

        public AdditionalTaxCollectorInformations(string collectorCallerName, int date)
        {
            CollectorCallerName = collectorCallerName;
            Date = date;
        }

        public AdditionalTaxCollectorInformations()
        {
        }

        public virtual short TypeId => Id;

        public string CollectorCallerName { get; set; }
        public int Date { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(CollectorCallerName);
            writer.WriteInt(Date);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            CollectorCallerName = reader.ReadUTF();
            Date = reader.ReadInt();
        }
    }
}