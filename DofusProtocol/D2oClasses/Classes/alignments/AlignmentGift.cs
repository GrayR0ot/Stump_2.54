using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AlignmentGift", "com.ankamagames.dofus.datacenter.alignments")]
    [Serializable]
    public class AlignmentGift : IDataObject, IIndexedData
    {
        public const string MODULE = "AlignmentGift";
        public int effectId;
        public uint gfxId;
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
        public int EffectId
        {
            get => effectId;
            set => effectId = value;
        }

        [D2OIgnore]
        public uint GfxId
        {
            get => gfxId;
            set => gfxId = value;
        }

        int IIndexedData.Id => id;
    }
}