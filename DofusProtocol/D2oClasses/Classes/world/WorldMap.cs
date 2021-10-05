using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("WorldMap", "com.ankamagames.dofus.datacenter.world")]
    [Serializable]
    public class WorldMap : IDataObject, IIndexedData
    {
        public const string MODULE = "WorldMaps";
        public int id;
        public double mapHeight;
        public double mapWidth;
        public double maxScale;
        public double minScale;

        [I18NField] public uint nameId;

        public int origineX;
        public int origineY;
        public double startScale;
        public int totalHeight;
        public int totalWidth;
        public bool viewableEverywhere;
        public List<string> zoom;

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
        public int OrigineX
        {
            get => origineX;
            set => origineX = value;
        }

        [D2OIgnore]
        public int OrigineY
        {
            get => origineY;
            set => origineY = value;
        }

        [D2OIgnore]
        public double MapWidth
        {
            get => mapWidth;
            set => mapWidth = value;
        }

        [D2OIgnore]
        public double MapHeight
        {
            get => mapHeight;
            set => mapHeight = value;
        }

        [D2OIgnore]
        public bool ViewableEverywhere
        {
            get => viewableEverywhere;
            set => viewableEverywhere = value;
        }

        [D2OIgnore]
        public double MinScale
        {
            get => minScale;
            set => minScale = value;
        }

        [D2OIgnore]
        public double MaxScale
        {
            get => maxScale;
            set => maxScale = value;
        }

        [D2OIgnore]
        public double StartScale
        {
            get => startScale;
            set => startScale = value;
        }

        [D2OIgnore]
        public int TotalWidth
        {
            get => totalWidth;
            set => totalWidth = value;
        }

        [D2OIgnore]
        public int TotalHeight
        {
            get => totalHeight;
            set => totalHeight = value;
        }

        [D2OIgnore]
        public List<string> Zoom
        {
            get => zoom;
            set => zoom = value;
        }

        int IIndexedData.Id => id;
    }
}