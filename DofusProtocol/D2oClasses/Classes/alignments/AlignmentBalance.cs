using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AlignmentBalance", "com.ankamagames.dofus.datacenter.alignments")]
    [Serializable]
    public class AlignmentBalance : IDataObject, IIndexedData
    {
        public const string MODULE = "AlignmentBalance";

        [I18NField] public uint descriptionId;

        public int endValue;
        public int id;

        [I18NField] public uint nameId;

        public int startValue;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int StartValue
        {
            get => startValue;
            set => startValue = value;
        }

        [D2OIgnore]
        public int EndValue
        {
            get => endValue;
            set => endValue = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        int IIndexedData.Id => id;
    }
}