using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class NpcDialogReplyMessage : Message
    {
        public const uint Id = 5616;

        public NpcDialogReplyMessage(uint replyId)
        {
            ReplyId = replyId;
        }

        public NpcDialogReplyMessage()
        {
        }

        public override uint MessageId => Id;

        public uint ReplyId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ReplyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ReplyId = reader.ReadVarUInt();
        }
    }
}