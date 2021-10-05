using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ItemCriterionOperator", "com.ankamagames.dofus.datacenter.items.criterion")]
    [Serializable]
    public class ItemCriterionOperator : IDataObject
    {
        public const string SUPERIOR = ">";
        public const string INFERIOR = "<";
        public const string EQUAL = "";
        public const string DIFFERENT = "!";
    }
}