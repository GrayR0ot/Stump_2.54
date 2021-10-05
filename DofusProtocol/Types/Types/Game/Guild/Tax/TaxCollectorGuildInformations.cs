using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class TaxCollectorGuildInformations : TaxCollectorComplementaryInformations
    {
        public new const short Id = 446;

        public TaxCollectorGuildInformations(BasicGuildInformations guild)
        {
            Guild = guild;
        }

        public TaxCollectorGuildInformations()
        {
        }

        public override short TypeId => Id;

        public BasicGuildInformations Guild { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Guild.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Guild = new BasicGuildInformations();
            Guild.Deserialize(reader);
        }
    }
}