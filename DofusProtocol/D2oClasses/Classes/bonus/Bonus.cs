using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Bonus", "com.ankamagames.dofus.datacenter.bonus")]
    [Serializable]
    public class Bonus : IDataObject, IIndexedData
    {
        public const string MODULE = "Bonuses";
        public int amount;
        public List<int> criterionsIds;
        public int id;
        public uint type;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint Type
        {
            get => type;
            set => type = value;
        }

        [D2OIgnore]
        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        [D2OIgnore]
        public List<int> CriterionsIds
        {
            get => criterionsIds;
            set => criterionsIds = value;
        }

        int IIndexedData.Id => id;
    }
}