using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TreasureHuntFinishedMessage : Message
    {
        public const uint Id = 6483;

        public TreasureHuntFinishedMessage(sbyte questType)
        {
            QuestType = questType;
        }

        public TreasureHuntFinishedMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte QuestType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(QuestType);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadSByte();
        }
    }
}