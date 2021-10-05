using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class JobBookSubscribeRequestMessage : Message
    {
        public const uint Id = 6592;

        public JobBookSubscribeRequestMessage(byte[] jobIds)
        {
            JobIds = jobIds;
        }

        public JobBookSubscribeRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public byte[] JobIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) JobIds.Count());
            for (var jobIdsIndex = 0; jobIdsIndex < JobIds.Count(); jobIdsIndex++)
                writer.WriteByte(JobIds[jobIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var jobIdsCount = reader.ReadUShort();
            JobIds = new byte[jobIdsCount];
            for (var jobIdsIndex = 0; jobIdsIndex < jobIdsCount; jobIdsIndex++) JobIds[jobIdsIndex] = reader.ReadByte();
        }
    }
}