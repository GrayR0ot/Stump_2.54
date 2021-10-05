using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class NpcDialogQuestionMessage : Message
    {
        public const uint Id = 5617;

        public NpcDialogQuestionMessage(uint messageId, string[] dialogParams, uint[] visibleReplies)
        {
            this.messageId = messageId;
            DialogParams = dialogParams;
            VisibleReplies = visibleReplies;
        }

        public NpcDialogQuestionMessage()
        {
        }

        public override uint MessageId => Id;

        public uint messageId { get; set; }
        public string[] DialogParams { get; set; }
        public uint[] VisibleReplies { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(messageId);
            writer.WriteShort((short) DialogParams.Count());
            for (var dialogParamsIndex = 0; dialogParamsIndex < DialogParams.Count(); dialogParamsIndex++)
                writer.WriteUTF(DialogParams[dialogParamsIndex]);
            writer.WriteShort((short) VisibleReplies.Count());
            for (var visibleRepliesIndex = 0; visibleRepliesIndex < VisibleReplies.Count(); visibleRepliesIndex++)
                writer.WriteVarUInt(VisibleReplies[visibleRepliesIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            messageId = reader.ReadVarUInt();
            var dialogParamsCount = reader.ReadUShort();
            DialogParams = new string[dialogParamsCount];
            for (var dialogParamsIndex = 0; dialogParamsIndex < dialogParamsCount; dialogParamsIndex++)
                DialogParams[dialogParamsIndex] = reader.ReadUTF();
            var visibleRepliesCount = reader.ReadUShort();
            VisibleReplies = new uint[visibleRepliesCount];
            for (var visibleRepliesIndex = 0; visibleRepliesIndex < visibleRepliesCount; visibleRepliesIndex++)
                VisibleReplies[visibleRepliesIndex] = reader.ReadVarUInt();
        }
    }
}