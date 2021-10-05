using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TreasureHuntDigRequestAnswerFailedMessage : TreasureHuntDigRequestAnswerMessage
    {
        public new const uint Id = 6509;

        public TreasureHuntDigRequestAnswerFailedMessage(sbyte questType, sbyte result, sbyte wrongFlagCount)
        {
            QuestType = questType;
            Result = result;
            WrongFlagCount = wrongFlagCount;
        }

        public TreasureHuntDigRequestAnswerFailedMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte WrongFlagCount { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(WrongFlagCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WrongFlagCount = reader.ReadSByte();
        }
    }
}