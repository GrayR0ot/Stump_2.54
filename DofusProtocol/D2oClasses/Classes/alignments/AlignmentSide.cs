using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AlignmentSide", "com.ankamagames.dofus.datacenter.alignments")]
    [Serializable]
    public class AlignmentSide : IDataObject, IIndexedData
    {
        public const string MODULE = "AlignmentSides";
        public bool canConquest;
        public int id;

        [I18NField] public uint nameId;

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
        public bool CanConquest
        {
            get => canConquest;
            set => canConquest = value;
        }

        int IIndexedData.Id => id;
    }
}