using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ContactLookMessage : Message
    {
        public const uint Id = 5934;

        public ContactLookMessage(uint requestId, string playerName, ulong playerId, EntityLook look)
        {
            RequestId = requestId;
            PlayerName = playerName;
            PlayerId = playerId;
            Look = look;
        }

        public ContactLookMessage()
        {
        }

        public override uint MessageId => Id;

        public uint RequestId { get; set; }
        public string PlayerName { get; set; }
        public ulong PlayerId { get; set; }
        public EntityLook Look { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(RequestId);
            writer.WriteUTF(PlayerName);
            writer.WriteVarULong(PlayerId);
            Look.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadVarUInt();
            PlayerName = reader.ReadUTF();
            PlayerId = reader.ReadVarULong();
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}