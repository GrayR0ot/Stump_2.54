using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("MapReference", "com.ankamagames.dofus.datacenter.world")]
    [Serializable]
    public class MapReference : IDataObject, IIndexedData
    {
        public const string MODULE = "MapReferences";
        public int cellId;
        public int id;
        public double mapId;

        [D2OIgnore]
        public int Id
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
        public int CellId
        {
            get => cellId;
            set => cellId = value;
        }

        int IIndexedData.Id => id;
    }
}