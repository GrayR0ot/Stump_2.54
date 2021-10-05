using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Waypoint", "com.ankamagames.dofus.datacenter.world")]
    [Serializable]
    public class Waypoint : IDataObject, IIndexedData
    {
        public const string MODULE = "Waypoints";
        public bool activated;
        public uint id;
        public double mapId;
        public uint subAreaId;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public double MapId
        {
            get => mapId;
            set => mapId = value;
        }

        [D2OIgnore]
        public uint SubAreaId
        {
            get => subAreaId;
            set => subAreaId = value;
        }

        [D2OIgnore]
        public bool Activated
        {
            get => activated;
            set => activated = value;
        }

        int IIndexedData.Id => (int) id;
    }
}