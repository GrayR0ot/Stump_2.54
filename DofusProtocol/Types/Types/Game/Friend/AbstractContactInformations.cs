using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class AbstractContactInformations
    {
        public const short Id = 380;

        public AbstractContactInformations(int accountId, string accountName)
        {
            AccountId = accountId;
            AccountName = accountName;
        }

        public AbstractContactInformations()
        {
        }

        public virtual short TypeId => Id;

        public int AccountId { get; set; }
        public string AccountName { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteUTF(AccountName);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            AccountId = reader.ReadInt();
            AccountName = reader.ReadUTF();
        }
    }
}