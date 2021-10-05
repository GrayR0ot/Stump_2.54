using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class FighterStatsListMessage : Message
    {
        public const uint Id = 6322;

        public FighterStatsListMessage(CharacterCharacteristicsInformations stats)
        {
            Stats = stats;
        }

        public FighterStatsListMessage()
        {
        }

        public override uint MessageId => Id;

        public CharacterCharacteristicsInformations Stats { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Stats.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Stats = new CharacterCharacteristicsInformations();
            Stats.Deserialize(reader);
        }
    }
}