﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildFightPlayersEnemyRemoveMessage : Message
    {
        public const uint Id = 5929;

        public GuildFightPlayersEnemyRemoveMessage(double fightId, ulong playerId)
        {
            FightId = fightId;
            PlayerId = playerId;
        }

        public GuildFightPlayersEnemyRemoveMessage()
        {
        }

        public override uint MessageId => Id;

        public double FightId { get; set; }
        public ulong PlayerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(FightId);
            writer.WriteVarULong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadDouble();
            PlayerId = reader.ReadVarULong();
        }
    }
}