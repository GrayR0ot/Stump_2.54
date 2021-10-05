using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("NamingRule", "com.ankamagames.dofus.datacenter.communication")]
    [Serializable]
    public class NamingRule : IDataObject, IIndexedData
    {
        public const string MODULE = "NamingRules";
        public uint id;
        public uint maxLength;
        public uint minLength;
        public string regexp;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint MinLength
        {
            get => minLength;
            set => minLength = value;
        }

        [D2OIgnore]
        public uint MaxLength
        {
            get => maxLength;
            set => maxLength = value;
        }

        [D2OIgnore]
        public string Regexp
        {
            get => regexp;
            set => regexp = value;
        }

        int IIndexedData.Id => (int) id;
    }
}