using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class JobDescriptionMessage : Message
    {
        public const uint Id = 5655;

        public JobDescriptionMessage(JobDescription[] jobsDescription)
        {
            JobsDescription = jobsDescription;
        }

        public JobDescriptionMessage()
        {
        }

        public override uint MessageId => Id;

        public JobDescription[] JobsDescription { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) JobsDescription.Count());
            for (var jobsDescriptionIndex = 0; jobsDescriptionIndex < JobsDescription.Count(); jobsDescriptionIndex++)
            {
                var objectToSend = JobsDescription[jobsDescriptionIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var jobsDescriptionCount = reader.ReadUShort();
            JobsDescription = new JobDescription[jobsDescriptionCount];
            for (var jobsDescriptionIndex = 0; jobsDescriptionIndex < jobsDescriptionCount; jobsDescriptionIndex++)
            {
                var objectToAdd = new JobDescription();
                objectToAdd.Deserialize(reader);
                JobsDescription[jobsDescriptionIndex] = objectToAdd;
            }
        }
    }
}