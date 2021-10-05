using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ServerPopulation", "com.ankamagames.dofus.datacenter.servers")]
    [Serializable]
    public class ServerPopulation : IDataObject, IIndexedData
    {
        public const string MODULE = "ServerPopulations";
        public int id;

        [I18NField] public uint nameId;

        public int weight;

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
        public int Weight
        {
            get => weight;
            set => weight = value;
        }

        int IIndexedData.Id => id;
    }
}