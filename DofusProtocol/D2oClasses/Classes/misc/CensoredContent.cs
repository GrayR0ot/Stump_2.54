using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("CensoredContent", "com.ankamagames.dofus.datacenter.misc")]
    [Serializable]
    public class CensoredContent : IDataObject
    {
        public const string MODULE = "CensoredContents";
        public string lang;
        public int newValue;
        public int oldValue;
        public int type;

        [D2OIgnore]
        public int Type
        {
            get => type;
            set => type = value;
        }

        [D2OIgnore]
        public int OldValue
        {
            get => oldValue;
            set => oldValue = value;
        }

        [D2OIgnore]
        public int NewValue
        {
            get => newValue;
            set => newValue = value;
        }

        [D2OIgnore]
        public string Lang
        {
            get => lang;
            set => lang = value;
        }
    }
}