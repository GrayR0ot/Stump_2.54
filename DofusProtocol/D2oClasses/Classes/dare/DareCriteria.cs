using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("DareCriteria", "com.ankamagames.dofus.datacenter.dare")]
    [Serializable]
    public class DareCriteria : IDataObject, IIndexedData
    {
        public const string MODULE = "DareCriterias";
        public uint id;
        public uint maxOccurence;
        public int maxParameterBound;
        public uint maxParameters;
        public int minParameterBound;

        [I18NField] public uint nameId;

        [D2OIgnore]
        public uint Id
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
        public uint MaxOccurence
        {
            get => maxOccurence;
            set => maxOccurence = value;
        }

        [D2OIgnore]
        public uint MaxParameters
        {
            get => maxParameters;
            set => maxParameters = value;
        }

        [D2OIgnore]
        public int MinParameterBound
        {
            get => minParameterBound;
            set => minParameterBound = value;
        }

        [D2OIgnore]
        public int MaxParameterBound
        {
            get => maxParameterBound;
            set => maxParameterBound = value;
        }

        int IIndexedData.Id => (int) id;
    }
}