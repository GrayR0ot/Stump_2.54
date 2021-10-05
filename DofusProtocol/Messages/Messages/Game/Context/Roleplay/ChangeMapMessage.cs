﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ChangeMapMessage : Message
    {
        public const uint Id = 221;

        public ChangeMapMessage(double mapId, bool autopilot)
        {
            MapId = mapId;
            Autopilot = autopilot;
        }

        public ChangeMapMessage()
        {
        }

        public override uint MessageId => Id;

        public double MapId { get; set; }
        public bool Autopilot { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MapId);
            writer.WriteBoolean(Autopilot);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadDouble();
            Autopilot = reader.ReadBoolean();
        }
    }
}