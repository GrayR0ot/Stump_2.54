using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Job", "com.ankamagames.dofus.datacenter.jobs")]
    [Serializable]
    public class Job : IDataObject, IIndexedData
    {
        public const string MODULE = "Jobs";
        public int iconId;
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

        [D2OIgnore]
        public int IconId
        {
            get => iconId;
            set => iconId = value;
        }

        int IIndexedData.Id => id;
    }
}