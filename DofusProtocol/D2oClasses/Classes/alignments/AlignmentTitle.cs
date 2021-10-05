using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AlignmentTitle", "com.ankamagames.dofus.datacenter.alignments")]
    [Serializable]
    public class AlignmentTitle : IDataObject, IIndexedData
    {
        public const string MODULE = "AlignmentTitles";
        public List<int> namesId;
        public List<int> shortsId;
        public int sideId;

        [D2OIgnore]
        public int SideId
        {
            get => sideId;
            set => sideId = value;
        }

        [D2OIgnore]
        public List<int> NamesId
        {
            get => namesId;
            set => namesId = value;
        }

        [D2OIgnore]
        public List<int> ShortsId
        {
            get => shortsId;
            set => shortsId = value;
        }

        int IIndexedData.Id => sideId;
    }
}