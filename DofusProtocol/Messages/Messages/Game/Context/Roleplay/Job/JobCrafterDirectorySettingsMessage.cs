using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class JobCrafterDirectorySettingsMessage : Message
    {
        public const uint Id = 5652;

        public JobCrafterDirectorySettingsMessage(JobCrafterDirectorySettings[] craftersSettings)
        {
            CraftersSettings = craftersSettings;
        }

        public JobCrafterDirectorySettingsMessage()
        {
        }

        public override uint MessageId => Id;

        public JobCrafterDirectorySettings[] CraftersSettings { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) CraftersSettings.Count());
            for (var craftersSettingsIndex = 0;
                craftersSettingsIndex < CraftersSettings.Count();
                craftersSettingsIndex++)
            {
                var objectToSend = CraftersSettings[craftersSettingsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var craftersSettingsCount = reader.ReadUShort();
            CraftersSettings = new JobCrafterDirectorySettings[craftersSettingsCount];
            for (var craftersSettingsIndex = 0; craftersSettingsIndex < craftersSettingsCount; craftersSettingsIndex++)
            {
                var objectToAdd = new JobCrafterDirectorySettings();
                objectToAdd.Deserialize(reader);
                CraftersSettings[craftersSettingsIndex] = objectToAdd;
            }
        }
    }
}