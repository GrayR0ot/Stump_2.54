using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ServerExperienceModificatorMessage : Message
    {
        public const uint Id = 6237;

        public ServerExperienceModificatorMessage(ushort experiencePercent)
        {
            ExperiencePercent = experiencePercent;
        }

        public ServerExperienceModificatorMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort ExperiencePercent { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(ExperiencePercent);
        }

        public override void Deserialize(IDataReader reader)
        {
            ExperiencePercent = reader.ReadVarUShort();
        }
    }
}