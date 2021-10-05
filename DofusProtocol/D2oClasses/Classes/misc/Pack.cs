using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Pack", "com.ankamagames.dofus.datacenter.misc")]
    [Serializable]
    public class Pack : IDataObject, IIndexedData
    {
        public const string MODULE = "Pack";
        public bool hasSubAreas;
        public int id;
        public string name;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public string Name
        {
            get => name;
            set => name = value;
        }

        [D2OIgnore]
        public bool HasSubAreas
        {
            get => hasSubAreas;
            set => hasSubAreas = value;
        }

        int IIndexedData.Id => id;
    }
}