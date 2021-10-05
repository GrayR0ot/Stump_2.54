using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AllianceListMessage : Message
    {
        public const uint Id = 6408;

        public AllianceListMessage(AllianceFactSheetInformations[] alliances)
        {
            Alliances = alliances;
        }

        public AllianceListMessage()
        {
        }

        public override uint MessageId => Id;

        public AllianceFactSheetInformations[] Alliances { get; set; }

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
            Alliances = new AllianceFactSheetInformations[alliancesCount];
            for (var alliancesIndex = 0; alliancesIndex < alliancesCount; alliancesIndex++)
            {
                var objectToAdd = new AllianceFactSheetInformations();
                objectToAdd.Deserialize(reader);
                Alliances[alliancesIndex] = objectToAdd;
            }
        }
    }
}