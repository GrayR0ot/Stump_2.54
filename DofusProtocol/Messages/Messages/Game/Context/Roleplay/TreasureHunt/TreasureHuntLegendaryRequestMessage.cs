﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TreasureHuntLegendaryRequestMessage : Message
    {
        public const uint Id = 6499;

        public TreasureHuntLegendaryRequestMessage(ushort legendaryId)
        {
            LegendaryId = legendaryId;
        }

        public TreasureHuntLegendaryRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort LegendaryId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(LegendaryId);
        }

        public override void Deserialize(IDataReader reader)
        {
            LegendaryId = reader.ReadVarUShort();
        }
    }
}