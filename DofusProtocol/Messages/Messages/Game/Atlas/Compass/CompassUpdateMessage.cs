﻿using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CompassUpdateMessage : Message
    {
        public const uint Id = 5591;

        public CompassUpdateMessage(sbyte type, MapCoordinates coords)
        {
            Type = type;
            Coords = coords;
        }

        public CompassUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Type { get; set; }
        public MapCoordinates Coords { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
            writer.WriteShort(Coords.TypeId);
            Coords.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
            Coords = ProtocolTypeManager.GetInstance<MapCoordinates>(reader.ReadShort());
            Coords.Deserialize(reader);
        }
    }
}