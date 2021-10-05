using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class JobCrafterDirectoryAddMessage : Message
    {
        public const uint Id = 5651;

        public JobCrafterDirectoryAddMessage(JobCrafterDirectoryListEntry listEntry)
        {
            ListEntry = listEntry;
        }

        public JobCrafterDirectoryAddMessage()
        {
        }

        public override uint MessageId => Id;

        public JobCrafterDirectoryListEntry ListEntry { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            ListEntry.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ListEntry = new JobCrafterDirectoryListEntry();
            ListEntry.Deserialize(reader);
        }
    }
}