using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TreasureHuntDigRequestMessage : Message
    {
        public const uint Id = 6485;

        public TreasureHuntDigRequestMessage(sbyte questType)
        {
            QuestType = questType;
        }

        public TreasureHuntDigRequestMessage()
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