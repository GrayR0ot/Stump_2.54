﻿using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachGameFightEndMessage : GameFightEndMessage
    {
        public new const uint Id = 6809;

        public BreachGameFightEndMessage(int duration, short rewardRate, short lootShareLimitMalus,
            FightResultListEntry[] results, NamedPartyTeamWithOutcome[] namedPartyTeamsOutcomes, int budget)
        {
            Duration = duration;
            RewardRate = rewardRate;
            LootShareLimitMalus = lootShareLimitMalus;
            Results = results;
            NamedPartyTeamsOutcomes = namedPartyTeamsOutcomes;
            Budget = budget;
        }

        public BreachGameFightEndMessage()
        {
        }

        public override uint MessageId => Id;

        public int Budget { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Budget);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Budget = reader.ReadInt();
        }
    }
}