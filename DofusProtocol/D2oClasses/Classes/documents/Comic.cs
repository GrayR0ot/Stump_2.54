using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Comic", "com.ankamagames.dofus.datacenter.documents")]
    [Serializable]
    public class Comic : IDataObject, IIndexedData
    {
        private const string MODULE = "Comics";
        public int id;
        public string remoteId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public string RemoteId
        {
            get => remoteId;
            set => remoteId = value;
        }

        int IIndexedData.Id => id;
    }
}