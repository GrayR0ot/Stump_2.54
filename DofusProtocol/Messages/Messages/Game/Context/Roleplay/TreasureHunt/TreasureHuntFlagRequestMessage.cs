﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TreasureHuntFlagRequestMessage : Message
    {
        public const uint Id = 6508;

        public TreasureHuntFlagRequestMessage(sbyte questType, sbyte index)
        {
            QuestType = questType;
            Index = index;
        }

        public TreasureHuntFlagRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte QuestType { get; set; }
        public sbyte Index { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(QuestType);
            writer.WriteSByte(Index);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadSByte();
            Index = reader.ReadSByte();
        }
    }
}