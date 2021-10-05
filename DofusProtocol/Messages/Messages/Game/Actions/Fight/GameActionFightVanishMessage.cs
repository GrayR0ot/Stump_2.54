﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameActionFightVanishMessage : AbstractGameActionMessage
    {
        public new const uint Id = 6217;

        public GameActionFightVanishMessage(ushort actionId, double sourceId, double targetId)
        {
            ActionId = actionId;
            SourceId = sourceId;
            TargetId = targetId;
        }

        public GameActionFightVanishMessage()
        {
        }

        public override uint MessageId => Id;

        public double TargetId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
        }
    }
}