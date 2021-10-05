using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("CompanionCharacteristic", "com.ankamagames.dofus.datacenter.monsters")]
    [Serializable]
    public class CompanionCharacteristic : IDataObject, IIndexedData
    {
        public const string MODULE = "CompanionCharacteristics";
        public int caracId;
        public int companionId;
        public int id;
        public int order;
        public List<List<double>> statPerLevelRange;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int CaracId
        {
            get => caracId;
            set => caracId = value;
        }

        [D2OIgnore]
        public int CompanionId
        {
            get => companionId;
            set => companionId = value;
        }

        [D2OIgnore]
        public int Order
        {
            get => order;
            set => order = value;
        }

        [D2OIgnore]
        public List<List<double>> StatPerLevelRange
        {
            get => statPerLevelRange;
            set => statPerLevelRange = value;
        }

        int IIndexedData.Id => id;
    }
}