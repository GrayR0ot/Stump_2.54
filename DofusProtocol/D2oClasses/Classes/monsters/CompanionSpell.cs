using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("CompanionSpell", "com.ankamagames.dofus.datacenter.monsters")]
    [Serializable]
    public class CompanionSpell : IDataObject, IIndexedData
    {
        public const string MODULE = "CompanionSpells";
        public int companionId;
        public string gradeByLevel;
        public int id;
        public int spellId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int SpellId
        {
            get => spellId;
            set => spellId = value;
        }

        [D2OIgnore]
        public int CompanionId
        {
            get => companionId;
            set => companionId = value;
        }

        [D2OIgnore]
        public string GradeByLevel
        {
            get => gradeByLevel;
            set => gradeByLevel = value;
        }

        int IIndexedData.Id => id;
    }
}