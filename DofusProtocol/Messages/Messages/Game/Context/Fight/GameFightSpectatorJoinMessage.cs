using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightSpectatorJoinMessage : GameFightJoinMessage
    {
        public new const uint Id = 6504;

        public GameFightSpectatorJoinMessage(bool isTeamPhase, bool canBeCancelled, bool canSayReady,
            bool isFightStarted, short timeMaxBeforeFightStart, sbyte fightType, NamedPartyTeam[] namedPartyTeams)
        {
            IsTeamPhase = isTeamPhase;
            CanBeCancelled = canBeCancelled;
            CanSayReady = canSayReady;
            IsFightStarted = isFightStarted;
            TimeMaxBeforeFightStart = timeMaxBeforeFightStart;
            FightType = fightType;
            NamedPartyTeams = namedPartyTeams;
        }

        public GameFightSpectatorJoinMessage()
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