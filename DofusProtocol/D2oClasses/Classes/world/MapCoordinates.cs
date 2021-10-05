using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("MapCoordinates", "com.ankamagames.dofus.datacenter.world")]
    [Serializable]
    public class MapCoordinates : IDataObject
    {
        public const string MODULE = "MapCoordinates";
        public uint compressedCoords;
        public List<double> mapIds;

        [D2OIgnore]
        public uint CompressedCoords
        {
            get => compressedCoords;
            set => compressedCoords = value;
        }

        [D2OIgnore]
        public List<double> MapIds
        {
            get => mapIds;
            set => mapIds = value;
        }
    }
}