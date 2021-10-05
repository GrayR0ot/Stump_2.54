using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("EmblemBackground", "com.ankamagames.dofus.datacenter.guild")]
    [Serializable]
    public class EmblemBackground : IDataObject, IIndexedData
    {
        public const string MODULE = "EmblemBackgrounds";
        public int id;
        public int order;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
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