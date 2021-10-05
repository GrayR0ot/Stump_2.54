﻿using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class AtlasPointsInformations
    {
        public const short Id = 175;

        public AtlasPointsInformations(sbyte type, MapCoordinatesExtended[] coords)
        {
            Type = type;
            Coords = coords;
        }

        public AtlasPointsInformations()
        {
        }

        public virtual short TypeId => Id;

        public sbyte Type { get; set; }
        public MapCoordinatesExtended[] Coords { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
            writer.WriteShort((short) Coords.Count());
            for (var coordsIndex = 0; coordsIndex < Coords.Count(); coordsIndex++)
            {
                var objectToSend = Coords[coordsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public virtual void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
            var coordsCount = reader.ReadUShort();
            Coords = new MapCoordinatesExtended[coordsCount];
            for (var coordsIndex = 0; coordsIndex < coordsCount; coordsIndex++)
            {
                var objectToAdd = new MapCoordinatesExtended();
                objectToAdd.Deserialize(reader);
                Coords[coordsIndex] = objectToAdd;
            }
        }
    }
}