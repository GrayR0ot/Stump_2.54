using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AllianceKickRequestMessage : Message
    {
        public const uint Id = 6400;
        public uint kickedId;

        public AllianceKickRequestMessage(uint kickedId)
        {
            this.kickedId = kickedId;
        }

        public AllianceKickRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(kickedId);
        }

        public override void Deserialize(IDataReader reader)
        {
            kickedId = reader.ReadVarUInt();
        }
    }
}