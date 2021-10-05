using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AchievementObjective", "com.ankamagames.dofus.datacenter.quest")]
    [Serializable]
    public class AchievementObjective : IDataObject, IIndexedData
    {
        public const string MODULE = "AchievementObjectives";
        public uint achievementId;
        public string criterion;
        public uint id;

        [I18NField] public uint nameId;

        public uint order;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint AchievementId
        {
            get => achievementId;
            set => achievementId = value;
        }

        [D2OIgnore]
        public uint Order
        {
            get => order;
            set => order = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public string Criterion
        {
            get => criterion;
            set => criterion = value;
        }

        int IIndexedData.Id => (int) id;
    }
}