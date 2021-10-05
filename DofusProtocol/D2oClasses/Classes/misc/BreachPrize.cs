// Generated on 03/27/2020 01:22:45

using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses.Classes.misc
{
    [D2OClass("BreachPrize", "com.ankamagames.dofus.datacenter.misc")]
    [Serializable]
    public class BreachPrize : IDataObject, IIndexedData
    {
        public const string MODULE = "BreachPrizes";
        public int categoryId;
        public int currency;

        [I18NField] public uint descriptionKey;

        public int id;
        public int itemId;

        [I18NField] public uint nameId;

        public string tooltipKey;

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
        public int Currency
        {
            get => currency;
            set => currency = value;
        }

        [D2OIgnore]
        public string TooltipKey
        {
            get => tooltipKey;
            set => tooltipKey = value;
        }

        [D2OIgnore]
        public uint DescriptionKey
        {
            get => descriptionKey;
            set => descriptionKey = value;
        }

        [D2OIgnore]
        public int CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        [D2OIgnore]
        public int ItemId
        {
            get => itemId;
            set => itemId = value;
        }

        int IIndexedData.Id => id;
    }
}