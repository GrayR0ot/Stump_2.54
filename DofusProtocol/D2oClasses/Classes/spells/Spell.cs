using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Spell", "com.ankamagames.dofus.datacenter.spells")]
    [Serializable]
    public class Spell : IDataObject, IIndexedData
    {
        public const string MODULE = "Spells";
        public bool bypassSummoningLimit;
        public bool canAlwaysTriggerSpells;
        public string default_zone;
        public uint descriptionId;
        public int iconId;
        public int id;
        public uint nameId;
        public uint order;
        public int scriptId;
        public int scriptIdCritical;
        public string scriptParams;
        public string scriptParamsCritical;
        public List<uint> spellLevels;
        public uint typeId;
        public bool useParamCache = true;
        public bool verbose_cast;

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
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        [D2OIgnore]
        public uint TypeId
        {
            get => typeId;
            set => typeId = value;
        }

        [D2OIgnore]
        public uint Order
        {
            get => order;
            set => order = value;
        }

        [D2OIgnore]
        public string ScriptParams
        {
            get => scriptParams;
            set => scriptParams = value;
        }

        [D2OIgnore]
        public string ScriptParamsCritical
        {
            get => scriptParamsCritical;
            set => scriptParamsCritical = value;
        }

        [D2OIgnore]
        public int ScriptId
        {
            get => scriptId;
            set => scriptId = value;
        }

        [D2OIgnore]
        public int ScriptIdCritical
        {
            get => scriptIdCritical;
            set => scriptIdCritical = value;
        }

        [D2OIgnore]
        public int IconId
        {
            get => iconId;
            set => iconId = value;
        }

        [D2OIgnore]
        public List<uint> SpellLevels
        {
            get => spellLevels;
            set => spellLevels = value;
        }

        [D2OIgnore]
        public bool UseParamCache
        {
            get => useParamCache;
            set => useParamCache = value;
        }

        [D2OIgnore]
        public bool Verbose_cast
        {
            get => verbose_cast;
            set => verbose_cast = value;
        }

        [D2OIgnore]
        public string Default_zone
        {
            get => default_zone;
            set => default_zone = value;
        }

        [D2OIgnore]
        public bool BypassSummoningLimit
        {
            get => bypassSummoningLimit;
            set => bypassSummoningLimit = value;
        }

        [D2OIgnore]
        public bool CanAlwaysTriggerSpells
        {
            get => canAlwaysTriggerSpells;
            set => canAlwaysTriggerSpells = value;
        }

        int IIndexedData.Id => id;
    }
}