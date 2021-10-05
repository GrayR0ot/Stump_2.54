using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameActionFightUnmarkCellsMessage : AbstractGameActionMessage
    {
        public new const uint Id = 5570;

        public GameActionFightUnmarkCellsMessage(ushort actionId, double sourceId, short markId)
        {
            ActionId = actionId;
            SourceId = sourceId;
            MarkId = markId;
        }

        public GameActionFightUnmarkCellsMessage()
        {
        }

        public override uint MessageId => Id;

        public short MarkId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MarkId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MarkId = reader.ReadShort();
        }
    }
}