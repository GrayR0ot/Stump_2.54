using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AbstractGameActionWithAckMessage : AbstractGameActionMessage
    {
        public new const uint Id = 1001;

        public AbstractGameActionWithAckMessage(ushort actionId, double sourceId, short waitAckId)
        {
            ActionId = actionId;
            SourceId = sourceId;
            WaitAckId = waitAckId;
        }

        public AbstractGameActionWithAckMessage()
        {
        }

        public override uint MessageId => Id;

        public short WaitAckId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WaitAckId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WaitAckId = reader.ReadShort();
        }
    }
}