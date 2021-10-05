using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SkillName", "com.ankamagames.dofus.datacenter.interactives")]
    [Serializable]
    public class SkillName : IDataObject, IIndexedData
    {
        public const string MODULE = "SkillNames";
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

        int IIndexedData.Id => id;
    }
}