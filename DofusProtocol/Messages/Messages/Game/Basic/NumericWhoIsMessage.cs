using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class NumericWhoIsMessage : Message
    {
        public const uint Id = 6297;

        public NumericWhoIsMessage(ulong playerId, int accountId)
        {
            PlayerId = playerId;
            AccountId = accountId;
        }

        public NumericWhoIsMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong PlayerId { get; set; }
        public int AccountId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(PlayerId);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarULong();
            AccountId = reader.ReadInt();
        }
    }
}