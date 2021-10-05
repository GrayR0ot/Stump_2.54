using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Sign", "com.ankamagames.dofus.datacenter.interactives")]
    [Serializable]
    public class Sign : IDataObject, IIndexedData
    {
        public const string MODULE = "Signs";
        public int id;
        public string @params;
        public int skillId;

        [I18NField] public uint textKey;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public string Params
        {
            get => @params;
            set => @params = value;
        }

        [D2OIgnore]
        public int SkillId
        {
            get => skillId;
            set => skillId = value;
        }

        [D2OIgnore]
        public uint TextKey
        {
            get => textKey;
            set => textKey = value;
        }

        int IIndexedData.Id => id;
    }
}