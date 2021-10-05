using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildFightTakePlaceRequestMessage : GuildFightJoinRequestMessage
    {
        public new const uint Id = 6235;

        public GuildFightTakePlaceRequestMessage(double taxCollectorId, int replacedCharacterId)
        {
            TaxCollectorId = taxCollectorId;
            ReplacedCharacterId = replacedCharacterId;
        }

        public GuildFightTakePlaceRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public int ReplacedCharacterId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(ReplacedCharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ReplacedCharacterId = reader.ReadInt();
        }
    }
}