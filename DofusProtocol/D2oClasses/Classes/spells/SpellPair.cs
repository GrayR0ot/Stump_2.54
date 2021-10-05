using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SpellPair", "com.ankamagames.dofus.datacenter.spells")]
    [Serializable]
    public class SpellPair : IDataObject, IIndexedData
    {
        public const string MODULE = "SpellPairs";

        [I18NField] public uint descriptionId;

        public int iconId;
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
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        [D2OIgnore]
        public int IconId
        {
            get => iconId;
            set => iconId = value;
        }

        int IIndexedData.Id => id;
    }
}