using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("QuestObjective", "com.ankamagames.dofus.datacenter.quest")]
    [Serializable]
    public class QuestObjective : IDataObject, IIndexedData
    {
        public const string MODULE = "QuestObjectives";
        public Point coords;
        public int dialogId;
        public uint id;
        public double mapId;
        public QuestObjectiveParameters parameters;
        public uint stepId;
        public uint typeId;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint StepId
        {
            get => stepId;
            set => stepId = value;
        }

        [D2OIgnore]
        public uint TypeId
        {
            get => typeId;
            set => typeId = value;
        }

        [D2OIgnore]
        public int DialogId
        {
            get => dialogId;
            set => dialogId = value;
        }

        [D2OIgnore]
        public QuestObjectiveParameters Parameters
        {
            get => parameters;
            set => parameters = value;
        }

        [D2OIgnore]
        public Point Coords
        {
            get => coords;
            set => coords = value;
        }

        [D2OIgnore]
        public double MapId
        {
            get => mapId;
            set => mapId = value;
        }

        int IIndexedData.Id => (int) id;
    }
}