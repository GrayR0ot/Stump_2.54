using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AllianceVersatileInfoListMessage : Message
    {
        public const uint Id = 6436;

        public AllianceVersatileInfoListMessage(AllianceVersatileInformations[] alliances)
        {
            Alliances = alliances;
        }

        public AllianceVersatileInfoListMessage()
        {
        }

        public override uint MessageId => Id;

        public AllianceVersatileInformations[] Alliances { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Alliances.Count());
            for (var alliancesIndex = 0; alliancesIndex < Alliances.Count(); alliancesIndex++)
            {
                var objectToSend = Alliances[alliancesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var alliancesCount = reader.ReadUShort();
            Alliances = new AllianceVersatileInformations[alliancesCount];
            for (var alliancesIndex = 0; alliancesIndex < alliancesCount; alliancesIndex++)
            {
                var objectToAdd = new AllianceVersatileInformations();
                objectToAdd.Deserialize(reader);
                Alliances[alliancesIndex] = objectToAdd;
            }
        }
    }
}