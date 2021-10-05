using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildHouseUpdateInformationMessage : Message
    {
        public const uint Id = 6181;

        public GuildHouseUpdateInformationMessage(HouseInformationsForGuild housesInformations)
        {
            HousesInformations = housesInformations;
        }

        public GuildHouseUpdateInformationMessage()
        {
        }

        public override uint MessageId => Id;

        public HouseInformationsForGuild HousesInformations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            HousesInformations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            HousesInformations = new HouseInformationsForGuild();
            HousesInformations.Deserialize(reader);
        }
    }
}