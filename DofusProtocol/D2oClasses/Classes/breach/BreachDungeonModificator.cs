// Generated on 03/27/2020 19:46:04

using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("BreachDungeonModificator", "com.ankamagames.dofus.datacenter.breach")]
    [Serializable]
    public class BreachDungeonModificator : IDataObject, IIndexedData
    {
        public const string MODULE = "BreachDungeonModificators";
        public double additionalRewardPercent;
        public string criterion;
        public uint id;
        public bool isPositiveForPlayers;
        public uint modificatorId;
        public double score;
        public string tooltipBaseline;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint ModificatorId
        {
            get => modificatorId;
            set => modificatorId = value;
        }

        [D2OIgnore]
        public string Criterion
        {
            get => criterion;
            set => criterion = value;
        }

        [D2OIgnore]
        public double AdditionalRewardPercent
        {
            get => additionalRewardPercent;
            set => additionalRewardPercent = value;
        }

        [D2OIgnore]
        public double Score
        {
            get => score;
            set => score = value;
        }

        [D2OIgnore]
        public bool IsPositiveForPlayers
        {
            get => isPositiveForPlayers;
            set => isPositiveForPlayers = value;
        }

        [D2OIgnore]
        public string TooltipBaseline
        {
            get => tooltipBaseline;
            set => tooltipBaseline = value;
        }

        int IIndexedData.Id => (int) id;
    }
}