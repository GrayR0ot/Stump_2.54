using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class JobCrafterDirectoryEntryRequestMessage : Message
    {
        public const uint Id = 6043;

        public JobCrafterDirectoryEntryRequestMessage(ulong playerId)
        {
            PlayerId = playerId;
        }

        public JobCrafterDirectoryEntryRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong PlayerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarULong();
        }
    }
}