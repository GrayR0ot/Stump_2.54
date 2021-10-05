using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("PointOfInterest", "com.ankamagames.dofus.datacenter.quest.treasureHunt")]
    [Serializable]
    public class PointOfInterest : IDataObject, IIndexedData
    {
        public const string MODULE = "PointOfInterest";
        public uint categoryId;
        public uint id;

        [I18NField] public uint nameId;

        [D2OIgnore]
        public uint Id
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
        public uint CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        int IIndexedData.Id => (int) id;
    }
}