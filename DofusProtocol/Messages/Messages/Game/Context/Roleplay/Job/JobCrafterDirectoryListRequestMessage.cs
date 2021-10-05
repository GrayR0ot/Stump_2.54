using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class JobCrafterDirectoryListRequestMessage : Message
    {
        public const uint Id = 6047;

        public JobCrafterDirectoryListRequestMessage(sbyte jobId)
        {
            JobId = jobId;
        }

        public JobCrafterDirectoryListRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte JobId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(JobId);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadSByte();
        }
    }
}