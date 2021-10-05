using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildHousesInformationMessage : Message
    {
        public const uint Id = 5919;

        public GuildHousesInformationMessage(HouseInformationsForGuild[] housesInformations)
        {
            HousesInformations = housesInformations;
        }

        public GuildHousesInformationMessage()
        {
        }

        public override uint MessageId => Id;

        public HouseInformationsForGuild[] HousesInformations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) HousesInformations.Count());
            for (var housesInformationsIndex = 0;
                housesInformationsIndex < HousesInformations.Count();
                housesInformationsIndex++)
            {
                var objectToSend = HousesInformations[housesInformationsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var housesInformationsCount = reader.ReadUShort();
            HousesInformations = new HouseInformationsForGuild[housesInformationsCount];
            for (var housesInformationsIndex = 0;
                housesInformationsIndex < housesInformationsCount;
                housesInformationsIndex++)
            {
                var objectToAdd = new HouseInformationsForGuild();
                objectToAdd.Deserialize(reader);
                HousesInformations[housesInformationsIndex] = objectToAdd;
            }
        }
    }
}