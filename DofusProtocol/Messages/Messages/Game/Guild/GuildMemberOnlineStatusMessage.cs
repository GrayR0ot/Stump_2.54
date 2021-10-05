using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildMemberOnlineStatusMessage : Message
    {
        public const uint Id = 6061;

        public GuildMemberOnlineStatusMessage(ulong memberId, bool online)
        {
            MemberId = memberId;
            Online = online;
        }

        public GuildMemberOnlineStatusMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong MemberId { get; set; }
        public bool Online { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(MemberId);
            writer.WriteBoolean(Online);
        }

        public override void Deserialize(IDataReader reader)
        {
            MemberId = reader.ReadVarULong();
            Online = reader.ReadBoolean();
        }
    }
}