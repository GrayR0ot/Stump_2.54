﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameActionFightReduceDamagesMessage : AbstractGameActionMessage
    {
        public new const uint Id = 5526;

        public GameActionFightReduceDamagesMessage(ushort actionId, double sourceId, double targetId, uint amount)
        {
            ActionId = actionId;
            SourceId = sourceId;
            TargetId = targetId;
            Amount = amount;
        }

        public GameActionFightReduceDamagesMessage()
        {
        }

        public override uint MessageId => Id;

        public double TargetId { get; set; }
        public uint Amount { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarUInt(Amount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Amount = reader.ReadVarUInt();
        }
    }
}