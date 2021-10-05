using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SuperArea", "com.ankamagames.dofus.datacenter.world")]
    [Serializable]
    public class SuperArea : IDataObject, IIndexedData
    {
        public const string MODULE = "SuperAreas";
        public bool hasWorldMap;
        public int id;

        [I18NField] public uint nameId;

        public uint worldmapId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public uint WorldmapId
        {
            get => worldmapId;
            set => worldmapId = value;
        }

        [D2OIgnore]
        public bool HasWorldMap
        {
            get => hasWorldMap;
            set => hasWorldMap = value;
        }

        int IIndexedData.Id => id;
    }
}