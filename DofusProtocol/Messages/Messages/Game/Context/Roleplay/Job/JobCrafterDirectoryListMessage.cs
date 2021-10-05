using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class JobCrafterDirectoryListMessage : Message
    {
        public const uint Id = 6046;

        public JobCrafterDirectoryListMessage(JobCrafterDirectoryListEntry[] listEntries)
        {
            ListEntries = listEntries;
        }

        public JobCrafterDirectoryListMessage()
        {
        }

        public override uint MessageId => Id;

        public JobCrafterDirectoryListEntry[] ListEntries { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ListEntries.Count());
            for (var listEntriesIndex = 0; listEntriesIndex < ListEntries.Count(); listEntriesIndex++)
            {
                var objectToSend = ListEntries[listEntriesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var listEntriesCount = reader.ReadUShort();
            ListEntries = new JobCrafterDirectoryListEntry[listEntriesCount];
            for (var listEntriesIndex = 0; listEntriesIndex < listEntriesCount; listEntriesIndex++)
            {
                var objectToAdd = new JobCrafterDirectoryListEntry();
                objectToAdd.Deserialize(reader);
                ListEntries[listEntriesIndex] = objectToAdd;
            }
        }
    }
}