using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class IgnoredInformations : AbstractContactInformations
    {
        public new const short Id = 106;

        public IgnoredInformations(int accountId, string accountName)
        {
            AccountId = accountId;
            AccountName = accountName;
        }

        public IgnoredInformations()
        {
        }

        public override short TypeId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}