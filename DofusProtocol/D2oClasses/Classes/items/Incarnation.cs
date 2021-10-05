using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Incarnation", "com.ankamagames.dofus.datacenter.items")]
    [Serializable]
    public class Incarnation : IDataObject, IIndexedData
    {
        public const string MODULE = "Incarnation";
        public uint id;
        public string lookFemale;
        public string lookMale;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public string LookMale
        {
            get => lookMale;
            set => lookMale = value;
        }

        [D2OIgnore]
        public string LookFemale
        {
            get => lookFemale;
            set => lookFemale = value;
        }

        int IIndexedData.Id => (int) id;
    }
}