using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SmileyCategory", "com.ankamagames.dofus.datacenter.communication")]
    [Serializable]
    public class SmileyCategory : IDataObject, IIndexedData
    {
        public const string MODULE = "SmileyCategories";
        public string gfxId;
        public int id;
        public bool isFake;
        public uint order;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint Order
        {
            get => order;
            set => order = value;
        }

        [D2OIgnore]
        public string GfxId
        {
            get => gfxId;
            set => gfxId = value;
        }

        [D2OIgnore]
        public bool IsFake
        {
            get => isFake;
            set => isFake = value;
        }

        int IIndexedData.Id => id;
    }
}