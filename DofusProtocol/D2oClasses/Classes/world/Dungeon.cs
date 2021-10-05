using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Dungeon", "com.ankamagames.dofus.datacenter.world")]
    [Serializable]
    public class Dungeon : IDataObject, IIndexedData
    {
        public const string MODULE = "Dungeons";
        public double entranceMapId;
        public double exitMapId;
        public int id;
        public List<double> mapIds;

        [I18NField] public uint nameId;

        public int optimalPlayerLevel;

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
        public int OptimalPlayerLevel
        {
            get => optimalPlayerLevel;
            set => optimalPlayerLevel = value;
        }

        [D2OIgnore]
        public List<double> MapIds
        {
            get => mapIds;
            set => mapIds = value;
        }

        [D2OIgnore]
        public double EntranceMapId
        {
            get => entranceMapId;
            set => entranceMapId = value;
        }

        [D2OIgnore]
        public double ExitMapId
        {
            get => exitMapId;
            set => exitMapId = value;
        }

        int IIndexedData.Id => id;
    }
}