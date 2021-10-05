using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("LegendaryTreasureHunt", "com.ankamagames.dofus.datacenter.quest.treasureHunt")]
    [Serializable]
    public class LegendaryTreasureHunt : IDataObject, IIndexedData
    {
        public const string MODULE = "LegendaryTreasureHunts";
        public uint chestId;
        public uint id;
        public uint level;
        public uint mapItemId;
        public uint monsterId;

        [I18NField] public uint nameId;

        public double xpRatio;

        [D2OIgnore]
        public uint Id
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
        public uint Level
        {
            get => level;
            set => level = value;
        }

        [D2OIgnore]
        public uint ChestId
        {
            get => chestId;
            set => chestId = value;
        }

        [D2OIgnore]
        public uint MonsterId
        {
            get => monsterId;
            set => monsterId = value;
        }

        [D2OIgnore]
        public uint MapItemId
        {
            get => mapItemId;
            set => mapItemId = value;
        }

        [D2OIgnore]
        public double XpRatio
        {
            get => xpRatio;
            set => xpRatio = value;
        }

        int IIndexedData.Id => (int) id;
    }
}