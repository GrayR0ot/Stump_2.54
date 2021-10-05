using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("NpcAction", "com.ankamagames.dofus.datacenter.npcs")]
    [Serializable]
    public class NpcAction : IDataObject, IIndexedData
    {
        public const string MODULE = "NpcActions";
        public int id;

        [I18NField] public uint nameId;

        public int realId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int RealId
        {
            get => realId;
            set => realId = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        int IIndexedData.Id => id;
    }
}