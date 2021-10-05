using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Url", "com.ankamagames.dofus.datacenter.misc")]
    [Serializable]
    public class Url : IDataObject, IIndexedData
    {
        public const string MODULE = "Url";
        public int browserId;
        public int id;
        public string method;
        public string param;
        public string url;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int BrowserId
        {
            get => browserId;
            set => browserId = value;
        }

        [D2OIgnore]
        public string Url_
        {
            get => url;
            set => url = value;
        }

        [D2OIgnore]
        public string Param
        {
            get => param;
            set => param = value;
        }

        [D2OIgnore]
        public string Method
        {
            get => method;
            set => method = value;
        }

        int IIndexedData.Id => id;
    }
}