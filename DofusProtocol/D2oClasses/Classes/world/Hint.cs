using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Hint", "com.ankamagames.dofus.datacenter.world")]
    [Serializable]
    public class Hint : IDataObject, IIndexedData
    {
        public const string MODULE = "Hints";
        public uint gfx;
        public int id;
        public uint level;
        public double mapId;

        [I18NField] public uint nameId;

        public bool outdoor;
        public double realMapId;
        public int subareaId;
        public int worldMapId;

        [I18NField] public int x;

        public int y;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint Gfx
        {
            get => gfx;
            set => gfx = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public double MapId
        {
            get => mapId;
            set => mapId = value;
        }

        [D2OIgnore]
        public double RealMapId
        {
            get => realMapId;
            set => realMapId = value;
        }

        [D2OIgnore]
        public int X
        {
            get => x;
            set => x = value;
        }

        [D2OIgnore]
        public int Y
        {
            get => y;
            set => y = value;
        }

        [D2OIgnore]
        public bool Outdoor
        {
            get => outdoor;
            set => outdoor = value;
        }

        [D2OIgnore]
        public int SubareaId
        {
            get => subareaId;
            set => subareaId = value;
        }

        [D2OIgnore]
        public int WorldMapId
        {
            get => worldMapId;
            set => worldMapId = value;
        }

        [D2OIgnore]
        public uint Level
        {
            get => level;
            set => level = value;
        }

        int IIndexedData.Id => id;
    }
}