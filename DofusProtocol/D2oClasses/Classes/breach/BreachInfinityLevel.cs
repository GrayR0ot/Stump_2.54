// Generated on 03/27/2020 19:46:04

using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("BreachInfinityLevel", "com.ankamagames.dofus.datacenter.breach")]
    [Serializable]
    public class BreachInfinityLevel : IDataObject, IIndexedData
    {
        public const string MODULE = "BreachInfinityLevels";
        public uint id;
        public uint level;

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
        public uint Level
        {
            get => level;
            set => level = value;
        }

        int IIndexedData.Id => (int) id;
    }
}