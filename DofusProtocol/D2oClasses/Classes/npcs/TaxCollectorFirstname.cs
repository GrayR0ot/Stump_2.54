using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("TaxCollectorFirstname", "com.ankamagames.dofus.datacenter.npcs")]
    [Serializable]
    public class TaxCollectorFirstname : IDataObject, IIndexedData
    {
        public const string MODULE = "TaxCollectorFirstnames";

        [I18NField] public uint firstnameId;

        public int id;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint FirstnameId
        {
            get => firstnameId;
            set => firstnameId = value;
        }

        int IIndexedData.Id => id;
    }
}