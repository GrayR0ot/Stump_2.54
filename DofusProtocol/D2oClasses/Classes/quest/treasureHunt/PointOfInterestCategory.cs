using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("PointOfInterestCategory", "com.ankamagames.dofus.datacenter.quest.treasureHunt")]
    [Serializable]
    public class PointOfInterestCategory : IDataObject, IIndexedData
    {
        public const string MODULE = "PointOfInterestCategory";

        [I18NField] public uint actionLabelId;

        public uint id;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint ActionLabelId
        {
            get => actionLabelId;
            set => actionLabelId = value;
        }

        int IIndexedData.Id => (int) id;
    }
}