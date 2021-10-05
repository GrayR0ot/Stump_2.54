using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SpellState", "com.ankamagames.dofus.datacenter.spells")]
    [Serializable]
    public class SpellState : IDataObject, IIndexedData
    {
        public const string MODULE = "SpellStates";
        public bool cantBeMoved;
        public bool cantBePushed;
        public bool cantBeTackled;
        public bool cantDealDamage;
        public bool cantSwitchPosition;
        public bool cantTackle;
        public List<int> effectsIds;
        public string icon = "";
        public int iconVisibilityMask;
        public int id;
        public bool incurable;
        public bool invulnerable;
        public bool invulnerableMelee;
        public bool invulnerableRange;
        public bool isSilent;

        [I18NField] public uint nameId;

        public bool preventsFight;
        public bool preventsSpellCast;

        [D2OIgnore]
        public int Id
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

        [D2OIgnore]
        public bool PreventsSpellCast
        {
            get => preventsSpellCast;
            set => preventsSpellCast = value;
        }

        [D2OIgnore]
        public bool PreventsFight
        {
            get => preventsFight;
            set => preventsFight = value;
        }

        [D2OIgnore]
        public bool IsSilent
        {
            get => isSilent;
            set => isSilent = value;
        }

        [D2OIgnore]
        public bool CantDealDamage
        {
            get => cantDealDamage;
            set => cantDealDamage = value;
        }

        [D2OIgnore]
        public bool Invulnerable
        {
            get => invulnerable;
            set => invulnerable = value;
        }

        [D2OIgnore]
        public bool Incurable
        {
            get => incurable;
            set => incurable = value;
        }

        [D2OIgnore]
        public bool CantBeMoved
        {
            get => cantBeMoved;
            set => cantBeMoved = value;
        }

        [D2OIgnore]
        public bool CantBePushed
        {
            get => cantBePushed;
            set => cantBePushed = value;
        }

        [D2OIgnore]
        public bool CantSwitchPosition
        {
            get => cantSwitchPosition;
            set => cantSwitchPosition = value;
        }

        [D2OIgnore]
        public List<int> EffectsIds
        {
            get => effectsIds;
            set => effectsIds = value;
        }

        [D2OIgnore]
        public string Icon
        {
            get => icon;
            set => icon = value;
        }

        [D2OIgnore]
        public int IconVisibilityMask
        {
            get => iconVisibilityMask;
            set => iconVisibilityMask = value;
        }

        [D2OIgnore]
        public bool InvulnerableMelee
        {
            get => invulnerableMelee;
            set => invulnerableMelee = value;
        }

        [D2OIgnore]
        public bool InvulnerableRange
        {
            get => invulnerableRange;
            set => invulnerableRange = value;
        }

        [D2OIgnore]
        public bool CantTackle
        {
            get => cantTackle;
            set => cantTackle = value;
        }

        [D2OIgnore]
        public bool CantBeTackled
        {
            get => cantBeTackled;
            set => cantBeTackled = value;
        }

        int IIndexedData.Id => id;
    }
}