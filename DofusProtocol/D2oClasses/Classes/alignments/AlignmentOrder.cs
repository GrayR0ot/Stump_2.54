using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AlignmentOrder", "com.ankamagames.dofus.datacenter.alignments")]
    [Serializable]
    public class AlignmentOrder : IDataObject, IIndexedData
    {
        public const string MODULE = "AlignmentOrder";
        public int id;

        [I18NField] public uint nameId;

        public uint sideId;

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
        public uint SideId
        {
            get => sideId;
            set => sideId = value;
        }

        int IIndexedData.Id => id;
    }
}