using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ServerLang", "com.ankamagames.dofus.datacenter.servers")]
    [Serializable]
    public class ServerLang : IDataObject, IIndexedData
    {
        public const string MODULE = "ServerLangs";
        public int id;
        public string langCode;

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
        public string LangCode
        {
            get => langCode;
            set => langCode = value;
        }

        int IIndexedData.Id => id;
    }
}