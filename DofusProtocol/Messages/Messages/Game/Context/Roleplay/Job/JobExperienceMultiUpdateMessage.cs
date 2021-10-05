using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class JobExperienceMultiUpdateMessage : Message
    {
        public const uint Id = 5809;

        public JobExperienceMultiUpdateMessage(JobExperience[] experiencesUpdate)
        {
            ExperiencesUpdate = experiencesUpdate;
        }

        public JobExperienceMultiUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public JobExperience[] ExperiencesUpdate { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ExperiencesUpdate.Count());
            for (var experiencesUpdateIndex = 0;
                experiencesUpdateIndex < ExperiencesUpdate.Count();
                experiencesUpdateIndex++)
            {
                var objectToSend = ExperiencesUpdate[experiencesUpdateIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var experiencesUpdateCount = reader.ReadUShort();
            ExperiencesUpdate = new JobExperience[experiencesUpdateCount];
            for (var experiencesUpdateIndex = 0;
                experiencesUpdateIndex < experiencesUpdateCount;
                experiencesUpdateIndex++)
            {
                var objectToAdd = new JobExperience();
                objectToAdd.Deserialize(reader);
                ExperiencesUpdate[experiencesUpdateIndex] = objectToAdd;
            }
        }
    }
}