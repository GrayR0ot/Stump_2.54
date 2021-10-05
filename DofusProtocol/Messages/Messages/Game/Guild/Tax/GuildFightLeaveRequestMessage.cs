using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildFightLeaveRequestMessage : Message
    {
        public const uint Id = 5715;

        public GuildFightLeaveRequestMessage(double taxCollectorId, ulong characterId)
        {
            TaxCollectorId = taxCollectorId;
            CharacterId = characterId;
        }

        public GuildFightLeaveRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public double TaxCollectorId { get; set; }
        public ulong CharacterId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(TaxCollectorId);
            writer.WriteVarULong(CharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TaxCollectorId = reader.ReadDouble();
            CharacterId = reader.ReadVarULong();
        }
    }
}