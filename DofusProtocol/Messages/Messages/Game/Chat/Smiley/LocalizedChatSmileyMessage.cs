using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class LocalizedChatSmileyMessage : ChatSmileyMessage
    {
        public new const uint Id = 6185;

        public LocalizedChatSmileyMessage(double entityId, ushort smileyId, int accountId, ushort cellId)
        {
            EntityId = entityId;
            SmileyId = smileyId;
            AccountId = accountId;
            CellId = cellId;
        }

        public LocalizedChatSmileyMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort CellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CellId = reader.ReadVarUShort();
        }
    }
}