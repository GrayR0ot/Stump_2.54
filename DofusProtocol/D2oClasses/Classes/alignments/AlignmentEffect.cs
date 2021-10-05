using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AlignmentEffect", "com.ankamagames.dofus.datacenter.alignments")]
    [Serializable]
    public class AlignmentEffect : IDataObject, IIndexedData
    {
        public const string MODULE = "AlignmentEffect";
        public uint characteristicId;

        [I18NField] public uint descriptionId;

        public int id;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint CharacteristicId
        {
            get => characteristicId;
            set => characteristicId = value;
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