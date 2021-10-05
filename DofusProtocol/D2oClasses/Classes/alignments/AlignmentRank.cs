using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AlignmentRank", "com.ankamagames.dofus.datacenter.alignments")]
    [Serializable]
    public class AlignmentRank : IDataObject, IIndexedData
    {
        public const string MODULE = "AlignmentRank";

        [I18NField] public uint descriptionId;

        public List<int> gifts;
        public int id;
        public int minimumAlignment;

        [I18NField] public uint nameId;

        public int objectsStolen;
        public uint orderId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint OrderId
        {
            get => orderId;
            set => orderId = value;
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

        [D2OIgnore]
        public int MinimumAlignment
        {
            get => minimumAlignment;
            set => minimumAlignment = value;
        }

        [D2OIgnore]
        public int ObjectsStolen
        {
            get => objectsStolen;
            set => objectsStolen = value;
        }

        [D2OIgnore]
        public List<int> Gifts
        {
            get => gifts;
            set => gifts = value;
        }

        int IIndexedData.Id => id;
    }
}