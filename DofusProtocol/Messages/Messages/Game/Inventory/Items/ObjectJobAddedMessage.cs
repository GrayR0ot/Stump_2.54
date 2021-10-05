﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectJobAddedMessage : Message
    {
        public const uint Id = 6014;

        public ObjectJobAddedMessage(sbyte jobId)
        {
            JobId = jobId;
        }

        public ObjectJobAddedMessage()
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