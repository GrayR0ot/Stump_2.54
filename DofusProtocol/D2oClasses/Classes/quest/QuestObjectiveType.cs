using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("QuestObjectiveType", "com.ankamagames.dofus.datacenter.quest")]
    [Serializable]
    public class QuestObjectiveType : IDataObject, IIndexedData
    {
        public const string MODULE = "QuestObjectiveTypes";
        public uint id;

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

        int IIndexedData.Id => (int) id;
    }
}