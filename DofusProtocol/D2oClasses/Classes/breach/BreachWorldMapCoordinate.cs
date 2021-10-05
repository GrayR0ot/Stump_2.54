// Generated on 03/27/2020 19:46:04

using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("BreachWorldMapCoordinate", "com.ankamagames.dofus.datacenter.breach")]
    [Serializable]
    public class BreachWorldMapCoordinate : IDataObject, IIndexedData
    {
        public const string MODULE = "BreachWorldMapCoordinates";
        public int exploredMapIcon;
        public uint id;
        public int mapCoordinateX;
        public int mapCoordinateY;
        public uint mapStage;
        public int unexploredMapIcon;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint MapStage
        {
            get => mapStage;
            set => mapStage = value;
        }

        [D2OIgnore]
        public int MapCoordinateX
        {
            get => mapCoordinateX;
            set => mapCoordinateX = value;
        }

        [D2OIgnore]
        public int MapCoordinateY
        {
            get => mapCoordinateY;
            set => mapCoordinateY = value;
        }

        [D2OIgnore]
        public int UnexploredMapIcon
        {
            get => unexploredMapIcon;
            set => unexploredMapIcon = value;
        }

        [D2OIgnore]
        public int ExploredMapIcon
        {
            get => exploredMapIcon;
            set => exploredMapIcon = value;
        }

        int IIndexedData.Id => (int) id;
    }
}