using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("IncarnationLevel", "com.ankamagames.dofus.datacenter.items")]
    [Serializable]
    public class IncarnationLevel : IDataObject, IIndexedData
    {
        public const string MODULE = "IncarnationLevels";
        public int id;
        public int incarnationId;
        public int level;
        public uint requiredXp;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int IncarnationId
        {
            get => incarnationId;
            set => incarnationId = value;
        }

        [D2OIgnore]
        public int Level
        {
            get => level;
            set => level = value;
        }

        [D2OIgnore]
        public uint RequiredXp
        {
            get => requiredXp;
            set => requiredXp = value;
        }

        int IIndexedData.Id => id;
    }
}