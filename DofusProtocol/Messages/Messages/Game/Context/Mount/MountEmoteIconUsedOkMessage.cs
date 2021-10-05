using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MountEmoteIconUsedOkMessage : Message
    {
        public const uint Id = 5978;

        public MountEmoteIconUsedOkMessage(int mountId, sbyte reactionType)
        {
            MountId = mountId;
            ReactionType = reactionType;
        }

        public MountEmoteIconUsedOkMessage()
        {
        }

        public override uint MessageId => Id;

        public int MountId { get; set; }
        public sbyte ReactionType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(MountId);
            writer.WriteSByte(ReactionType);
        }

        public override void Deserialize(IDataReader reader)
        {
            MountId = reader.ReadVarInt();
            ReactionType = reader.ReadSByte();
        }
    }
}