using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MapRunningFightDetailsExtendedMessage : MapRunningFightDetailsMessage
    {
        public new const uint Id = 6500;

        public MapRunningFightDetailsExtendedMessage(ushort fightId, GameFightFighterLightInformations[] attackers,
            GameFightFighterLightInformations[] defenders, NamedPartyTeam[] namedPartyTeams)
        {
            FightId = fightId;
            Attackers = attackers;
            Defenders = defenders;
            NamedPartyTeams = namedPartyTeams;
        }

        public MapRunningFightDetailsExtendedMessage()
        {
        }

        public override uint MessageId => Id;

        public NamedPartyTeam[] NamedPartyTeams { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) NamedPartyTeams.Count());
            for (var namedPartyTeamsIndex = 0; namedPartyTeamsIndex < NamedPartyTeams.Count(); namedPartyTeamsIndex++)
            {
                var objectToSend = NamedPartyTeams[namedPartyTeamsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var namedPartyTeamsCount = reader.ReadUShort();
            NamedPartyTeams = new NamedPartyTeam[namedPartyTeamsCount];
            for (var namedPartyTeamsIndex = 0; namedPartyTeamsIndex < namedPartyTeamsCount; namedPartyTeamsIndex++)
            {
                var objectToAdd = new NamedPartyTeam();
                objectToAdd.Deserialize(reader);
                NamedPartyTeams[namedPartyTeamsIndex] = objectToAdd;
            }
        }
    }
}