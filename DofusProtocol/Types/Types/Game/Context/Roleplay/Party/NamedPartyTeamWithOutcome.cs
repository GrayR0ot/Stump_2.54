using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class NamedPartyTeamWithOutcome
    {
        public const short Id = 470;

        public NamedPartyTeamWithOutcome(NamedPartyTeam team, ushort outcome)
        {
            Team = team;
            Outcome = outcome;
        }

        public NamedPartyTeamWithOutcome()
        {
        }

        public virtual short TypeId => Id;

        public NamedPartyTeam Team { get; set; }
        public ushort Outcome { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            Team.Serialize(writer);
            writer.WriteVarUShort(Outcome);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            Team = new NamedPartyTeam();
            Team.Deserialize(reader);
            Outcome = reader.ReadVarUShort();
        }
    }
}