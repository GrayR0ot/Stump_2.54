﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PrismSetSabotagedRequestMessage : Message
    {
        public const uint Id = 6468;

        public PrismSetSabotagedRequestMessage(ushort subAreaId)
        {
            SubAreaId = subAreaId;
        }

        public PrismSetSabotagedRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort SubAreaId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(SubAreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUShort();
        }
    }
}