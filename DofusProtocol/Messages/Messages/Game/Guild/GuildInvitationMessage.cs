using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildInvitationMessage : Message
    {
        public const uint Id = 5551;

        public GuildInvitationMessage(ulong targetId)
        {
            TargetId = targetId;
        }

        public GuildInvitationMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong TargetId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TargetId = reader.ReadVarULong();
        }
    }
}