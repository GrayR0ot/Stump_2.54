using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Effect", "com.ankamagames.dofus.datacenter.effects")]
    [Serializable]
    public class Effect : IDataObject, IIndexedData
    {
        public const string MODULE = "Effects";
        public bool active;
        public int bonusType;
        public bool boost;
        public uint category;
        public int characteristic;

        [I18NField] public uint descriptionId;

        public uint effectPriority;
        public int elementId;
        public bool forceMinMax;
        public int iconId;
        public int id;
        public string @operator;
        public int oppositeId;
        public bool showInSet;
        public bool showInTooltip;

        [I18NField] public uint theoreticalDescriptionId;

        public uint theoreticalPattern;
        public bool useDice;
        public bool useInFight;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        [D2OIgnore]
        public int IconId
        {
            get => iconId;
            set => iconId = value;
        }

        [D2OIgnore]
        public int Characteristic
        {
            get => characteristic;
            set => characteristic = value;
        }

        [D2OIgnore]
        public uint Category
        {
            get => category;
            set => category = value;
        }

        [D2OIgnore]
        public string Operator
        {
            get => @operator;
            set => @operator = value;
        }

        [D2OIgnore]
        public bool ShowInTooltip
        {
            get => showInTooltip;
            set => showInTooltip = value;
        }

        [D2OIgnore]
        public bool UseDice
        {
            get => useDice;
            set => useDice = value;
        }

        [D2OIgnore]
        public bool ForceMinMax
        {
            get => forceMinMax;
            set => forceMinMax = value;
        }

        [D2OIgnore]
        public bool Boost
        {
            get => boost;
            set => boost = value;
        }

        [D2OIgnore]
        public bool Active
        {
            get => active;
            set => active = value;
        }

        [D2OIgnore]
        public int OppositeId
        {
            get => oppositeId;
            set => oppositeId = value;
        }

        [D2OIgnore]
        public uint TheoreticalDescriptionId
        {
            get => theoreticalDescriptionId;
            set => theoreticalDescriptionId = value;
        }

        [D2OIgnore]
        public uint TheoreticalPattern
        {
            get => theoreticalPattern;
            set => theoreticalPattern = value;
        }

        [D2OIgnore]
        public bool ShowInSet
        {
            get => showInSet;
            set => showInSet = value;
        }

        [D2OIgnore]
        public int BonusType
        {
            get => bonusType;
            set => bonusType = value;
        }

        [D2OIgnore]
        public bool UseInFight
        {
            get => useInFight;
            set => useInFight = value;
        }

        [D2OIgnore]
        public uint EffectPriority
        {
            get => effectPriority;
            set => effectPriority = value;
        }

        [D2OIgnore]
        public int ElementId
        {
            get => elementId;
            set => elementId = value;
        }

        int IIndexedData.Id => id;
    }
}