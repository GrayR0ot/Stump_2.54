﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayPlayerFightFriendlyAnswerMessage : Message
    {
        public const uint Id = 5732;

        public GameRolePlayPlayerFightFriendlyAnswerMessage(ushort fightId, bool accept)
        {
            FightId = fightId;
            Accept = accept;
        }

        public GameRolePlayPlayerFightFriendlyAnswerMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort FightId { get; set; }
        public bool Accept { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(FightId);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUShort();
            Accept = reader.ReadBoolean();
        }
    }
}