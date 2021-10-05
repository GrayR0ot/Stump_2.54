using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AbuseReasons", "com.ankamagames.dofus.datacenter.abuse")]
    [Serializable]
    public class AbuseReasons : IDataObject, IIndexedData
    {
        public const string MODULE = "AbuseReasons";
        public uint _abuseReasonId;
        public uint _mask;

        [I18NField] public int _reasonTextId;

        [D2OIgnore]
        public uint AbuseReasonId
        {
            get => _abuseReasonId;
            set => _abuseReasonId = value;
        }

        [D2OIgnore]
        public uint Mask
        {
            get => _mask;
            set => _mask = value;
        }

        [D2OIgnore]
        public int ReasonTextId
        {
            get => _reasonTextId;
            set => _reasonTextId = value;
        }

        int IIndexedData.Id => (int) _abuseReasonId;
    }
}