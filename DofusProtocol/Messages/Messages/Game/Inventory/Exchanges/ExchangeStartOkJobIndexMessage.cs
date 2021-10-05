using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeStartOkJobIndexMessage : Message
    {
        public const uint Id = 5819;

        public ExchangeStartOkJobIndexMessage(uint[] jobs)
        {
            Jobs = jobs;
        }

        public ExchangeStartOkJobIndexMessage()
        {
        }

        public override uint MessageId => Id;

        public uint[] Jobs { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Jobs.Count());
            for (var jobsIndex = 0; jobsIndex < Jobs.Count(); jobsIndex++) writer.WriteVarUInt(Jobs[jobsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var jobsCount = reader.ReadUShort();
            Jobs = new uint[jobsCount];
            for (var jobsIndex = 0; jobsIndex < jobsCount; jobsIndex++) Jobs[jobsIndex] = reader.ReadVarUInt();
        }
    }
}