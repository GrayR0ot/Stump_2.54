using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SpellType", "com.ankamagames.dofus.datacenter.spells")]
    [Serializable]
    public class SpellType : IDataObject, IIndexedData
    {
        public const string MODULE = "SpellTypes";
        public int id;

        [I18NField] public uint longNameId;

        [I18NField] public uint shortNameId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint LongNameId
        {
            get => longNameId;
            set => longNameId = value;
        }

        [D2OIgnore]
        public uint ShortNameId
        {
            get => shortNameId;
            set => shortNameId = value;
        }

        int IIndexedData.Id => id;
    }
}