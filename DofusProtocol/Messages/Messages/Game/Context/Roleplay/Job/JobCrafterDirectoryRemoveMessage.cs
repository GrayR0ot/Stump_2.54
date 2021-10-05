using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class JobCrafterDirectoryRemoveMessage : Message
    {
        public const uint Id = 5653;

        public JobCrafterDirectoryRemoveMessage(sbyte jobId, ulong playerId)
        {
            JobId = jobId;
            PlayerId = playerId;
        }

        public JobCrafterDirectoryRemoveMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte JobId { get; set; }
        public ulong PlayerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(JobId);
            writer.WriteVarULong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadSByte();
            PlayerId = reader.ReadVarULong();
        }
    }
}