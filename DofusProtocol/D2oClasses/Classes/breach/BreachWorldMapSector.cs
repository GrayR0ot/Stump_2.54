// Generated on 03/27/2020 19:46:04

using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("BreachWorldMapSector", "com.ankamagames.dofus.datacenter.breach")]
    [Serializable]
    public class BreachWorldMapSector : IDataObject, IIndexedData
    {
        public const string MODULE = "BreachWorldMapSectors";
        public uint id;

        [I18NField] public uint legendId;

        public int maxStage;
        public int minStage;
        public string sectorIcon;

        [I18NField] public uint sectorNameId;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint SectorNameId
        {
            get => sectorNameId;
            set => sectorNameId = value;
        }

        [D2OIgnore]
        public uint LegendId
        {
            get => legendId;
            set => legendId = value;
        }

        [D2OIgnore]
        public string SectorIcon
        {
            get => sectorIcon;
            set => sectorIcon = value;
        }

        [D2OIgnore]
        public int MinStage
        {
            get => minStage;
            set => minStage = value;
        }

        [D2OIgnore]
        public int MaxStage
        {
            get => maxStage;
            set => maxStage = value;
        }

        int IIndexedData.Id => (int) id;
    }
}