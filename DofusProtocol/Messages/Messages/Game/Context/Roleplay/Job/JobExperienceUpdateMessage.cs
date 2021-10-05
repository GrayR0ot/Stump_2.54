using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class JobExperienceUpdateMessage : Message
    {
        public const uint Id = 5654;

        public JobExperienceUpdateMessage(JobExperience experiencesUpdate)
        {
            ExperiencesUpdate = experiencesUpdate;
        }

        public JobExperienceUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public JobExperience ExperiencesUpdate { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            ExperiencesUpdate.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ExperiencesUpdate = new JobExperience();
            ExperiencesUpdate.Deserialize(reader);
        }
    }
}