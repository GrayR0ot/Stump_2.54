using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyLocateMembersMessage : AbstractPartyMessage
    {
        public new const uint Id = 5595;

        public PartyLocateMembersMessage(uint partyId, PartyMemberGeoPosition[] geopositions)
        {
            PartyId = partyId;
            Geopositions = geopositions;
        }

        public PartyLocateMembersMessage()
        {
        }

        public override uint MessageId => Id;

        public PartyMemberGeoPosition[] Geopositions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Geopositions.Count());
            for (var geopositionsIndex = 0; geopositionsIndex < Geopositions.Count(); geopositionsIndex++)
            {
                var objectToSend = Geopositions[geopositionsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var geopositionsCount = reader.ReadUShort();
            Geopositions = new PartyMemberGeoPosition[geopositionsCount];
            for (var geopositionsIndex = 0; geopositionsIndex < geopositionsCount; geopositionsIndex++)
            {
                var objectToAdd = new PartyMemberGeoPosition();
                objectToAdd.Deserialize(reader);
                Geopositions[geopositionsIndex] = objectToAdd;
            }
        }
    }
}