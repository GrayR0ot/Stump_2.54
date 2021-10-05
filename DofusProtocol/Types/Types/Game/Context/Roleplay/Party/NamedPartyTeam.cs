﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class NamedPartyTeam
    {
        public const short Id = 469;

        public NamedPartyTeam(sbyte teamId, string partyName)
        {
            TeamId = teamId;
            PartyName = partyName;
        }

        public NamedPartyTeam()
        {
        }

        public virtual short TypeId => Id;

        public sbyte TeamId { get; set; }
        public string PartyName { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(TeamId);
            writer.WriteUTF(PartyName);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            TeamId = reader.ReadSByte();
            PartyName = reader.ReadUTF();
        }
    }
}