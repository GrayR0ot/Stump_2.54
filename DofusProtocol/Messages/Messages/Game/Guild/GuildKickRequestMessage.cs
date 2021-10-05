using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildKickRequestMessage : Message
    {
        public const uint Id = 5887;

        public GuildKickRequestMessage(ulong kickedId)
        {
            KickedId = kickedId;
        }

        public GuildKickRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong KickedId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(KickedId);
        }

        public override void Deserialize(IDataReader reader)
        {
            KickedId = reader.ReadVarULong();
        }
    }
}