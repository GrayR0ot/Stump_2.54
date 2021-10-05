using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("RankName", "com.ankamagames.dofus.datacenter.guild")]
    [Serializable]
    public class RankName : IDataObject, IIndexedData
    {
        public const string MODULE = "RankNames";
        public int id;

        [I18NField] public uint nameId;

        public int order;

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
        public int Order
        {
            get => order;
            set => order = value;
        }

        int IIndexedData.Id => id;
    }
}