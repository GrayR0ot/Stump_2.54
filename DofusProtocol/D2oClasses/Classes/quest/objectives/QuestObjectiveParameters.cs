using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("QuestObjectiveParameters", "com.ankamagames.dofus.datacenter.quest.objectives")]
    [Serializable]
    public class QuestObjectiveParameters : IDataObject
    {
        public bool dungeonOnly;
        public uint numParams;
        public int parameter0;
        public int parameter1;
        public int parameter2;
        public int parameter3;
        public int parameter4;

        [D2OIgnore]
        public uint NumParams
        {
            get => numParams;
            set => numParams = value;
        }

        [D2OIgnore]
        public int Parameter0
        {
            get => parameter0;
            set => parameter0 = value;
        }

        [D2OIgnore]
        public int Parameter1
        {
            get => parameter1;
            set => parameter1 = value;
        }

        [D2OIgnore]
        public int Parameter2
        {
            get => parameter2;
            set => parameter2 = value;
        }

        [D2OIgnore]
        public int Parameter3
        {
            get => parameter3;
            set => parameter3 = value;
        }

        [D2OIgnore]
        public int Parameter4
        {
            get => parameter4;
            set => parameter4 = value;
        }

        [D2OIgnore]
        public bool DungeonOnly
        {
            get => dungeonOnly;
            set => dungeonOnly = value;
        }
    }
}