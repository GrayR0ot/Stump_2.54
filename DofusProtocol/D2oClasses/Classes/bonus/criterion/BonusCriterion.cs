using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("BonusCriterion", "com.ankamagames.dofus.datacenter.bonus.criterion")]
    [Serializable]
    public class BonusCriterion : IDataObject, IIndexedData
    {
        public const string MODULE = "BonusesCriterions";
        public int id;
        public uint type;
        public int value;

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
        public int Value
        {
            get => value;
            set => this.value = value;
        }

        int IIndexedData.Id => id;
    }
}