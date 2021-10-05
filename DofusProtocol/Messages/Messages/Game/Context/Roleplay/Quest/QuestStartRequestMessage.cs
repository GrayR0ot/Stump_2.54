using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class QuestStartRequestMessage : Message
    {
        public const uint Id = 5643;

        public QuestStartRequestMessage(ushort questId)
        {
            QuestId = questId;
        }

        public QuestStartRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort QuestId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(QuestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestId = reader.ReadVarUShort();
        }
    }
}