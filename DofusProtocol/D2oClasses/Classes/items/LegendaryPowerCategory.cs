using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("LegendaryPowerCategory", "com.ankamagames.dofus.datacenter.items")]
    [Serializable]
    public class LegendaryPowerCategory : IDataObject, IIndexedData
    {
        public const string MODULE = "LegendaryPowersCategories";
        public string categoryName;
        public bool categoryOverridable;
        public List<int> categorySpells;
        public int id;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public string CategoryName
        {
            get => categoryName;
            set => categoryName = value;
        }

        [D2OIgnore]
        public bool CategoryOverridable
        {
            get => categoryOverridable;
            set => categoryOverridable = value;
        }

        [D2OIgnore]
        public List<int> CategorySpells
        {
            get => categorySpells;
            set => categorySpells = value;
        }

        int IIndexedData.Id => id;
    }
}