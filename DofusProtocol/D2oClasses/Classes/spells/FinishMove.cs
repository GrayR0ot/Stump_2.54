using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("FinishMove", "com.ankamagames.dofus.datacenter.spells")]
    [Serializable]
    public class FinishMove : IDataObject, IIndexedData
    {
        public const string MODULE = "FinishMoves";
        public int category;
        public int duration;
        public bool free;
        public int id;

        [I18NField] public uint nameId;

        public int spellLevel;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int Duration
        {
            get => duration;
            set => duration = value;
        }

        [D2OIgnore]
        public bool Free
        {
            get => free;
            set => free = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public int Category
        {
            get => category;
            set => category = value;
        }

        [D2OIgnore]
        public int SpellLevel
        {
            get => spellLevel;
            set => spellLevel = value;
        }

        int IIndexedData.Id => id;
    }
}