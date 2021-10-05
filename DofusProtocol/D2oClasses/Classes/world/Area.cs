using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Area", "com.ankamagames.dofus.datacenter.world")]
    [Serializable]
    public class Area : IDataObject, IIndexedData
    {
        public const string MODULE = "Areas";
        public Rectangle bounds;
        public bool containHouses;
        public bool containPaddocks;
        public bool hasWorldMap;
        public int id;

        [I18NField] public uint nameId;

        public int superAreaId;
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
        public int SuperAreaId
        {
            get => superAreaId;
            set => superAreaId = value;
        }

        [D2OIgnore]
        public bool ContainHouses
        {
            get => containHouses;
            set => containHouses = value;
        }

        [D2OIgnore]
        public bool ContainPaddocks
        {
            get => containPaddocks;
            set => containPaddocks = value;
        }

        [D2OIgnore]
        public Rectangle Bounds
        {
            get => bounds;
            set => bounds = value;
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