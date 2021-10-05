using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Companion", "com.ankamagames.dofus.datacenter.monsters")]
    [Serializable]
    public class Companion : IDataObject, IIndexedData
    {
        public const string MODULE = "Companions";
        public uint assetId;
        public List<uint> characteristics;
        public int creatureBoneId;

        [I18NField] public uint descriptionId;

        public int id;
        public string look;

        [I18NField] public uint nameId;

        public List<uint> spells;
        public uint startingSpellLevelId;
        public bool webDisplay;

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
        public string Look
        {
            get => look;
            set => look = value;
        }

        [D2OIgnore]
        public bool WebDisplay
        {
            get => webDisplay;
            set => webDisplay = value;
        }

        [D2OIgnore]
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        [D2OIgnore]
        public uint StartingSpellLevelId
        {
            get => startingSpellLevelId;
            set => startingSpellLevelId = value;
        }

        [D2OIgnore]
        public uint AssetId
        {
            get => assetId;
            set => assetId = value;
        }

        [D2OIgnore]
        public List<uint> Characteristics
        {
            get => characteristics;
            set => characteristics = value;
        }

        [D2OIgnore]
        public List<uint> Spells
        {
            get => spells;
            set => spells = value;
        }

        [D2OIgnore]
        public int CreatureBoneId
        {
            get => creatureBoneId;
            set => creatureBoneId = value;
        }

        int IIndexedData.Id => id;
    }
}