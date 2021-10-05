using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("EffectInstance", "com.ankamagames.dofus.datacenter.effects")]
    [Serializable]
    public class EffectInstance : IDataObject, IIndexedData
    {
        public const int IS_DISPELLABLE = 1;
        public const int IS_DISPELLABLE_ONLY_BY_DEATH = 2;
        public const int IS_NOT_DISPELLABLE = 3;
        public int delay;
        public int dispellable = 1;
        public int duration;
        public int effectElement;
        public uint effectId;
        public uint effectUid;
        public bool forClientOnly;
        public int group;
        public int modificator;
        public int order;
        public int random;
        public string rawZone;
        public int spellId;
        public int targetId;
        public string targetMask;
        public bool trigger;
        public string triggers;
        public bool visibleInBuffUi = true;
        public bool visibleInFightLog = true;
        public bool visibleInTooltip = true;
        public object zoneEfficiencyPercent;
        public object zoneMaxEfficiency;
        public object zoneMinSize;
        public uint zoneShape;
        public object zoneSize;
        public object zoneStopAtTarget;

        [D2OIgnore]
        public uint EffectUid
        {
            get => effectUid;
            set => effectUid = value;
        }

        [D2OIgnore]
        public uint EffectId
        {
            get => effectId;
            set => effectId = value;
        }

        [D2OIgnore]
        public int Order
        {
            get => order;
            set => order = value;
        }

        [D2OIgnore]
        public int TargetId
        {
            get => targetId;
            set => targetId = value;
        }

        [D2OIgnore]
        public string TargetMask
        {
            get => targetMask;
            set => targetMask = value;
        }

        [D2OIgnore]
        public int Duration
        {
            get => duration;
            set => duration = value;
        }

        [D2OIgnore]
        public int Delay
        {
            get => delay;
            set => delay = value;
        }

        [D2OIgnore]
        public int Random
        {
            get => random;
            set => random = value;
        }

        [D2OIgnore]
        public int Group
        {
            get => group;
            set => group = value;
        }

        [D2OIgnore]
        public int Modificator
        {
            get => modificator;
            set => modificator = value;
        }

        [D2OIgnore]
        public bool Trigger
        {
            get => trigger;
            set => trigger = value;
        }

        [D2OIgnore]
        public string Triggers
        {
            get => triggers;
            set => triggers = value;
        }

        [D2OIgnore]
        public bool VisibleInTooltip
        {
            get => visibleInTooltip;
            set => visibleInTooltip = value;
        }

        [D2OIgnore]
        public bool VisibleInBuffUi
        {
            get => visibleInBuffUi;
            set => visibleInBuffUi = value;
        }

        [D2OIgnore]
        public bool VisibleInFightLog
        {
            get => visibleInFightLog;
            set => visibleInFightLog = value;
        }

        [D2OIgnore]
        public bool ForClientOnly
        {
            get => forClientOnly;
            set => forClientOnly = value;
        }

        [D2OIgnore]
        public int Dispellable
        {
            get => dispellable;
            set => dispellable = value;
        }

        [D2OIgnore]
        public object ZoneSize
        {
            get => zoneSize;
            set => zoneSize = value;
        }

        [D2OIgnore]
        public uint ZoneShape
        {
            get => zoneShape;
            set => zoneShape = value;
        }

        [D2OIgnore]
        public object ZoneMinSize
        {
            get => zoneMinSize;
            set => zoneMinSize = value;
        }

        [D2OIgnore]
        public object ZoneEfficiencyPercent
        {
            get => zoneEfficiencyPercent;
            set => zoneEfficiencyPercent = value;
        }

        [D2OIgnore]
        public object ZoneMaxEfficiency
        {
            get => zoneMaxEfficiency;
            set => zoneMaxEfficiency = value;
        }

        [D2OIgnore]
        public object ZoneStopAtTarget
        {
            get => zoneStopAtTarget;
            set => zoneStopAtTarget = value;
        }

        [D2OIgnore]
        public int EffectElement
        {
            get => effectElement;
            set => effectElement = value;
        }

        [D2OIgnore]
        public int SpellId
        {
            get => spellId;
            set => spellId = value;
        }

        [D2OIgnore]
        public string RawZone
        {
            get => rawZone;
            set => rawZone = value;
        }

        int IIndexedData.Id => (int) effectUid;
    }
}