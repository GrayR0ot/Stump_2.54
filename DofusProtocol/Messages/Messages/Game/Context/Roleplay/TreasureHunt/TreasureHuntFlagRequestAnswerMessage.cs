using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TreasureHuntFlagRequestAnswerMessage : Message
    {
        public const uint Id = 6507;

        public TreasureHuntFlagRequestAnswerMessage(sbyte questType, sbyte result, sbyte index)
        {
            QuestType = questType;
            Result = result;
            Index = index;
        }

        public TreasureHuntFlagRequestAnswerMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte QuestType { get; set; }
        public sbyte Result { get; set; }
        public sbyte Index { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(QuestType);
            writer.WriteSByte(Result);
            writer.WriteSByte(Index);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadSByte();
            Result = reader.ReadSByte();
            Index = reader.ReadSByte();
        }
    }
}